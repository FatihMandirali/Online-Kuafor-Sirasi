using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.KuaforSaatAraligi
{
    public class KuaforSaatAralik
    {
        Unit unitofwork = new Unit(new PlutoContext());
        public void Aralik(string saat, string saat1, Kuaforler berber, string artis, int id)
        {
          
            KuaforTrasSaatiAralik trasAralik;
            //   string saat = berber.AcilmaSaati;
            int ilkiki = Convert.ToInt32(saat.Substring(0, 2));
            int soniki = Convert.ToInt32(saat.Substring(3, 2));
            DateTime zaman = new DateTime(2019, 10, 10, ilkiki, soniki, 0);
            //string saat1 = berber.KapanmaSaati;
            int ilkiki1 = Convert.ToInt32(saat1.Substring(0, 2));
            int soniki1 = Convert.ToInt32(saat1.Substring(3, 2));
            DateTime zaman1 = new DateTime(2019, 10, 10, ilkiki1, soniki1, 0);

            while (true)
            {
               
                if (zaman > zaman1)
                { break; }
                trasAralik = new KuaforTrasSaatiAralik();
                trasAralik.BaslamaSaati = zaman.ToString("HH:mm");
                zaman = zaman.AddMinutes(Convert.ToInt32(artis));
                trasAralik.BitisSaati = zaman.ToString("HH:mm");
                trasAralik.Dolu = false;
                trasAralik.KuaforIdi = berber.Id;
                trasAralik.ElemanId = id;
                unitofwork.KuaforTrasSaatiAralik.Insert(trasAralik);
                unitofwork.Complete();
               

            }
          //  unitofwork.Dispose();

            
        }

        public void AralikSil(Kuaforler berber)
        {
            
            List<KuaforTrasSaatiAralik> trasAralik = unitofwork.KuaforTrasSaatiAralik.List(x => x.KuaforId.Id == berber.Id);
            for (int i = 0; i < trasAralik.Count(); i++)
            {
                unitofwork.KuaforTrasSaatiAralik.Delete(trasAralik[i]);
                unitofwork.Complete();
              //  unitofwork.Dispose();
            }
        }
    }
}