using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Core.Domain.Modeller;
using BeefKuaforSiram.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeefKuaforSiram.Controllers.Api
{
    public class KullaniciCuzdanController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpGet]
        public IHttpActionResult GetCuzdanKontrol(string id)
        {
            Kullanici kullanici = unitofwork.Kullanici.Find(x => x.KullaniciAdi == id);
            KullaniciCuzdan kullaniciCuzdan = unitofwork.KullaniciCuzdan.Find(x => x.KullaniciIdi == kullanici.Id);
            return Ok(kullaniciCuzdan);

        }


        //[HttpGet]
        //public IHttpActionResult GetCuzdanParaKazan(string id)
        //{
        //    Kullanici kullanici = unitofwork.Kullanici.Find(x => x.KullaniciAdi == id);
        //    List<Gorevler> gorevlers = unitofwork.Gorevler.List();
        //    List<KullaniciCuzdanParaKazan> kullaniciCuzdanParaKazans = new List<KullaniciCuzdanParaKazan>();
        //    List<GorevDurum> gorevDurums = unitofwork.GorevDurum.List(x=>x.KullanciciIdi==kullanici.Id);
        //    for (int i = 0; i < gorevlers.Count(); i++)
        //    {
        //        int gorevId = gorevlers[i].Id;
        //        GorevDurum gorevDurum = unitofwork.GorevDurum.Find(x => x.GorevlerIdi ==gorevId && x.KullanciciIdi==kullanici.Id);

        //        if (gorevDurum != null)
        //        {
        //        kullaniciCuzdanParaKazans.Add(new KullaniciCuzdanParaKazan()
        //        {
        //            toplamSayi = gorevlers[i].TamamlanmaAdet,
        //            gelinenSayi = gorevDurum.TamamlanmaSayisi,
        //            id = gorevlers[i].Id,
        //            gorevAdi = gorevlers[i].GorevAdi
                    
        //        });
        //        }
        //        else
        //        {
        //            kullaniciCuzdanParaKazans.Add(new KullaniciCuzdanParaKazan()
        //            {
        //                toplamSayi = gorevlers[i].TamamlanmaAdet,
        //                gelinenSayi =0,
        //                id = gorevlers[i].Id,
        //                gorevAdi = gorevlers[i].GorevAdi

        //            });
        //        }


        //    }


        //    return Ok(kullaniciCuzdanParaKazans);

        //}
        
    }
}
