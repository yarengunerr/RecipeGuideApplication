using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TarifRehberi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            PerformDatabaseOperations();
        }

        private static void PerformDatabaseOperations()
        {
            
            string connectionString = "Server=GUNER\\SQLEXPRESS01;Database=YemekTarifleriDB;Integrated Security=True;";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Veritabanı bağlantısı başarılı!");

                    
                    CreateTablesIfNotExists(connection);

                    
                    string tarifAdi = PromptUserInput("Tarif Adı: ");
                    int hazirlamaSuresi = int.Parse(PromptUserInput("Hazırlama Süresi (dakika): "));
                    string talimatlar = PromptUserInput("Talimatlar: ");
                    string kategori = PromptUserInput("Kategori: "); 

                    
                    int tarifId = AddOrGetTarif(connection, tarifAdi, hazirlamaSuresi, talimatlar, kategori); 


                    
                    string malzemeAdi = PromptUserInput("Malzeme Adı: ");
                    string toplamMiktar = PromptUserInput("Toplam Miktar: ");
                    string malzemeBirim = PromptUserInput("Malzeme Birimi: ");
                    decimal birimFiyat = decimal.Parse(PromptUserInput("Birim Fiyat: "));

                    
                    int malzemeId = AddOrGetMalzeme(connection, malzemeAdi, toplamMiktar, malzemeBirim, birimFiyat);

                    
                    double malzemeMiktar = double.Parse(PromptUserInput("Malzeme Miktarı: "));
                    AddTarifMalzemeIliski(connection, tarifId, malzemeId, malzemeMiktar);

                    MessageBox.Show("İşlemler başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private static void CreateTablesIfNotExists(SqlConnection connection)
        {
           
            string createTariflerTableSql = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Tarifler' AND xtype='U')
                CREATE TABLE Tarifler (
                    TarifID INT PRIMARY KEY IDENTITY(1,1),
                    TarifAdi VARCHAR(100) NOT NULL,
                    HazirlamaSuresi INT NOT NULL,
                    Talimatlar TEXT NOT NULL,
                    Kategori VARCHAR(100) NOT NULL -- Kategori eklendi
                )";
            ExecuteNonQuery(connection, createTariflerTableSql);

            
            string createMalzemelerTableSql = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Malzemeler' AND xtype='U')
                CREATE TABLE Malzemeler (
                    MalzemeID INT PRIMARY KEY IDENTITY(1,1),
                    MalzemeAdi VARCHAR(100) NOT NULL,
                    ToplamMiktar VARCHAR(50),
                    MalzemeBirim VARCHAR(20),
                    BirimFiyat DECIMAL(10, 2)
                )";
            ExecuteNonQuery(connection, createMalzemelerTableSql);

            
            string createTarifMalzemeIliskiTableSql = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TarifMalzemeIliski' AND xtype='U')
                CREATE TABLE TarifMalzemeIliski (
                    TarifID INT NOT NULL,
                    MalzemeID INT NOT NULL,
                    MalzemeMiktar FLOAT NOT NULL,
                    FOREIGN KEY (TarifID) REFERENCES Tarifler(TarifID),
                    FOREIGN KEY (MalzemeID) REFERENCES Malzemeler(MalzemeID),
                    PRIMARY KEY (TarifID, MalzemeID)
                )";
            ExecuteNonQuery(connection, createTarifMalzemeIliskiTableSql);
        }

        
        private static int AddOrGetTarif(SqlConnection connection, string tarifAdi, int hazirlamaSuresi, string talimatlar, string kategori) 
        {
            string getTarifIdSql = "SELECT TarifID FROM Tarifler WHERE TarifAdi = @TarifAdi";
            using (SqlCommand getTarifCommand = new SqlCommand(getTarifIdSql, connection))
            {
                getTarifCommand.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                var result = getTarifCommand.ExecuteScalar();
                if (result != null)
                {
                    return (int)result; 
                }
            }

            string insertTarifSql = @"
                INSERT INTO Tarifler (TarifAdi, HazirlamaSuresi, Talimatlar, Kategori) 
                OUTPUT INSERTED.TarifID 
                VALUES (@TarifAdi, @HazirlamaSuresi, @Talimatlar, @Kategori)"; 
            using (SqlCommand insertTarifCommand = new SqlCommand(insertTarifSql, connection))
            {
                insertTarifCommand.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                insertTarifCommand.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);
                insertTarifCommand.Parameters.AddWithValue("@Talimatlar", talimatlar);
                insertTarifCommand.Parameters.AddWithValue("@Kategori", kategori); 
                return (int)insertTarifCommand.ExecuteScalar(); 
            }
        }

        
        private static int AddOrGetMalzeme(SqlConnection connection, string malzemeAdi, string toplamMiktar, string malzemeBirim, decimal birimFiyat)
        {
            string getMalzemeIdSql = "SELECT MalzemeID FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi";
            using (SqlCommand getMalzemeCommand = new SqlCommand(getMalzemeIdSql, connection))
            {
                getMalzemeCommand.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                var result = getMalzemeCommand.ExecuteScalar();
                if (result != null)
                {
                    return (int)result; 
                }
            }

            string insertMalzemeSql = @"
                INSERT INTO Malzemeler (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) 
                OUTPUT INSERTED.MalzemeID 
                VALUES (@MalzemeAdi, @ToplamMiktar, @MalzemeBirim, @BirimFiyat)";
            using (SqlCommand insertMalzemeCommand = new SqlCommand(insertMalzemeSql, connection))
            {
                insertMalzemeCommand.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                insertMalzemeCommand.Parameters.AddWithValue("@ToplamMiktar", toplamMiktar);
                insertMalzemeCommand.Parameters.AddWithValue("@MalzemeBirim", malzemeBirim);
                insertMalzemeCommand.Parameters.AddWithValue("@BirimFiyat", birimFiyat);
                return (int)insertMalzemeCommand.ExecuteScalar(); 
            }
        }

        
        private static void AddTarifMalzemeIliski(SqlConnection connection, int tarifId, int malzemeId, double malzemeMiktar)
        {
            string insertIliskiSql = @"
                IF NOT EXISTS (SELECT 1 FROM TarifMalzemeIliski WHERE TarifID = @TarifID AND MalzemeID = @MalzemeID)
                INSERT INTO TarifMalzemeIliski (TarifID, MalzemeID, MalzemeMiktar) 
                VALUES (@TarifID, @MalzemeID, @MalzemeMiktar)";
            using (SqlCommand insertIliskiCommand = new SqlCommand(insertIliskiSql, connection))
            {
                insertIliskiCommand.Parameters.AddWithValue("@TarifID", tarifId);
                insertIliskiCommand.Parameters.AddWithValue("@MalzemeID", malzemeId);
                insertIliskiCommand.Parameters.AddWithValue("@MalzemeMiktar", malzemeMiktar);
                insertIliskiCommand.ExecuteNonQuery();
            }
        }

        
        private static string PromptUserInput(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bu alan boş olamaz. Lütfen geçerli bir değer girin.");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        
        private static void ExecuteNonQuery(SqlConnection connection, string sql)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
