using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace HastaneOtomasyon
{
    internal class Hastane
    {
        public List<Randevu> randevular = new List<Randevu>();


        public bool RandevuEkle(Randevu randevu)
        {
            try
            {
                randevular.Add(randevu);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public Randevu RandevuAra(int tcno)
        {
            foreach(Randevu randevu in randevular)
            {
                if (randevu.Tcno == tcno)
                {
                    return randevu;
                }
            }
            return null;
        }
        public bool RandevuSil(Randevu randevu)
        {
            try 
            {
                randevular.Remove(randevu);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RandevuGuncelle(Randevu guncellenecekRandevu)
        {
            try
            {
                for (int i = 0; i < randevular.Count; i++)
                {
                    if (randevular[i].Tcno == guncellenecekRandevu.Tcno)
                    {
                        randevular[i] = guncellenecekRandevu;
                        return true;
                    }
                }
                return false; 
            }
            catch
            {
                return false; 
            }
        }
    }
}
