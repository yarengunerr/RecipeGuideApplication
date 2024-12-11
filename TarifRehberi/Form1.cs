using System;
using System.Windows.Forms;

namespace TarifRehberi
{   
    //form1 ana ekran

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing; 

            
            Label baslikLabel = new Label();
            baslikLabel.Text = "YÖRESEL GİRESUN YEMEKLERİ";
            baslikLabel.Font = new System.Drawing.Font("Segoe UI", 24, System.Drawing.FontStyle.Italic); 
            baslikLabel.AutoSize = true;
            baslikLabel.Location = new System.Drawing.Point(200, 160); 
            baslikLabel.ForeColor = System.Drawing.Color.FromArgb(30, 144, 255); 


            
            Button tumTariflerButton = new Button();
            tumTariflerButton.Text = "Tüm Tarifler";
            tumTariflerButton.Location = new System.Drawing.Point(320, 370);  
            tumTariflerButton.Click += new EventHandler(TumTariflerButton_Click);  
            tumTariflerButton.Size = new System.Drawing.Size(250, 100);
            tumTariflerButton.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Italic);

            
            Button tarifEkleButton = new Button();
            tarifEkleButton.Text = "Tarif Ekle";
            tarifEkleButton.Location = new System.Drawing.Point(120, 250); 
            tarifEkleButton.Click += new EventHandler(TarifEkleButton_Click); 
            tarifEkleButton.Size = new System.Drawing.Size(250, 100);
            tarifEkleButton.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Italic); 

            
            Button malzemeEkleButton = new Button();
            malzemeEkleButton.Text = "Malzeme Ekle";
            malzemeEkleButton.Location = new System.Drawing.Point(500, 250); 
            malzemeEkleButton.Click += new EventHandler(MalzemeEkleButton_Click); 
            malzemeEkleButton.Size = new System.Drawing.Size(250, 100);
            malzemeEkleButton.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Italic);





            Controls.Add(tumTariflerButton);
            Controls.Add(tarifEkleButton);
            Controls.Add(baslikLabel);
            Controls.Add(malzemeEkleButton);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0); 
        }


        
        private void TumTariflerButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(); 
            form3.Show(); 
        }


        
        private void TarifEkleButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        
        private void MalzemeEkleButton_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(); 
            form5.Show(); 
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
