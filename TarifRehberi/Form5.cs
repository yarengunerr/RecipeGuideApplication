using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarifRehberi
{
    //malzeme ekle yeri

    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent(); 

            this.button1.Click += new System.EventHandler(this.buttonKaydet_Click);
            
            this.buttonMalzemeleriGoster.Click += new System.EventHandler(this.buttonMalzemeleriGoster_Click);

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            Veritabanı_Servisi dbService = new Veritabanı_Servisi();

            string malzemeAdı = textBoxMalzemeAdı.Text;
            int toplamMiktar = int.Parse(textBoxToplamMiktar.Text);
            string malzemeBirimi = comboBoxMalzemeBirimi.SelectedItem.ToString(); 
            decimal birimFiyat = decimal.Parse(textBoxBirimFiyat.Text); 

            try
            {
                dbService.MalzemeKaydet(malzemeAdı, toplamMiktar, malzemeBirimi, birimFiyat); 
                MessageBox.Show("Malzeme başarıyla kaydedildi.");
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void buttonMalzemeleriGoster_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }



    }
}
