using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TarifRehberi
{
    public class Veritabanı_Servisi
    {

        private string connectionString = "Server=GUNER\\SQLEXPRESS01;Database=YemekTarifleriDB;Integrated Security=True;";



        public bool TarifEkle(YemekTarifleri tarif)
        {

            if (TarifVarMi(tarif.TarifAdi))
            {

                MessageBox.Show("Bu tarif zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Tarifler (TarifAdi, HazirlamaSuresi, Talimatlar, Kategori) " +
                               "VALUES (@tarifAdi, @hazirlamaSuresi, @talimatlar, @kategori); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tarifAdi", tarif.TarifAdi);
                    command.Parameters.AddWithValue("@hazirlamaSuresi", tarif.TarifSuresi);
                    command.Parameters.AddWithValue("@talimatlar", tarif.Talimatlar);
                    command.Parameters.AddWithValue("@kategori", tarif.Kategori);

                    int yeniTarifId = Convert.ToInt32(command.ExecuteScalar());
                    tarif.TarifId = yeniTarifId;
                    return true;
                }
            }
        }




        public List<YemekTarifleri> TarifleriGetir()
        {
            List<YemekTarifleri> tarifler = new List<YemekTarifleri>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectTarifSql = "SELECT * FROM Tarifler";

                using (SqlCommand command = new SqlCommand(selectTarifSql, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        YemekTarifleri tarif = new YemekTarifleri
                        {
                            TarifId = int.TryParse(reader["TarifID"].ToString(), out int tarifId) ? tarifId : 0,
                            TarifAdi = reader["TarifAdi"].ToString(),
                            TarifSuresi = int.TryParse(reader["HazirlamaSuresi"].ToString(), out int hazirlamaSuresi) ? hazirlamaSuresi : 0,
                            Talimatlar = reader["Talimatlar"].ToString(),
                            Kategori = reader["Kategori"].ToString()
                        };

                        tarifler.Add(tarif);
                    }
                }
            }

            return tarifler;
        }


        public void TarifGuncelle(YemekTarifleri tarif)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateTarifSql = @"
                UPDATE Tarifler 
                SET TarifAdi = @TarifAdi, Kategori = @Kategori, HazirlamaSuresi = @HazirlamaSuresi, Talimatlar = @Talimatlar 
                WHERE TarifID = @TarifID";

                using (SqlCommand command = new SqlCommand(updateTarifSql, connection))
                {
                    command.Parameters.AddWithValue("@TarifID", tarif.TarifId);
                    command.Parameters.AddWithValue("@TarifAdi", tarif.TarifAdi);
                    command.Parameters.AddWithValue("@Kategori", tarif.Kategori);
                    command.Parameters.AddWithValue("@HazirlamaSuresi", tarif.TarifSuresi);
                    command.Parameters.AddWithValue("@Talimatlar", tarif.Talimatlar);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void TarifSil(int tarifId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string deleteTarifSql = "DELETE FROM Tarifler WHERE TarifID = @TarifID";

                using (SqlCommand command = new SqlCommand(deleteTarifSql, connection))
                {
                    command.Parameters.AddWithValue("@TarifID", tarifId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void MalzemeKaydet(string malzemeAdı, int toplamMiktar, string malzemeBirimi, decimal birimFiyat)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Malzemeler (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) VALUES (@malzemeAdi, @toplamMiktar, @malzemeBirim, @birimFiyat)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@malzemeAdi", malzemeAdı);
                    command.Parameters.AddWithValue("@toplamMiktar", toplamMiktar);
                    command.Parameters.AddWithValue("@malzemeBirim", malzemeBirimi);
                    command.Parameters.AddWithValue("@birimFiyat", birimFiyat);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<Malzeme> MalzemeListele()
        {
            List<Malzeme> malzemeListesi = new List<Malzeme>();
            string query = "SELECT MalzemeID, MalzemeAdi FROM Malzemeler";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    malzemeListesi.Add(new Malzeme
                    {
                        MalzemeID = reader.GetInt32(0),
                        MalzemeAdi = reader.GetString(1)
                    });
                }
            }
            return malzemeListesi;
        }


        public int MalzemeIdBul(string malzemeAdi)
        {
            string query = "SELECT MalzemeID FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public bool MalzemeMiktarKontrol(int malzemeId, double miktar)
        {
            string query = "SELECT ToplamMiktar FROM Malzemeler WHERE MalzemeID = @MalzemeID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MalzemeID", malzemeId);
                connection.Open();
                var toplamMiktar = (string)command.ExecuteScalar();
                return double.TryParse(toplamMiktar, out double toplam) && toplam >= miktar;
            }
        }

        public void TarifMalzemeIliskiEkle(int tarifId, int malzemeId, double malzemeMiktar)
        {
            string query = "INSERT INTO TarifMalzemeIliski (TarifID, MalzemeID, MalzemeMiktar) VALUES (@TarifID, @MalzemeID, @MalzemeMiktar)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifId);
                command.Parameters.AddWithValue("@MalzemeID", malzemeId);
                command.Parameters.AddWithValue("@MalzemeMiktar", malzemeMiktar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Tuple<string, double>> TarifMalzemeleriGetir(int tarifId)
        {
            List<Tuple<string, double>> malzemeListesi = new List<Tuple<string, double>>();

            string query = @"
        SELECT m.MalzemeAdi, tmi.MalzemeMiktar
        FROM TarifMalzemeIliski tmi
        INNER JOIN Malzemeler m ON tmi.MalzemeID = m.MalzemeID
        WHERE tmi.TarifID = @TarifID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string malzemeAdi = reader["MalzemeAdi"].ToString();
                    double malzemeMiktar = double.TryParse(reader["MalzemeMiktar"].ToString(), out double miktar) ? miktar : 0;
                    malzemeListesi.Add(new Tuple<string, double>(malzemeAdi, malzemeMiktar));
                }
            }

            return malzemeListesi;
        }

        public void TarifMalzemeGuncelle(int tarifId, int malzemeId, double yeniMiktar)
        {
            string query = @"
        UPDATE TarifMalzemeIliski
        SET MalzemeMiktar = @YeniMiktar
        WHERE TarifID = @TarifID AND MalzemeID = @MalzemeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifId);
                command.Parameters.AddWithValue("@MalzemeID", malzemeId);
                command.Parameters.AddWithValue("@YeniMiktar", yeniMiktar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void TarifMalzemeSil(int tarifId, int malzemeId)
        {
            string query = "DELETE FROM TarifMalzemeIliski WHERE TarifID = @TarifID AND MalzemeID = @MalzemeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifId);
                command.Parameters.AddWithValue("@MalzemeID", malzemeId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void MalzemeAdiGuncelle(int malzemeId, string yeniMalzemeAdi)
        {
            string query = "UPDATE Malzemeler SET MalzemeAdi = @YeniMalzemeAdi WHERE MalzemeID = @MalzemeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@YeniMalzemeAdi", yeniMalzemeAdi);
                command.Parameters.AddWithValue("@MalzemeID", malzemeId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool TarifVarMi(string tarifAdi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Tarifler WHERE TarifAdi = @tarifAdi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tarifAdi", tarifAdi);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public double MalzemeBirimFiyatiBul(string malzemeAdi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT BirimFiyat FROM Malzemeler WHERE MalzemeAdi = @malzemeAdi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToDouble(result) : 0;
                }
            }
        }

        public double MaliyetHesapla(int tarifId)
        {
            double toplamMaliyet = 0;


            List<Tuple<string, double>> malzemeler = TarifMalzemeleriGetir(tarifId);

            foreach (var malzeme in malzemeler)
            {
                string malzemeAdi = malzeme.Item1;
                double miktar = malzeme.Item2;


                double birimFiyat = MalzemeBirimFiyatiBul(malzemeAdi);


                toplamMaliyet += birimFiyat * miktar;
            }

            return toplamMaliyet;
        }

        public decimal TarifMaliyetiGetir(int tarifId)
        {

            return (decimal)MaliyetHesapla(tarifId);
        }

        public void MalzemeSil(int malzemeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Malzemeler WHERE MalzemeID = @MalzemeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MalzemeID", malzemeId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
