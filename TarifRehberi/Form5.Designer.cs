namespace TarifRehberi
{
    partial class Form5
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.textBoxMalzemeAdı = new System.Windows.Forms.TextBox();
            this.textBoxToplamMiktar = new System.Windows.Forms.TextBox();
            this.comboBoxMalzemeBirimi = new System.Windows.Forms.ComboBox();
            this.textBoxBirimFiyat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonMalzemeleriGoster = new System.Windows.Forms.Button(); 
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            
            
            
            this.textBoxMalzemeAdı.Location = new System.Drawing.Point(45, 148);
            this.textBoxMalzemeAdı.Name = "textBoxMalzemeAdı";
            this.textBoxMalzemeAdı.Size = new System.Drawing.Size(188, 22);
            this.textBoxMalzemeAdı.TabIndex = 0;
            
           
            
            this.textBoxToplamMiktar.Location = new System.Drawing.Point(45, 243);
            this.textBoxToplamMiktar.Name = "textBoxToplamMiktar";
            this.textBoxToplamMiktar.Size = new System.Drawing.Size(188, 22);
            this.textBoxToplamMiktar.TabIndex = 1;
            
            
            
            this.comboBoxMalzemeBirimi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMalzemeBirimi.FormattingEnabled = true;
            this.comboBoxMalzemeBirimi.Items.AddRange(new object[] {
            "Gram",
            "Litre"});
            this.comboBoxMalzemeBirimi.Location = new System.Drawing.Point(45, 313);
            this.comboBoxMalzemeBirimi.Name = "comboBoxMalzemeBirimi";
            this.comboBoxMalzemeBirimi.Size = new System.Drawing.Size(188, 24);
            this.comboBoxMalzemeBirimi.TabIndex = 2;
            
           
            
            this.textBoxBirimFiyat.Location = new System.Drawing.Point(45, 392);
            this.textBoxBirimFiyat.Name = "textBoxBirimFiyat";
            this.textBoxBirimFiyat.Size = new System.Drawing.Size(188, 22);
            this.textBoxBirimFiyat.TabIndex = 3;
            
            
            
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(240, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 54);
            this.label1.TabIndex = 4;
            this.label1.Text = "MALZEME EKLE";
           
            
            
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Malzeme Adı";
            
            
            
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Toplam Miktar";
           
            
            
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Malzeme Birimi";
            
            
            
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Birim Fiyat";
            
            
            
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(365, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 208);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            
            
            
            this.button1.Location = new System.Drawing.Point(489, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 41);
            this.button1.TabIndex = 10;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            
            
            
            this.buttonMalzemeleriGoster.Location = new System.Drawing.Point(489, 420);
            this.buttonMalzemeleriGoster.Name = "buttonMalzemeleriGoster";
            this.buttonMalzemeleriGoster.Size = new System.Drawing.Size(150, 41);
            this.buttonMalzemeleriGoster.TabIndex = 11;
            this.buttonMalzemeleriGoster.Text = "Malzemeleri Göster";
            this.buttonMalzemeleriGoster.UseVisualStyleBackColor = true;
            
           
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.buttonMalzemeleriGoster);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBirimFiyat);
            this.Controls.Add(this.comboBoxMalzemeBirimi);
            this.Controls.Add(this.textBoxToplamMiktar);
            this.Controls.Add(this.textBoxMalzemeAdı);
            this.Name = "Form5";
            this.Text = "Giresun Yemekleri";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxMalzemeAdı;
        private System.Windows.Forms.TextBox textBoxToplamMiktar;
        private System.Windows.Forms.ComboBox comboBoxMalzemeBirimi;
        private System.Windows.Forms.TextBox textBoxBirimFiyat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonMalzemeleriGoster; 
    }
}
