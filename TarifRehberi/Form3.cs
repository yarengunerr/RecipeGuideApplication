using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace TarifRehberi
{
    //tüm tarifler yeri

    public partial class Form3 : Form
    {
        private Veritabanı_Servisi veritabani;
        private List<YemekTarifleri> tarifler; 
        private ListBox tarifListesi;          
        private TextBox aramaKutusu;           

        public Form3()
        {
            InitializeComponent();
            veritabani = new Veritabanı_Servisi();
            TarifleriYukle();

            
            aramaKutusu = new TextBox();
            aramaKutusu.Location = new System.Drawing.Point(20, 20); 
            aramaKutusu.Width = 200;                                 

            
            Button araButonu = new Button();
            araButonu.Text = "Ara";
            araButonu.Location = new System.Drawing.Point(230, 20); 
            araButonu.Click += new EventHandler(AraButonu_Click);   

            
            PictureBox resimBox = new PictureBox();
            resimBox.Image = System.Drawing.Image.FromFile(@"C:\Users\guner\OneDrive\Masaüstü\yazlab1 kodlarım\indir (1).jpeg");
            resimBox.SizeMode = PictureBoxSizeMode.StretchImage; 
            resimBox.Location = new System.Drawing.Point(20, 375); 
            resimBox.Size = new System.Drawing.Size(300, 200);

            Button öneriButonu = new Button();
            öneriButonu.Text = "Tarif Önerisi Al";
            öneriButonu.Location = new System.Drawing.Point(350, 20); 
            öneriButonu.Click += new EventHandler(OneriButonu_Click);   
            öneriButonu.Size = new System.Drawing.Size(100, 25);
            Controls.Add(öneriButonu);

            
            Button eslesmeButonu = new Button();
            eslesmeButonu.Text = "Tarif Eşleşmesi";
            eslesmeButonu.Location = new System.Drawing.Point(500, 20); 
            eslesmeButonu.Click += new EventHandler(EslesmeButonu_Click);
            eslesmeButonu.Size = new System.Drawing.Size(100, 25);
            Controls.Add(eslesmeButonu);

            
            Button filtrelemeButonu = new Button();
            filtrelemeButonu.Text = "Tarif Filtreleme";
            filtrelemeButonu.Location = new System.Drawing.Point(650, 20);
            filtrelemeButonu.Click += new EventHandler(FiltrelemeButonu_Click); 
            filtrelemeButonu.Size = new System.Drawing.Size(120, 25);
            Controls.Add(filtrelemeButonu);



            
            Controls.Add(aramaKutusu);
            Controls.Add(araButonu);

            Controls.Add(resimBox);
        }

        public void TarifleriYukle()
        {
            tarifler = veritabani.TarifleriGetir(); 

            
            foreach (var tarif in tarifler)
            {
                tarif.Malzemeler = veritabani.TarifMalzemeleriGetir(tarif.TarifId); 
                tarif.ToplamMaliyet = veritabani.MaliyetHesapla(tarif.TarifId); 
            }

            
            tarifListesi = new ListBox();
            tarifListesi.Location = new System.Drawing.Point(20, 60); 
            tarifListesi.Size = new System.Drawing.Size(700, 300);

            
            ListeyiGuncelle(tarifler);

            tarifListesi.DisplayMember = "Goruntule"; 
            tarifListesi.SelectedIndexChanged += TarifListesi_SecimDegisti; 
            this.Controls.Add(tarifListesi);
        }


        
        public void ListeyiGuncelle(List<YemekTarifleri> guncelTarifler)
        {
            tarifListesi.Items.Clear(); 

            foreach (var tarif in guncelTarifler)
            {
                
                tarifListesi.Items.Add(new ListeKutusuOgeleri(tarif));
            }
        }

        private void Arama(string anahtarKelime)
        {
            List<YemekTarifleri> sonuclar;

            if (string.IsNullOrWhiteSpace(anahtarKelime))
            {
                sonuclar = tarifler; 
            }
            else
            {
                
                sonuclar = tarifler.Where(tarif =>
                    tarif.TarifAdi.ToLower().Contains(anahtarKelime.ToLower()) ||
                    tarif.Malzemeler.Any(malzeme => malzeme.Item1.ToLower().Contains(anahtarKelime.ToLower())) 
                ).ToList();
            }

            
            ListeyiGuncelle(sonuclar);
        }


        
        private void AraButonu_Click(object sender, EventArgs e)
        {
            string anahtarKelime = aramaKutusu.Text; 
            Arama(anahtarKelime);                    
        }

        private void TarifListesi_SecimDegisti(object sender, EventArgs e)
        {
            
            var listeKutusu = sender as ListBox;
            if (listeKutusu.SelectedItem is ListeKutusuOgeleri secilenOgeler)
            {
                
                Form4 form4 = new Form4(secilenOgeler.Tarif, this); 
                form4.ShowDialog();
            }
        }


        
        
        private class ListeKutusuOgeleri
        {
            public YemekTarifleri Tarif { get; }

            public string Goruntule
            {
                get
                {
                    
                    string malzemeBilgisi = "";
                    if (Tarif.Malzemeler != null && Tarif.Malzemeler.Any()) 
                    {
                        malzemeBilgisi = string.Join(", ", Tarif.Malzemeler.Select(malzeme => $"{malzeme.Item1} ({malzeme.Item2})")); 
                    }
                    else
                    {
                        malzemeBilgisi = "Malzeme yok";
                    }

                    
                    return $"{Tarif.TarifAdi} - {Tarif.TarifSuresi} dk - Toplam Maliyet: {Tarif.ToplamMaliyet:C} - Malzemeler: {malzemeBilgisi}";
                }
            }

            public ListeKutusuOgeleri(YemekTarifleri tarif)
            {
                Tarif = tarif;
            }
        }

        private void OneriButonu_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(veritabani); 
            form6.ShowDialog(); 
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        
        private void EslesmeButonu_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8(veritabani); 
            form8.ShowDialog(); 
        }

        
        private void FiltrelemeButonu_Click(object sender, EventArgs e)
        {
            
            var form9 = new Form9(tarifler); 
            form9.Show();

        }
    }
}
