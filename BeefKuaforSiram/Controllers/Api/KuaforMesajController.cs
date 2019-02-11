using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Core.Domain.Modeller;
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
    public class KuaforMesajController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpPost]
        public IHttpActionResult PostMesajGonder(KullaniciMesajGonderRequest kullaniciMesajGonderRequest)
        {
            if (kullaniciMesajGonderRequest.mesaj == null)
            {
                return Ok("Lütfen Mesajınızı Boş Girmeyin.");
            }
            else
            {
                Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Slug == kullaniciMesajGonderRequest.kuaforSlug);
                Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Slug == kullaniciMesajGonderRequest.kullaniciSlug);
                //   KuaforMesaj kuaforMesaj1 = unitofwork.KuaforMesaj.Find(x => x.KullaniciIdi == kullanici.Id);
                KuaforMesaj kuaforMesaj = new KuaforMesaj();
                kuaforMesaj.KullaniciIdi = kullanici.Id;
                kuaforMesaj.Mesaj = kullaniciMesajGonderRequest.mesaj;
                kuaforMesaj.KuaforIdi = kuaforler.Id;
                unitofwork.KuaforMesaj.Insert(kuaforMesaj);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok("Mesajınız Başarıyla Gönderildi");
            }

        }

        [HttpGet]
        public IHttpActionResult GETMesajKutusuKullanicilar(int id)
        {
            
            Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Id == id);
            List<int> kuaforMesajlar = unitofwork.KuaforMesaj.List(x => x.KuaforIdi == kuaforler.Id).Select(x=>x.KullaniciIdi).Distinct().ToList();
            List<MessageUsersListResponse> messageUsersListResponse = new List<MessageUsersListResponse>();

            for (int i = 0; i < kuaforMesajlar.Count(); i++)
            {
                int idi = kuaforMesajlar[i];
                List<KuaforMesaj> kuaforMesaj = unitofwork.KuaforMesaj.List(x => x.KullaniciIdi == idi);
             //   int ids = kuaforMesaj[0].Id;
                int kIds = kuaforMesaj[0].KullaniciIdi;
                Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Id == kIds);
                string ads = kullanici.Ad + " " + kullanici.Soyad;
                messageUsersListResponse.Add(new MessageUsersListResponse { id = i + 1, kullaniciAdSoyad = ads, dbId = kullanici.Id });
            }
            return Ok(messageUsersListResponse);
        }


        [HttpGet]
        public IHttpActionResult GETKullaniciMesajKuforler(string id)
        {

            Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Slug == id);
            List<int> kullaniciKuaforLis = unitofwork.KuaforMesaj.List(x => x.KullaniciIdi == kullanici.Id).Select(x => x.KuaforIdi).Distinct().ToList();
            List<MessageUsersListResponse> messageUsersListResponse = new List<MessageUsersListResponse>();

            for (int i = 0; i < kullaniciKuaforLis.Count(); i++)
            {
                int idi = kullaniciKuaforLis[i];
                List<KuaforMesaj> kuaforMesaj = unitofwork.KuaforMesaj.List(x => x.KuaforIdi == idi);
              
                int kIds = kuaforMesaj[0].KuaforIdi;
                Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Id == kIds);
                string ads = kuaforler.Ad;
                int ids = kuaforMesaj[0].KuaforIdi;
                messageUsersListResponse.Add(new MessageUsersListResponse { id = i + 1, kullaniciAdSoyad = ads, dbId = ids});
            }
            return Ok(messageUsersListResponse);
        }

        [HttpPost]
        public IHttpActionResult Mesajlar(MessagesRequest messagesRequest)
        {
           List<KuaforMesaj> kuaforMesajs = unitofwork.KuaforMesaj.List(x => x.KullaniciIdi == messagesRequest.kullaniciId && x.KuaforIdi == messagesRequest.kuaforId).ToList();
            return Ok(kuaforMesajs);
        }

        [HttpPost]
        public IHttpActionResult KullaniciMesajlar(KullaniciMessagesRequest messagesRequest)
        {
            Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Slug == messagesRequest.kullaniciSlug);
            List<KuaforMesaj> kuaforMesajs = unitofwork.KuaforMesaj.List(x => x.KullaniciIdi == kullanici.Id && x.KuaforIdi == messagesRequest.kuaforId).ToList();
            return Ok(kuaforMesajs);
        }
        

       [HttpPost]
        public IHttpActionResult PostYoneticiMessage(ManagerMessageRequest managerMessageRequest)
        {
            KuaforMesaj kuaforMesaj = new KuaforMesaj();
            kuaforMesaj.KuaforIdi = managerMessageRequest.kuaforId;
            kuaforMesaj.KullaniciIdi = managerMessageRequest.kullaniciId;
            kuaforMesaj.Mesaj = managerMessageRequest.mesaj;
            kuaforMesaj.YoneticiDurum = true;
            kuaforMesaj.KullaniciDurum = true;
            kuaforMesaj.Yonetici = true;
            kuaforMesaj.Kullanici = false;
            unitofwork.KuaforMesaj.Insert(kuaforMesaj);
            unitofwork.Complete();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult PostKullaniciMessage(KullaniciMessageRequest kullaniciMessageRequest)
        {
            Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Slug == kullaniciMessageRequest.kullaniciSlug);
            KuaforMesaj kuaforMesaj = new KuaforMesaj();
            kuaforMesaj.KuaforIdi = kullaniciMessageRequest.kuaforId;
            kuaforMesaj.KullaniciIdi = kullanici.Id;
            kuaforMesaj.Mesaj = kullaniciMessageRequest.mesaj;
            kuaforMesaj.YoneticiDurum = true;
            kuaforMesaj.KullaniciDurum = true;
            kuaforMesaj.Yonetici = false;
            kuaforMesaj.Kullanici = true;
            unitofwork.KuaforMesaj.Insert(kuaforMesaj);
            unitofwork.Complete();
            return Ok();
        }




    }
}
