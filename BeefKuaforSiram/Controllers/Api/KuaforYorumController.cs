using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Core.Domain.Modeller.KuaforAdminModel;
using BeefKuaforSiram.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeefKuaforSiram.Controllers.Api
{
    public class KuaforYorumController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpGet]
        public IHttpActionResult GetKuaforYorumlar(int id)
        {
            List<KuaforYorum> kuaforlers = unitofwork.KuaforYorum.List(x => x.KuaforIdi == id);
            List<KuaforYorumResponse> kuaforYorumResponses = new List<KuaforYorumResponse>();
            for (int i = 0; i < kuaforlers.Count(); i++)
            {
                int kullaniId = kuaforlers[i].KullaniciIdi;
                Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Id ==kullaniId );
                string kullaniciAd = kullanici.Ad + " " + kullanici.Soyad;
                kuaforYorumResponses.Add(new KuaforYorumResponse()
                {
                    hizPuan = kuaforlers[i].HizPuan,
                    id= kuaforlers[i].Id,
                   kalitePuan= kuaforlers[i].KalitePuan,
                   kullaniciAdi= kullaniciAd,
                   ozenPuan= kuaforlers[i].OzenPuan,
                   yorum= kuaforlers[i].Yorum
                });


            }
            return Ok(kuaforYorumResponses);
        }

        [HttpGet]
        public IHttpActionResult GetKuaforYorumlarIncele(string id)
        {
            int yorumId = Convert.ToInt32(id);
            KuaforYorum kuaforYorum = unitofwork.KuaforYorum.Find(x => x.Id == yorumId);
            Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Id == kuaforYorum.KullaniciIdi);
            string kullaniciAd = kullanici.Ad + " " + kullanici.Soyad;
            KuaforYorumResponse kuaforYorumResponse = new KuaforYorumResponse();
            kuaforYorumResponse.hizPuan = kuaforYorum.HizPuan;
            kuaforYorumResponse.kalitePuan = kuaforYorum.KalitePuan;
            kuaforYorumResponse.kullaniciAdi = kullaniciAd;
            kuaforYorumResponse.ozenPuan = kuaforYorum.OzenPuan;
            kuaforYorumResponse.yorum = kuaforYorum.Yorum;
            return Ok(kuaforYorumResponse);
        }
            
    }
}
