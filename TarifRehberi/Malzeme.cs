using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarifRehberi
{
    public class Malzeme
    {
        public int MalzemeID { get; set; }
        public string MalzemeAdi { get; set; }

        public int ToplamMiktar { get; set; }

        public string MalzemeBirim { get; set; }

        public double BirimFiyat { get; set; }


    }
}