namespace TarifRehberi
{
    partial class Form7
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewMalzemeler;
        private System.Windows.Forms.Button buttonSil;

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
            this.dataGridViewMalzemeler = new System.Windows.Forms.DataGridView();
            this.buttonSil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMalzemeler)).BeginInit();
            this.SuspendLayout();
            
            
            
            this.dataGridViewMalzemeler.AllowUserToAddRows = false;
            this.dataGridViewMalzemeler.AllowUserToDeleteRows = false;
            this.dataGridViewMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMalzemeler.Location = new System.Drawing.Point(16, 15);
            this.dataGridViewMalzemeler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewMalzemeler.Name = "dataGridViewMalzemeler";
            this.dataGridViewMalzemeler.ReadOnly = true;
            this.dataGridViewMalzemeler.RowHeadersWidth = 51;
            this.dataGridViewMalzemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMalzemeler.Size = new System.Drawing.Size(600, 308);
            this.dataGridViewMalzemeler.TabIndex = 0;
           
            
            
            this.buttonSil.Location = new System.Drawing.Point(16, 345);
            this.buttonSil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSil.Name = "buttonSil";
            this.buttonSil.Size = new System.Drawing.Size(133, 37);
            this.buttonSil.TabIndex = 1;
            this.buttonSil.Text = "Sil";
            this.buttonSil.UseVisualStyleBackColor = true;
            this.buttonSil.Click += new System.EventHandler(this.buttonSil_Click);
           
            
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 406);
            this.Controls.Add(this.dataGridViewMalzemeler);
            this.Controls.Add(this.buttonSil);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form7";
            this.Text = "Malzemeleri Yönet";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMalzemeler)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
