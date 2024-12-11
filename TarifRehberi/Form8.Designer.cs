using System.Windows.Forms;

namespace TarifRehberi
{
    partial class Form8
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxMalzeme;
        private Button buttonMalzemeEkle;
        private Button buttonEslesmeBul;
        private ListBox listBoxMalzemeler;
        private ListBox listBoxTarifler;

        private void InitializeComponent()
        {
            this.textBoxMalzeme = new System.Windows.Forms.TextBox();
            this.buttonMalzemeEkle = new System.Windows.Forms.Button();
            this.buttonEslesmeBul = new System.Windows.Forms.Button();
            this.listBoxMalzemeler = new System.Windows.Forms.ListBox();
            this.listBoxTarifler = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            
            this.textBoxMalzeme.Location = new System.Drawing.Point(20, 20);
            this.textBoxMalzeme.Name = "textBoxMalzeme";
            this.textBoxMalzeme.Size = new System.Drawing.Size(200, 22);
            this.textBoxMalzeme.TabIndex = 0;
            
            this.buttonMalzemeEkle.Location = new System.Drawing.Point(230, 20);
            this.buttonMalzemeEkle.Name = "buttonMalzemeEkle";
            this.buttonMalzemeEkle.Size = new System.Drawing.Size(75, 23);
            this.buttonMalzemeEkle.TabIndex = 1;
            this.buttonMalzemeEkle.Text = "Malzeme Ekle";
            this.buttonMalzemeEkle.Click += new System.EventHandler(this.buttonMalzemeEkle_Click);
            
            this.buttonEslesmeBul.Location = new System.Drawing.Point(20, 220);
            this.buttonEslesmeBul.Name = "buttonEslesmeBul";
            this.buttonEslesmeBul.Size = new System.Drawing.Size(75, 23);
            this.buttonEslesmeBul.TabIndex = 3;
            this.buttonEslesmeBul.Text = "Tarif Eşleşmesi Bul";
            this.buttonEslesmeBul.Click += new System.EventHandler(this.buttonEslesmeBul_Click);
            
            this.listBoxMalzemeler.ItemHeight = 16;
            this.listBoxMalzemeler.Location = new System.Drawing.Point(20, 60);
            this.listBoxMalzemeler.Name = "listBoxMalzemeler";
            this.listBoxMalzemeler.Size = new System.Drawing.Size(200, 148);
            this.listBoxMalzemeler.TabIndex = 2;
            
            this.listBoxTarifler.ItemHeight = 16;
            this.listBoxTarifler.Location = new System.Drawing.Point(20, 260);
            this.listBoxTarifler.Name = "listBoxTarifler";
            this.listBoxTarifler.Size = new System.Drawing.Size(300, 196);
            this.listBoxTarifler.TabIndex = 4;
            
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.textBoxMalzeme);
            this.Controls.Add(this.buttonMalzemeEkle);
            this.Controls.Add(this.listBoxMalzemeler);
            this.Controls.Add(this.buttonEslesmeBul);
            this.Controls.Add(this.listBoxTarifler);
            this.Name = "Form8";
            this.Text = "Tarif Eşleşmesi";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
