using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TarifRehberi
{
    public partial class Form9 : Form
    {
        private List<YemekTarifleri> tarifler;

        public Form9(List<YemekTarifleri> tarifler) 
        {
            InitializeComponent();
            this.tarifler = tarifler;
            Hazirla();
        }

        private void Hazirla()
        {
            
            comboBoxSiralama.Items.Add("Hazırlama Süresine Göre (Artan)");
            comboBoxSiralama.Items.Add("Hazırlama Süresine Göre (Azalan)");
            comboBoxSiralama.Items.Add("Maliyete Göre (Artan)");
            comboBoxSiralama.Items.Add("Maliyete Göre (Azalan)");

            
            comboBoxMalzemeSayisi.Items.Add("1 Malzeme");
            comboBoxMalzemeSayisi.Items.Add("2 Malzeme");
            comboBoxMalzemeSayisi.Items.Add("3 Malzeme");
            comboBoxMalzemeSayisi.Items.Add("4 Malzeme");
            comboBoxMalzemeSayisi.Items.Add("5 veya daha fazla Malzeme");

            
            comboBoxKategori.Items.Add("Ana Yemek");
            comboBoxKategori.Items.Add("Çorba");
            comboBoxKategori.Items.Add("Salata");
            comboBoxKategori.Items.Add("Tatlı");
            comboBoxKategori.Items.Add("Ara Sıcak");


            textBoxMaliyetBaslangic.Text = "0";
            textBoxMaliyetBitis.Text = "1000"; 
        }

        private void buttonUygula_Click(object sender, EventArgs e)
        {
            
            var siralamaSecimi = comboBoxSiralama.SelectedItem?.ToString();
            var malzemeSayisiSecimi = comboBoxMalzemeSayisi.SelectedItem?.ToString();
            var kategoriSecimi = comboBoxKategori.SelectedItem?.ToString();
            double maliyetBaslangic = double.TryParse(textBoxMaliyetBaslangic.Text, out var baslangic) ? baslangic : 0;
            double maliyetBitis = double.TryParse(textBoxMaliyetBitis.Text, out var bitis) ? bitis : double.MaxValue;

            IEnumerable<YemekTarifleri> filtrelenmisTarifler = tarifler;

            
            if (!string.IsNullOrEmpty(malzemeSayisiSecimi))
            {
                int malzemeSayisi = int.Parse(malzemeSayisiSecimi.Split(' ')[0]);
                filtrelenmisTarifler = filtrelenmisTarifler.Where(t => t.Malzemeler.Count == malzemeSayisi);
            }

            
            if (!string.IsNullOrEmpty(kategoriSecimi))
            {
                filtrelenmisTarifler = filtrelenmisTarifler.Where(t => t.Kategori.Equals(kategoriSecimi, StringComparison.OrdinalIgnoreCase));
            }

            
            filtrelenmisTarifler = filtrelenmisTarifler.Where(t => t.ToplamMaliyet >= maliyetBaslangic && t.ToplamMaliyet <= maliyetBitis);

            
            if (!string.IsNullOrEmpty(siralamaSecimi))
            {
                switch (siralamaSecimi)
                {
                    case "Hazırlama Süresine Göre (Artan)":
                        filtrelenmisTarifler = filtrelenmisTarifler.OrderBy(t => t.TarifSuresi);
                        break;
                    case "Hazırlama Süresine Göre (Azalan)":
                        filtrelenmisTarifler = filtrelenmisTarifler.OrderByDescending(t => t.TarifSuresi);
                        break;
                    case "Maliyete Göre (Artan)":
                        filtrelenmisTarifler = filtrelenmisTarifler.OrderBy(t => t.ToplamMaliyet);
                        break;
                    case "Maliyete Göre (Azalan)":
                        filtrelenmisTarifler = filtrelenmisTarifler.OrderByDescending(t => t.ToplamMaliyet);
                        break;
                }
            }

            
            ListeyiGuncelle(filtrelenmisTarifler.ToList());
        }

        private void ListeyiGuncelle(List<YemekTarifleri> guncelTarifler)
        {
            listBoxSonuclar.Items.Clear();

            foreach (var tarif in guncelTarifler)
            {
                listBoxSonuclar.Items.Add(tarif.TarifAdi + " - Maliyet: " + tarif.ToplamMaliyet.ToString("C") + " - Süre: " + tarif.TarifSuresi + " dk");
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
