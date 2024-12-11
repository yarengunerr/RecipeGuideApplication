using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TarifRehberi
{

    //tarif ekle yeri
    public partial class Form2 : Form
    {
        
        Veritabanı_Servisi veritabani = new Veritabanı_Servisi();

        
        private TextBox nameTextBox;
        private TextBox sureTextBox;
        private TextBox talimatTextBox;


        private ComboBox malzemeComboBox; 
        private TextBox malzemeMiktarTextBox; 
        private ComboBox kategoriComboBox; 

        private List<(string Malzeme, double Miktar)> tarifMalzemeleri = new List<(string Malzeme, double Miktar)>();


        
        public Form2()
        {
            InitializeComponent();

            
            Label baslikLabel = new Label();
            baslikLabel.Text = "TARİF EKLE";
            baslikLabel.Font = new System.Drawing.Font("Segoe UI", 20, System.Drawing.FontStyle.Italic);
            baslikLabel.AutoSize = true;
            baslikLabel.Location = new System.Drawing.Point(10, 10);
            baslikLabel.ForeColor = System.Drawing.Color.FromArgb(30, 144, 255);

            
            PictureBox resimBox = new PictureBox();
            resimBox.Image = System.Drawing.Image.FromFile(@"C:\Users\guner\OneDrive\Masaüstü\yazlab1 kodlarım\istockphoto-1204264626-612x612.jpg");
            resimBox.SizeMode = PictureBoxSizeMode.StretchImage;
            resimBox.Location = new System.Drawing.Point(350, 45);
            resimBox.Size = new System.Drawing.Size(200, 300);

            
            Label nameLabel = new Label();
            nameLabel.Text = "Yemek İsmi:";
            nameLabel.Location = new System.Drawing.Point(20, 60);
            nameTextBox = new TextBox();
            nameTextBox.Location = new System.Drawing.Point(120, 60);

            
            Label sureLabel = new Label();
            sureLabel.Text = "Hazırlık Süresi (dk):";
            sureLabel.Location = new System.Drawing.Point(20, 100);
            sureTextBox = new TextBox();
            sureTextBox.Location = new System.Drawing.Point(120, 100);

            
            Label talimatLabel = new Label();
            talimatLabel.Text = "Talimatlar:";
            talimatLabel.Location = new System.Drawing.Point(20, 180);
            talimatTextBox = new TextBox();
            talimatTextBox.Location = new System.Drawing.Point(120, 180);
            talimatTextBox.Size = new System.Drawing.Size(200, 100);
            talimatTextBox.Multiline = true;

            
            Label kategoriLabel = new Label();
            kategoriLabel.Text = "Kategori:";
            kategoriLabel.Location = new System.Drawing.Point(20, 300);
            kategoriComboBox = new ComboBox(); 
            kategoriComboBox.Location = new System.Drawing.Point(120, 300);
            kategoriComboBox.DropDownStyle = ComboBoxStyle.DropDownList; 
            kategoriComboBox.Items.AddRange(new string[] { "Ana Yemek", "Ara Sıcak", "Salata", "Tatlı", "Çorba" }); 

            
            Label malzemeLabel = new Label();
            malzemeLabel.Text = "Malzeme Ekle:";
            malzemeLabel.Location = new System.Drawing.Point(20, 350);
            Controls.Add(malzemeLabel);

            malzemeComboBox = new ComboBox(); 
            malzemeComboBox.Location = new System.Drawing.Point(120, 350);
            malzemeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(malzemeComboBox);

            
            Label miktarLabel = new Label();
            miktarLabel.Text = "Malzeme Miktarı:";
            miktarLabel.Location = new System.Drawing.Point(20, 400);
            Controls.Add(miktarLabel);

            malzemeMiktarTextBox = new TextBox(); 
            malzemeMiktarTextBox.Location = new System.Drawing.Point(120, 400);
            Controls.Add(malzemeMiktarTextBox);

            
            Button malzemeEkleButton = new Button();
            malzemeEkleButton.Text = "Malzeme Ekle";
            malzemeEkleButton.Location = new System.Drawing.Point(250, 450);
            malzemeEkleButton.Click += new EventHandler(MalzemeEkleButton_Click);
            Controls.Add(malzemeEkleButton);


            
            Button kaydetButton = new Button();
            kaydetButton.Text = "Kaydet";
            kaydetButton.Location = new System.Drawing.Point(410, 380);
            kaydetButton.Click += new EventHandler(KaydetButton_Click);
            kaydetButton.Size = new System.Drawing.Size(100, 50);

            
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(sureLabel);
            Controls.Add(sureTextBox);
            Controls.Add(talimatLabel);
            Controls.Add(talimatTextBox);
            Controls.Add(kategoriLabel);
            Controls.Add(kategoriComboBox); 
            Controls.Add(kaydetButton);
            Controls.Add(baslikLabel);
            Controls.Add(resimBox);
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadMalzemeListesi();
        }

        private void LoadMalzemeListesi()
        {
            var malzemeler = veritabani.MalzemeListele(); 
            malzemeComboBox.Items.Clear(); 
            foreach (var malzeme in malzemeler)
            {
                malzemeComboBox.Items.Add(malzeme.MalzemeAdi); 
            }
        }

        
        private void KaydetButton_Click(object sender, EventArgs e)
        {
            
            string tarifAdi = nameTextBox.Text;
            int hazirlamaSuresi = int.TryParse(sureTextBox.Text, out var sure) ? sure : 0;
            string talimatlar = talimatTextBox.Text;
            string kategori = kategoriComboBox.SelectedItem?.ToString();

            
            YemekTarifleri yeniTarif = new YemekTarifleri(tarifAdi, hazirlamaSuresi, talimatlar, kategori);

            
            bool tarifEklendi = veritabani.TarifEkle(yeniTarif);

            
            if (!tarifEklendi)
            {
                return; 
            }

            
            foreach (var (malzeme, miktar) in tarifMalzemeleri)
            {
                int malzemeId = veritabani.MalzemeIdBul(malzeme);

                
                if (veritabani.MalzemeMiktarKontrol(malzemeId, miktar))
                {
                    veritabani.TarifMalzemeIliskiEkle(yeniTarif.TarifId, malzemeId, miktar);
                }
                else
                {
                    MessageBox.Show($"{malzeme} için yeterli malzeme yok! Tarifi kaydetmeden önce lütfen malzemeleri kontrol edin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
            }

            MessageBox.Show("Tarif başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); 
        }

        private void MalzemeEkleButton_Click(object sender, EventArgs e)
        {
            string selectedMalzeme = malzemeComboBox.SelectedItem?.ToString();
            double malzemeMiktar;

            if (string.IsNullOrEmpty(selectedMalzeme))
            {
                MessageBox.Show("Malzeme seçmelisiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            foreach (var (malzeme, _) in tarifMalzemeleri)
            {
                if (malzeme.Equals(selectedMalzeme, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"{selectedMalzeme} malzemesi zaten eklenmiş!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
            }

           

            int malzemeId = veritabani.MalzemeIdBul(selectedMalzeme); 

            while (true) 
            {
                
                if (double.TryParse(malzemeMiktarTextBox.Text, out malzemeMiktar))
                {
                    
                    if (veritabani.MalzemeMiktarKontrol(malzemeId, malzemeMiktar))
                    {
                        
                        tarifMalzemeleri.Add((selectedMalzeme, malzemeMiktar));
                        MessageBox.Show($"{selectedMalzeme} malzemesi {malzemeMiktar} miktarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        malzemeComboBox.SelectedIndex = -1;
                        malzemeMiktarTextBox.Clear();
                        break; 
                    }
                    else
                    {
                        
                        MessageBox.Show($"{selectedMalzeme} için yeterli malzeme yok! Lütfen tekrar miktar girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        malzemeMiktarTextBox.Clear(); 
                        malzemeMiktarTextBox.Focus(); 
                        return; 
                    }
                }
                else
                {
                    
                    MessageBox.Show("Geçersiz malzeme miktarı! Lütfen tekrar deneyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    malzemeMiktarTextBox.Clear(); 
                    malzemeMiktarTextBox.Focus(); 
                    return;
                }
            }
        }



    }
}
