using System.Windows.Forms;

namespace TarifRehberi
{
    partial class Form6
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxMalzeme;
        private Label labelMalzeme;
        private Button buttonOneriAl;
        private Button buttonMalzemeEkle; 
        private Button buttonMalzemeSifirla; 

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxMalzeme = new System.Windows.Forms.TextBox();
            this.labelMalzeme = new System.Windows.Forms.Label();
            this.buttonOneriAl = new System.Windows.Forms.Button();
            this.buttonMalzemeEkle = new System.Windows.Forms.Button();
            this.buttonMalzemeSifirla = new System.Windows.Forms.Button();
            this.listViewTarifler = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            
            
             
            this.textBoxMalzeme.Location = new System.Drawing.Point(20, 40);
            this.textBoxMalzeme.Name = "textBoxMalzeme";
            this.textBoxMalzeme.Size = new System.Drawing.Size(150, 22);
            this.textBoxMalzeme.TabIndex = 1;
            
           
            
            this.labelMalzeme.AutoSize = true;
            this.labelMalzeme.Location = new System.Drawing.Point(20, 20);
            this.labelMalzeme.Name = "labelMalzeme";
            this.labelMalzeme.Size = new System.Drawing.Size(85, 16);
            this.labelMalzeme.TabIndex = 3;
            this.labelMalzeme.Text = "Malzeme Adı";
            
            
            
            this.buttonOneriAl.Location = new System.Drawing.Point(320, 38);
            this.buttonOneriAl.Name = "buttonOneriAl";
            this.buttonOneriAl.Size = new System.Drawing.Size(100, 23);
            this.buttonOneriAl.TabIndex = 3;
            this.buttonOneriAl.Text = "Tarif Önerisi Al";
            this.buttonOneriAl.Click += new System.EventHandler(this.buttonOneriAl_Click);
            
            
           
            this.buttonMalzemeEkle.Location = new System.Drawing.Point(200, 38);
            this.buttonMalzemeEkle.Name = "buttonMalzemeEkle";
            this.buttonMalzemeEkle.Size = new System.Drawing.Size(100, 23);
            this.buttonMalzemeEkle.TabIndex = 2;
            this.buttonMalzemeEkle.Text = "Malzeme Ekle";
            this.buttonMalzemeEkle.Click += new System.EventHandler(this.buttonMalzemeEkle_Click);
           
            
            
            this.buttonMalzemeSifirla.Location = new System.Drawing.Point(430, 38);
            this.buttonMalzemeSifirla.Name = "buttonMalzemeSifirla";
            this.buttonMalzemeSifirla.Size = new System.Drawing.Size(100, 23);
            this.buttonMalzemeSifirla.TabIndex = 4;
            this.buttonMalzemeSifirla.Text = "Malzeme Sıfırla";
            this.buttonMalzemeSifirla.Click += new System.EventHandler(this.buttonMalzemeSifirla_Click);
           
            
            
            this.listViewTarifler.HideSelection = false;
            this.listViewTarifler.Location = new System.Drawing.Point(20, 102);
            this.listViewTarifler.Name = "listViewTarifler";
            this.listViewTarifler.Size = new System.Drawing.Size(510, 286);
            this.listViewTarifler.TabIndex = 5;
            this.listViewTarifler.UseCompatibleStateImageBehavior = false;
            
            
           
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.listViewTarifler);
            this.Controls.Add(this.textBoxMalzeme);
            this.Controls.Add(this.buttonMalzemeEkle);
            this.Controls.Add(this.labelMalzeme);
            this.Controls.Add(this.buttonOneriAl);
            this.Controls.Add(this.buttonMalzemeSifirla);
            this.Name = "Form6";
            this.Text = "Tarif Önerisi";
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ListView listViewTarifler;
    }
}
