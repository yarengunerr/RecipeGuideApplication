using System;
using System.Windows.Forms;

namespace TarifRehberi
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.txtTarifAdi = new System.Windows.Forms.TextBox();
            this.txtHazirlamaSuresi = new System.Windows.Forms.TextBox();
            this.txtTalimatlar = new System.Windows.Forms.TextBox();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaliyet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            
            
            this.txtTarifAdi.Location = new System.Drawing.Point(12, 35);
            this.txtTarifAdi.Name = "txtTarifAdi";
            this.txtTarifAdi.Size = new System.Drawing.Size(776, 22);
            this.txtTarifAdi.TabIndex = 0;
            
            
            
            this.txtHazirlamaSuresi.Location = new System.Drawing.Point(12, 96);
            this.txtHazirlamaSuresi.Name = "txtHazirlamaSuresi";
            this.txtHazirlamaSuresi.Size = new System.Drawing.Size(776, 22);
            this.txtHazirlamaSuresi.TabIndex = 1;
            
            
            
            this.txtTalimatlar.Location = new System.Drawing.Point(12, 165);
            this.txtTalimatlar.Multiline = true;
            this.txtTalimatlar.Name = "txtTalimatlar";
            this.txtTalimatlar.Size = new System.Drawing.Size(776, 93);
            this.txtTalimatlar.TabIndex = 2;
            
            
            
            this.txtKategori.Location = new System.Drawing.Point(11, 290);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(776, 22);
            this.txtKategori.TabIndex = 3;
            
            
            
            this.btnGuncelle.Location = new System.Drawing.Point(15, 611);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(120, 40);
            this.btnGuncelle.TabIndex = 4;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
             
            
            
            this.btnSil.Location = new System.Drawing.Point(671, 611);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(120, 40);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            
            
            
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tarif Adı";
             
            
            
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hazırlama Süresi";
            
            
            
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Talimatlar";
            
            
            
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kategori";
            
            
            
            this.textBox1.Location = new System.Drawing.Point(11, 356);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(383, 164);
            this.textBox1.TabIndex = 11;
            
            
            
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Malzemeler Ve Miktarları";
            
            
            
            this.txtMaliyet.Location = new System.Drawing.Point(11, 556);
            this.txtMaliyet.Name = "txtMaliyet";
            this.txtMaliyet.ReadOnly = true;
            this.txtMaliyet.Size = new System.Drawing.Size(776, 22);
            this.txtMaliyet.TabIndex = 13;
           
            
            
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 537);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Maliyet:";
            
            
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(840, 662);
            this.Controls.Add(this.txtMaliyet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKategori);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.txtTalimatlar);
            this.Controls.Add(this.txtHazirlamaSuresi);
            this.Controls.Add(this.txtTarifAdi);
            this.Name = "Form4";
            this.Text = "Tarif Detayları";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTarifAdi;
        private System.Windows.Forms.TextBox txtHazirlamaSuresi;
        private System.Windows.Forms.TextBox txtTalimatlar;
        private System.Windows.Forms.TextBox txtKategori; 
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private Label label6;
        private TextBox txtMaliyet;
    }
}
