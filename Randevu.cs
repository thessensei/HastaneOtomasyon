using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    internal class Randevu
    {
        string isim, soyisim, hastalık;
        int tcno,telno;
        public Randevu(string hastaisim, string hastasoyisim, string hastahastalık, int hastatcno, int hastatelno)
        {
            isim = hastaisim;
            Soyisim = soyisim;
            Hastalık = hastalık;
            Tcno = tcno;
            Telno = telno;
           
        }
        public Randevu()
        {

        }

        public string Isim { get => isim; set => isim = value; }
        public string Soyisim { get => soyisim; set => soyisim = value; }
        public string Hastalık { get => hastalık; set => hastalık = value; }
        public int Tcno { get => tcno;
            set
            {
                if (value.ToString().Length == 5)
                {
                    tcno = value;
                }
                else
                {
                    throw new Exception("TC No 11 haneli ve sadece rakamlardan oluşmalı!");
                }
            } 
        }
        public int Telno
        {
            get => telno;
            set
            {
                if (value.ToString().Length == 5)
                {
                    telno = value;
                }
                else
                {
                    throw new Exception("Tel No 10 haneli ve sadece rakamlardan oluşmalı!");
                }
            }
        }
    }
}
