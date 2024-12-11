using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TarifRehberi
{
    //tarif detayları yeri

    public partial class Form4 : Form
    {
        private YemekTarifleri tarif;
        private Veritabanı_Servisi veritabani;

        private Form3 parentForm;

        public Form4(YemekTarifleri secilenTarif, Form3 form)
        {
            InitializeComponent();
            this.tarif = secilenTarif; 
            this.parentForm = form;     
            veritabani = new Veritabanı_Servisi();

            
            TarifDetaylariniYukle();
        }

        private void TarifDetaylariniYukle()
        {
            
            if (txtTarifAdi != null && txtHazirlamaSuresi != null && txtTalimatlar != null && txtKategori != null && textBox1 != null)
            {
                txtTarifAdi.Text = tarif.TarifAdi;
                txtHazirlamaSuresi.Text = tarif.TarifSuresi.ToString();
                txtTalimatlar.Text = tarif.Talimatlar;
                txtKategori.Text = tarif.Kategori;

                
                List<Tuple<string, double>> malzemeler = veritabani.TarifMalzemeleriGetir(tarif.TarifId);

                
                textBox1.Clear();
                foreach (var malzeme in malzemeler)
                {
                    textBox1.AppendText($"{malzeme.Item1}: {malzeme.Item2} birim{Environment.NewLine}");
                }

                
                double maliyet = MaliyetHesapla();
                txtMaliyet.Text = maliyet.ToString("F2"); 

                
                Console.WriteLine($"Tarif ID: {tarif.TarifId}");
            }
            else
            {
                MessageBox.Show("Form kontrolleri yüklenemedi. Lütfen kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            
            tarif.TarifAdi = txtTarifAdi.Text;
            tarif.TarifSuresi = int.TryParse(txtHazirlamaSuresi.Text, out int sure) ? sure : tarif.TarifSuresi;
            tarif.Talimatlar = txtTalimatlar.Text;
            tarif.Kategori = txtKategori.Text;

            
            veritabani.TarifGuncelle(tarif);

            
            string[] malzemeSatirlari = textBox1.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string satir in malzemeSatirlari)
            {
                string[] malzemeBilgileri = satir.Split(':');
                if (malzemeBilgileri.Length == 2)
                {
                    string malzemeAdi = malzemeBilgileri[0].Trim();
                    if (double.TryParse(malzemeBilgileri[1].Trim().Split(' ')[0], out double yeniMiktar))
                    {
                        int malzemeId = veritabani.MalzemeIdBul(malzemeAdi);

                        
                        veritabani.TarifMalzemeGuncelle(tarif.TarifId, malzemeId, yeniMiktar);

                       
                        veritabani.MalzemeAdiGuncelle(malzemeId, malzemeAdi); 
                    }
                }
            }

            MessageBox.Show("Tarif ve malzemeler güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            parentForm.TarifleriYukle();

            this.Close();
        }



        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                
                List<Tuple<string, double>> malzemeler = veritabani.TarifMalzemeleriGetir(tarif.TarifId);
                foreach (var malzeme in malzemeler)
                {
                    int malzemeId = veritabani.MalzemeIdBul(malzeme.Item1);
                    veritabani.TarifMalzemeSil(tarif.TarifId, malzemeId);
                }

                
                veritabani.TarifSil(tarif.TarifId);

                MessageBox.Show("Tarif ve ilgili malzemeler başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                parentForm.TarifleriYukle();

                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double MaliyetHesapla()
        {
            double toplamMaliyet = 0;

            
            List<Tuple<string, double>> malzemeler = veritabani.TarifMalzemeleriGetir(tarif.TarifId);

            foreach (var malzeme in malzemeler)
            {
                string malzemeAdi = malzeme.Item1;
                double miktar = malzeme.Item2;

                
                double birimFiyat = veritabani.MalzemeBirimFiyatiBul(malzemeAdi);

                
                toplamMaliyet += birimFiyat * miktar;
            }

            return toplamMaliyet;
        }



        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
    }
}
