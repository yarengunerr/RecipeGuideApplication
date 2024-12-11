using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarifRehberi
{
    public class YemekTarifleri
    {
        public int TarifId { get; set; }
        public string TarifAdi { get; set; }

        public int TarifSuresi { get; set; }
        public string Talimatlar { get; set; }

        public string Kategori { get; set; }

        public double ToplamMaliyet { get; set; }

        public List<Tuple<string, double>> Malzemeler { get; set; }



        public YemekTarifleri(string isim, int sure, string talimatlar, string kategori)
        {
            TarifAdi = isim;
            TarifSuresi = sure;
            Talimatlar = talimatlar;
            Kategori = kategori;
        }

        
        public YemekTarifleri()
        {
            Malzemeler = new List<Tuple<string, double>>(); 
        }

    }



}
