using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TarifRehberi
{
    //tarif önerisi yeri

    public partial class Form6 : Form
    {
        private Veritabanı_Servisi veritabani; 
        private List<string> malzemeListesi; 

        public Form6(Veritabanı_Servisi databaseService)
        {
            InitializeComponent();
            veritabani = databaseService; 
            malzemeListesi = new List<string>(); 

            
            listViewTarifler.Columns.Add("Tarif Bilgisi", -2, HorizontalAlignment.Left);

            
            LoadTarifler();

            
            listViewTarifler.MouseClick += ListViewTarifler_MouseClick; 
        }

        private void LoadTarifler()
        {
            
            var tarifler = veritabani.TarifleriGetir();
            listViewTarifler.Items.Clear(); 

            foreach (var tarif in tarifler)
            {
                
                var malzemeler = veritabani.TarifMalzemeleriGetir(tarif.TarifId);
                string malzemeBilgisi = string.Join(", ", malzemeler.Select(malzeme => $"{malzeme.Item1} ({malzeme.Item2})"));

                
                decimal toplamMaliyet = veritabani.TarifMaliyetiGetir(tarif.TarifId);

                
                string itemText = $"{tarif.TarifAdi} - Malzemeler: {malzemeBilgisi} - Toplam Maliyet: {toplamMaliyet:C}"; 

                
                listViewTarifler.Items.Add(new ListViewItem(itemText));
            }
        }

        
        private void buttonMalzemeEkle_Click(object sender, EventArgs e)
        {
            string malzeme = textBoxMalzeme.Text.Trim(); 

            if (!string.IsNullOrEmpty(malzeme) && !malzemeListesi.Contains(malzeme)) 
            {
                malzemeListesi.Add(malzeme); 
                MessageBox.Show($"{malzeme} malzemesi eklendi."); 
                textBoxMalzeme.Clear(); 
            }
            else
            {
                MessageBox.Show("Geçersiz malzeme veya malzeme zaten eklenmiş."); 
            }
        }

        
        
        private void buttonOneriAl_Click(object sender, EventArgs e)
        {
            
            List<YemekTarifleri> uygunTarifler = new List<YemekTarifleri>();

            
            var tarifler = veritabani.TarifleriGetir();

            
            listViewTarifler.Items.Clear();

            foreach (var tarif in tarifler)
            {
                
                var malzemeler = veritabani.TarifMalzemeleriGetir(tarif.TarifId)
                    .Select(malzeme => malzeme.Item1) 
                    .ToList();

                
                if (malzemeListesi.Count > 0 && malzemeListesi.Count == malzemeler.Count &&
                    malzemeListesi.All(malzeme => malzemeler.Contains(malzeme, StringComparer.OrdinalIgnoreCase)))
                {
                    uygunTarifler.Add(tarif); 
                    listViewTarifler.Items.Add(new ListViewItem($"{tarif.TarifAdi} - Tam Uyumlu") { ForeColor = Color.Green }); 
                }
                else if (malzemeListesi.Any(malzeme => malzemeler.Contains(malzeme, StringComparer.OrdinalIgnoreCase)))
                {
                    
                    var eksikMalzemeler = new List<string>();
                    decimal toplamMaliyet = 0;

                    foreach (var malzeme in malzemeler)
                    {
                        
                        if (!malzemeListesi.Contains(malzeme, StringComparer.OrdinalIgnoreCase))
                        {
                            eksikMalzemeler.Add(malzeme);

                            
                            decimal birimFiyat = (decimal)veritabani.MalzemeBirimFiyatiBul(malzeme);
                            toplamMaliyet += birimFiyat; 
                        }
                    }

                    
                    var listViewItem = new ListViewItem($"{tarif.TarifAdi} - Eksik Malzemeler: {string.Join(", ", eksikMalzemeler)}") { ForeColor = Color.Red };
                    listViewTarifler.Items.Add(listViewItem);

                    
                    if (eksikMalzemeler.Count > 0)
                    {
                        string mesaj = "Eksik malzemeler:\n" + string.Join(", ", eksikMalzemeler) +
                                       $"\n\nToplam eksik malzeme maliyeti: {toplamMaliyet:C}"; 
                        MessageBox.Show(mesaj);
                    }
                }
            }

            
            if (uygunTarifler.Count == 0)
            {
                MessageBox.Show("Seçilen malzemelere uygun tarif bulunamadı."); 
            }
        }


        
        private void buttonMalzemeSifirla_Click(object sender, EventArgs e)
        {
            malzemeListesi.Clear(); 
            MessageBox.Show("Malzeme listesi sıfırlandı."); 

            
            LoadTarifler(); 

            
            foreach (ListViewItem item in listViewTarifler.Items)
            {
                item.ForeColor = Color.Black; 
            }
        }

        
        private void ListViewTarifler_MouseClick(object sender, MouseEventArgs e)
        {
            
            var item = listViewTarifler.GetItemAt(e.X, e.Y);
            if (item != null && item.ForeColor == Color.Red) 
            {
                
                string tarifAdi = item.Text.Split('-')[0].Trim();

                
                var tarif = veritabani.TarifleriGetir().FirstOrDefault(t => t.TarifAdi == tarifAdi); 

                
                if (tarif == null)
                {
                    MessageBox.Show("Tarif bulunamadı."); 
                    return; 
                }

                var malzemeler = veritabani.TarifMalzemeleriGetir(tarif.TarifId);
                decimal toplamMaliyet = 0; 
                List<string> eksikMalzemeler = new List<string>();

                foreach (var malzeme in malzemeler)
                {
                    
                    if (!malzemeListesi.Contains(malzeme.Item1, StringComparer.OrdinalIgnoreCase))
                    {
                        eksikMalzemeler.Add(malzeme.Item1); 

                        
                        decimal birimFiyat = (decimal)veritabani.MalzemeBirimFiyatiBul(malzeme.Item1); 

                        
                        toplamMaliyet += birimFiyat * (decimal)malzeme.Item2; 
                    }
                }

                
                string mesaj = "Eksik malzemeler:\n" + string.Join(", ", eksikMalzemeler) +
                               $"\n\nToplam maliyet: {toplamMaliyet:C}"; 
                MessageBox.Show(mesaj);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoadTarifler(); 
        }


    }
}
