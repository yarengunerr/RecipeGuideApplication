using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TarifRehberi
{
    //tarif eşleşmesi 

    public partial class Form8 : Form
    {
        private Veritabanı_Servisi veritabani;
        private List<string> malzemeListesi;

        public Form8(Veritabanı_Servisi databaseService)
        {
            InitializeComponent();
            veritabani = databaseService;
            malzemeListesi = new List<string>();
        }

        private void buttonMalzemeEkle_Click(object sender, EventArgs e)
        {
            string malzeme = textBoxMalzeme.Text.Trim();
            if (!string.IsNullOrEmpty(malzeme) && !malzemeListesi.Contains(malzeme))
            {
                malzemeListesi.Add(malzeme);
                listBoxMalzemeler.Items.Add(malzeme);
                textBoxMalzeme.Clear();
            }
        }

        private void buttonEslesmeBul_Click(object sender, EventArgs e)
        {
            if (malzemeListesi.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir malzeme ekleyin.");
                return;
            }

            
            var tarifler = veritabani.TarifleriGetir();
            var eslesmeSonuclari = new List<Tuple<YemekTarifleri, double>>();

            foreach (var tarif in tarifler)
            {
                var tarifMalzemeleri = veritabani.TarifMalzemeleriGetir(tarif.TarifId)
                    .Select(m => m.Item1).ToList();

                double eslesmeYuzdesi = HesaplaEslesmeYuzdesi(malzemeListesi, tarifMalzemeleri);
                eslesmeSonuclari.Add(Tuple.Create(tarif, eslesmeYuzdesi));
            }

           
            var siraliSonuclar = eslesmeSonuclari.OrderByDescending(t => t.Item2).ToList();
            listBoxTarifler.Items.Clear();

            foreach (var sonuc in siraliSonuclar)
            {
                listBoxTarifler.Items.Add($"{sonuc.Item1.TarifAdi} - Eşleşme: %{sonuc.Item2:F1}");
            }
        }

        private double HesaplaEslesmeYuzdesi(List<string> kullaniciMalzemeler, List<string> tarifMalzemeler)
        {
            int ortakMalzemeSayisi = kullaniciMalzemeler
                .Count(m => tarifMalzemeler.Contains(m, StringComparer.OrdinalIgnoreCase));

            return (double)ortakMalzemeSayisi / tarifMalzemeler.Count * 100;
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
