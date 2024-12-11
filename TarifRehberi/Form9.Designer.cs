namespace TarifRehberi
{
    partial class Form9
    {
        private System.ComponentModel.IContainer components = null;

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
            this.comboBoxSiralama = new System.Windows.Forms.ComboBox();
            this.buttonUygula = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMalzemeSayisi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxKategori = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaliyetBaslangic = new System.Windows.Forms.TextBox();
            this.textBoxMaliyetBitis = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxSonuclar = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comboBoxSiralama
            // 
            this.comboBoxSiralama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSiralama.FormattingEnabled = true;
            this.comboBoxSiralama.Location = new System.Drawing.Point(20, 37);
            this.comboBoxSiralama.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxSiralama.Name = "comboBoxSiralama";
            this.comboBoxSiralama.Size = new System.Drawing.Size(332, 24);
            this.comboBoxSiralama.TabIndex = 0;
            // 
            // buttonUygula
            // 
            this.buttonUygula.Location = new System.Drawing.Point(373, 37);
            this.buttonUygula.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUygula.Name = "buttonUygula";
            this.buttonUygula.Size = new System.Drawing.Size(100, 28);
            this.buttonUygula.TabIndex = 1;
            this.buttonUygula.Text = "Uygula";
            this.buttonUygula.UseVisualStyleBackColor = true;
            this.buttonUygula.Click += new System.EventHandler(this.buttonUygula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sıralama Seçenekleri";
            // 
            // comboBoxMalzemeSayisi
            // 
            this.comboBoxMalzemeSayisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMalzemeSayisi.FormattingEnabled = true;
            this.comboBoxMalzemeSayisi.Location = new System.Drawing.Point(20, 98);
            this.comboBoxMalzemeSayisi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMalzemeSayisi.Name = "comboBoxMalzemeSayisi";
            this.comboBoxMalzemeSayisi.Size = new System.Drawing.Size(332, 24);
            this.comboBoxMalzemeSayisi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Malzeme Sayısı";
            // 
            // comboBoxKategori
            // 
            this.comboBoxKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKategori.FormattingEnabled = true;
            this.comboBoxKategori.Location = new System.Drawing.Point(20, 160);
            this.comboBoxKategori.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxKategori.Name = "comboBoxKategori";
            this.comboBoxKategori.Size = new System.Drawing.Size(332, 24);
            this.comboBoxKategori.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kategori";
            // 
            // textBoxMaliyetBaslangic
            // 
            this.textBoxMaliyetBaslangic.Location = new System.Drawing.Point(20, 222);
            this.textBoxMaliyetBaslangic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMaliyetBaslangic.Name = "textBoxMaliyetBaslangic";
            this.textBoxMaliyetBaslangic.Size = new System.Drawing.Size(132, 22);
            this.textBoxMaliyetBaslangic.TabIndex = 7;
            // 
            // textBoxMaliyetBitis
            // 
            this.textBoxMaliyetBitis.Location = new System.Drawing.Point(220, 222);
            this.textBoxMaliyetBitis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMaliyetBitis.Name = "textBoxMaliyetBitis";
            this.textBoxMaliyetBitis.Size = new System.Drawing.Size(132, 22);
            this.textBoxMaliyetBitis.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Maliyet Aralığı (Başlangıç)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 203);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Maliyet Aralığı (Bitiş)";
            // 
            // listBoxSonuclar
            // 
            this.listBoxSonuclar.FormattingEnabled = true;
            this.listBoxSonuclar.ItemHeight = 16;
            this.listBoxSonuclar.Location = new System.Drawing.Point(20, 271);
            this.listBoxSonuclar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxSonuclar.Name = "listBoxSonuclar";
            this.listBoxSonuclar.Size = new System.Drawing.Size(452, 116);
            this.listBoxSonuclar.TabIndex = 11;
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 407);
            this.Controls.Add(this.listBoxSonuclar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMaliyetBitis);
            this.Controls.Add(this.textBoxMaliyetBaslangic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxKategori);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMalzemeSayisi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUygula);
            this.Controls.Add(this.comboBoxSiralama);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form9";
            this.Text = "Tarif Filtreleme";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBoxSiralama;
        private System.Windows.Forms.Button buttonUygula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMalzemeSayisi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxKategori;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMaliyetBaslangic;
        private System.Windows.Forms.TextBox textBoxMaliyetBitis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxSonuclar;
    }
}
