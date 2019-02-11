using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Core.Domain.Modeller;
using BeefKuaforSiram.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeefKuaforSiram.Controllers.Api.VeriTabaniHarici
{
    public class KuaforDetayYorumlarController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());
        Kuaforler kuafor = new Kuaforler();
        Kullanici kullanici = new Kullanici();
        List<KuaforYorum> kuaforyorum = new List<KuaforYorum>();
        List<KuaforDetayYorum> kyorum = new List<KuaforDetayYorum>();
        string ad;
        [HttpGet]
        public IHttpActionResult DetayYorumlar(string id)
        {
            kuafor = unitofwork.Kuaforler.Find(x => x.Slug == id);
            kuaforyorum = unitofwork.KuaforYorum.List(x => x.KuaforId.Slug == id);
            for (int i = 0; i < kuaforyorum.Count(); i++)
            {
                int kullaniciid = kuaforyorum[i].KullaniciIdi;
                Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Id == kullaniciid);
                ad = kullanici.Ad+" "+kullanici.Soyad;
                kyorum.Add(new KuaforDetayYorum() { KuaforAdi = kuaforyorum[i].KuaforId.Ad, KullaniciAdi = IsimKisalt(ad), Yorum = kuaforyorum[i].Yorum, HizPuan = kuaforyorum[i].HizPuan, KalitePuan = kuaforyorum[i].KalitePuan, OzenPuan = kuaforyorum[i].OzenPuan });
            }

            return Ok(kyorum);

        }


        [HttpGet]
        public IHttpActionResult GetKullaniciYorumKuaforId(string id)
        {
            Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Ad == id);
            return Ok(kuaforler.Ad);
        }
        
        [HttpPost]
        public IHttpActionResult GetKullaniciYorum(KullaniciYorumRequest kullaniciYorumRequest)
        {
            Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Slug == kullaniciYorumRequest.kullaniciSlug);
            int kuaforSiraId = Convert.ToInt32(kullaniciYorumRequest.kuaforAdi.ToString());
            KuaforSira kuaforSira = unitofwork.KuaforSira.Find(x => x.Id == kuaforSiraId);
            KuaforYorum kuaforYorum = new KuaforYorum();
            kuaforYorum.HizPuan = kullaniciYorumRequest.hizPuan;
            kuaforYorum.KalitePuan = kullaniciYorumRequest.kalitePuan;
            kuaforYorum.KuaforIdi = kuaforSira.KuaforIdi;
            kuaforYorum.KullaniciIdi = kullanici.Id;
            kuaforYorum.OzenPuan = kullaniciYorumRequest.ozenPuan;
            kuaforYorum.Yorum = kullaniciYorumRequest.yorum;
            unitofwork.KuaforYorum.Insert(kuaforYorum);
            unitofwork.Complete();

            kuaforSira.TamamlanmaDurum = true;
            unitofwork.KuaforSira.Update(kuaforSira);
            unitofwork.Complete();

            unitofwork.Dispose();
            return Ok("Başarılı bir şekilde yorum yaptınız");

        }

        public string IsimKisalt(string yazi)
        {
            int uz = yazi.Length;
            string ilk = yazi.Substring(0, 1);
            string son = yazi.Substring(uz - 1, 1);
            string sonuc = ilk + "... ..." + son;
            return sonuc;
        }

    }
}
