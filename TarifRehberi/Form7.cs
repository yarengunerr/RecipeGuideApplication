using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TarifRehberi
{
    //malzemelerin gösterilidği yer (malzeme ekle içinde)

    public partial class Form7 : Form
    {
        private Veritabanı_Servisi dbService;

        public Form7()
        {
            InitializeComponent();
            dbService = new Veritabanı_Servisi(); 
            MalzemeleriListele(); 
        }

        
        private void MalzemeleriListele()
        {
            List<Malzeme> malzemeler = dbService.MalzemeListele();
            dataGridViewMalzemeler.DataSource = malzemeler;
        }

        
        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewMalzemeler.SelectedRows.Count > 0)
            {
                int malzemeId = Convert.ToInt32(dataGridViewMalzemeler.SelectedRows[0].Cells["MalzemeID"].Value);

                
                dbService.MalzemeSil(malzemeId);

                MessageBox.Show("Malzeme başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                MalzemeleriListele();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz malzemeyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
