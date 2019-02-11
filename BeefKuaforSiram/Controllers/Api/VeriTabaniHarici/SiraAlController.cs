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

namespace BeefKuaforSiram.Controllers.Api.VeriTabaniHarici
{
    public class SiraAlController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpGet]
        public IHttpActionResult TrasCesitleri(string id)
        {
            Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Slug == id);
            List<KuaforTrasCesitleri> trascesitleri = unitofwork.KuaforTrasCesitleri.List(x => x.KuaforId.Id == kuaforler.Id);
            if (trascesitleri != null)
            {
                return Ok(trascesitleri);
            }
            else
            {
                return Ok("Geçersiz İşlem");
            }


        }

        [HttpPost]
        public IHttpActionResult SiraAralikLis(KuaforHizliSira kuaforHizliSira)
        {
            if (kuaforHizliSira == null)
            {
                return Ok();
            }
            if(kuaforHizliSira.tarih==null || kuaforHizliSira.personelId == null)
            {
                return Ok("Lütfen Eleman Seçtikten Sonra İşleminize Devam Edin");
            }
            else
            {
            KuaforElemanlari kuaforElemanlari = unitofwork.KuaforElemanlari.Find(x => x.Id == kuaforHizliSira.personelId);
            string adSoyad = kuaforElemanlari.Adi + " " + kuaforElemanlari.Soyadi;
            List<KuaforSira> KuaforSira = unitofwork.KuaforSira.List(x => x.KuaforElemanlariAdiSoyadi == adSoyad && x.Tarih == kuaforHizliSira.tarih);

            List<KuaforTrasSaatiAralik> kuaforTrasSaatiAraliks = unitofwork.KuaforTrasSaatiAralik.List(x => x.ElemanId == kuaforElemanlari.Id);

            List<KuaforHizliSiraResponse> kuaforHizliSiraResponseList = new List<KuaforHizliSiraResponse>();
            int i = 0;
            while (i < kuaforTrasSaatiAraliks.Count())
            {
                string saatAralik = kuaforTrasSaatiAraliks[i].BaslamaSaati + "-" + kuaforTrasSaatiAraliks[i].BitisSaati;
                KuaforSira kuaforSiras = unitofwork.KuaforSira.Find(x => x.KuaforElemanlariAdiSoyadi == adSoyad && x.Tarih == kuaforHizliSira.tarih && x.KuaforSaatAralik == saatAralik &&x.SiraDurum==true);

                if (kuaforSiras != null)
                {
                    kuaforHizliSiraResponseList.Add(new KuaforHizliSiraResponse
                    {
                        baslamaSaati = kuaforTrasSaatiAraliks[i].BaslamaSaati,
                        bitisSaati = kuaforTrasSaatiAraliks[i].BitisSaati,
                        Durum = false,
                        id = kuaforTrasSaatiAraliks[i].Id,
                    });
                }
                else
                {
                    kuaforHizliSiraResponseList.Add(new KuaforHizliSiraResponse
                    {
                        baslamaSaati = kuaforTrasSaatiAraliks[i].BaslamaSaati,
                        bitisSaati = kuaforTrasSaatiAraliks[i].BitisSaati,
                        Durum = true,
                        id = kuaforTrasSaatiAraliks[i].Id,
                    });
                }
                i++;
            }
           
            return Ok(kuaforHizliSiraResponseList);
            }
          
            


        }

        [HttpGet]
        public IHttpActionResult KuaforElemanlari(string id)
        {
            Kuaforler kuafor = unitofwork.Kuaforler.Find(x => x.Slug == id);
            List<KuaforElemanlari> elemanlar = unitofwork.KuaforElemanlari.List(x => x.KuaforIdi == kuafor.Id);
            if (elemanlar != null)
            {
                return Ok(elemanlar);
            }
            else
            {
                return Ok("Geçersiz İşlem");
            }


        }


        [HttpPost]
        public IHttpActionResult SiraniAl(KuaforSiraAlRequest kuaforSiraAlRequest)
        {
            if (kuaforSiraAlRequest.trasCesitleri == null)
            {
                return Ok("Lütfen Traş Çeşidinizi Seçin.");
            }
            else if (kuaforSiraAlRequest.kullaniciId == null)
            {
                return Ok("Lütfen Giriş Yapın. Sonra Sıranızı Seçin");
            }
            else if (kuaforSiraAlRequest.elemanId == null)
            {
                return Ok("Lütfen Traş Olacağınız Elemanı Seçin");
            }
            else if (kuaforSiraAlRequest.saatId == null)
            {
                return Ok("Lütfen Traş Olacağınız Saati Seçin");
            }
            else
            {
                Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Id == kuaforSiraAlRequest.kullaniciId);
                Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Slug == kuaforSiraAlRequest.kuaforSlug);
                KuaforElemanlari kuaforElemanlari = unitofwork.KuaforElemanlari.Find(x => x.Id == kuaforSiraAlRequest.elemanId);
                KuaforTrasSaatiAralik kuaforTrasSaatiAralik = unitofwork.KuaforTrasSaatiAralik.Find(x => x.Id == kuaforSiraAlRequest.saatId);
                KuaforSira kuaforSira = new KuaforSira();
                kuaforSira.KullaniciIdi = kullanici.Id;
                kuaforSira.KuaforIdi = kuaforler.Id;
                kuaforSira.KuaforSaatAralik = kuaforTrasSaatiAralik.BaslamaSaati + "-" + kuaforTrasSaatiAralik.BitisSaati;
                kuaforSira.Tarih = kuaforSiraAlRequest.tarih;
                kuaforSira.KuaforElemanlariAdiSoyadi = kuaforElemanlari.Adi + " " + kuaforElemanlari.Soyadi;
                kuaforSira.KuaforCesitAdi = kuaforSiraAlRequest.trasCesitleri;
                kuaforSira.SiraDurum = true;
                unitofwork.KuaforSira.Insert(kuaforSira);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok("Sıra Alma İşleminiz Başarılı");

            }

        }

        [HttpGet]
        public IHttpActionResult KullaniciAlinanSiralar(int id)
        {
            Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Id == id);
            List<KuaforSira> kuaforSiras = unitofwork.KuaforSira.List(x => x.KullaniciIdi == kullanici.Id);
            if (kullanici != null)
            {
                List<KullaniciAlinanSiralar> kullaniciAlinanSiralars = new List<KullaniciAlinanSiralar>();
                int i = 0;
                while (i < kuaforSiras.Count())
                {
                    int kuaforId = kuaforSiras[i].KuaforIdi;
                    string kuaforler = unitofwork.Kuaforler.Find(x => x.Id == kuaforId).Ad;
                    kullaniciAlinanSiralars.Add(new KullaniciAlinanSiralar
                    {
                        kuafor = kuaforler,
                        kuaforElemani = kuaforSiras[i].KuaforElemanlariAdiSoyadi,
                        saatAraligi = kuaforSiras[i].KuaforSaatAralik,
                        tarih = kuaforSiras[i].Tarih,
                        trasCesidi = kuaforSiras[i].KuaforCesitAdi,
                        siradurum = kuaforSiras[i].SiraDurum,
                        tamamlanmadurum= kuaforSiras[i].TamamlanmaDurum,
                        id = kuaforSiras[i].Id
                    });
                    i++;
                }
                return Ok(kullaniciAlinanSiralars);
            }
            else
            {
                return Ok("Geçersiz İşlem");
            }


        }

        [HttpPost]
        public IHttpActionResult KullaniciSiraSil(int id)
        {
            KuaforSira kuaforSira = unitofwork.KuaforSira.Find(x => x.Id == id);
            unitofwork.KuaforSira.Delete(kuaforSira);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Ok("Sıranız Başarıyla Silindi.");
        }


        [HttpGet]
        public IHttpActionResult GetKuaforAdminGelecekSira(int id)
        {
            List<KuaforSira> kuaforSiras = unitofwork.KuaforSira.List(x => x.KuaforIdi == id && x.SiraDurum == true);
            List<KuaforSiralarResponse> kuaforSiralarResponses = new List<KuaforSiralarResponse>();
            int i = 0;
            while (i < kuaforSiras.Count())
            {
                int kuaforId = kuaforSiras[i].KullaniciIdi;
                string kullanici = unitofwork.Kullanici.Find(x => x.Id == kuaforId).Ad + " " + unitofwork.Kullanici.Find(x => x.Id == kuaforId).Soyad;
                kuaforSiralarResponses.Add(new KuaforSiralarResponse
                {
                    eleman = kuaforSiras[i].KuaforElemanlariAdiSoyadi,
                    saatAralik = kuaforSiras[i].KuaforSaatAralik,
                    kullanici = kullanici,
                    tarih = kuaforSiras[i].Tarih,
                    trasCesidi = kuaforSiras[i].KuaforCesitAdi,
                    id = kuaforSiras[i].Id
                });
                i++;
            }
            return Ok(kuaforSiralarResponses);
        }
        
        [HttpGet]
        public IHttpActionResult GetKuaforAdminGecmisSira(int id)
        {
            List<KuaforSira> kuaforSiras = unitofwork.KuaforSira.List(x => x.KuaforIdi == id && x.SiraDurum == false);
            List<KuaforSiralarResponse> kuaforSiralarResponses = new List<KuaforSiralarResponse>();
            int i = 0;
            while (i < kuaforSiras.Count())
            {
                int kuaforId = kuaforSiras[i].KullaniciIdi;
                string kullanici = unitofwork.Kullanici.Find(x => x.Id == kuaforId).Ad + " " + unitofwork.Kullanici.Find(x => x.Id == kuaforId).Soyad;
                kuaforSiralarResponses.Add(new KuaforSiralarResponse
                {
                    eleman = kuaforSiras[i].KuaforElemanlariAdiSoyadi,
                    saatAralik = kuaforSiras[i].KuaforSaatAralik,
                    kullanici = kullanici,
                    tarih = kuaforSiras[i].Tarih,
                    trasCesidi = kuaforSiras[i].KuaforCesitAdi,
                    id = kuaforSiras[i].Id
                });
                i++;
            }
            return Ok(kuaforSiralarResponses);
        }

        [HttpGet]
        public IHttpActionResult GetKuaforAdminGelecekSiraIncele(int id)
        {
            KuaforSira kuaforSiras = unitofwork.KuaforSira.Find(x => x.Id == id);
            int kuaforId = kuaforSiras.KullaniciIdi;
            string kullanici = unitofwork.Kullanici.Find(x => x.Id == kuaforId).Ad + " " + unitofwork.Kullanici.Find(x => x.Id == kuaforId).Soyad;

            KuaforSiralarResponse kuaforSiralarResponses = new KuaforSiralarResponse();

            kuaforSiralarResponses.kullanici = kullanici;
            kuaforSiralarResponses.saatAralik = kuaforSiras.KuaforSaatAralik;
            kuaforSiralarResponses.tarih = kuaforSiras.Tarih;
            kuaforSiralarResponses.trasCesidi = kuaforSiras.KuaforCesitAdi;
            kuaforSiralarResponses.eleman = kuaforSiras.KuaforElemanlariAdiSoyadi;
            return Ok(kuaforSiralarResponses);
        }

        [HttpGet]
        public IHttpActionResult GetKuaforAdminGecmisSiraIncele(int id)
        {
            KuaforSira kuaforSiras = unitofwork.KuaforSira.Find(x => x.Id == id);
            int kuaforId = kuaforSiras.KullaniciIdi;
            string kullanici = unitofwork.Kullanici.Find(x => x.Id == kuaforId).Ad + " " + unitofwork.Kullanici.Find(x => x.Id == kuaforId).Soyad;

            KuaforSiralarResponse kuaforSiralarResponses = new KuaforSiralarResponse();

            kuaforSiralarResponses.kullanici = kullanici;
            kuaforSiralarResponses.saatAralik = kuaforSiras.KuaforSaatAralik;
            kuaforSiralarResponses.tarih = kuaforSiras.Tarih;
            kuaforSiralarResponses.trasCesidi = kuaforSiras.KuaforCesitAdi;
            kuaforSiralarResponses.eleman = kuaforSiras.KuaforElemanlariAdiSoyadi;
            return Ok(kuaforSiralarResponses);
        }
        
         [HttpPost]
        public IHttpActionResult GetKuaforAdminGelecekSiraTamamla(int id)
        {
            KuaforSira kuaforSiras = unitofwork.KuaforSira.Find(x => x.Id == id);
            kuaforSiras.SiraDurum = false;
            unitofwork.KuaforSira.Update(kuaforSiras);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Ok("Sıra Başarıyla Tamamlandı");
        }

        [HttpPost]
        public IHttpActionResult GetKuaforAdminGecmisSiraSil(int id)
        {
            KuaforSira kuaforSiras = unitofwork.KuaforSira.Find(x => x.Id == id);
            unitofwork.KuaforSira.Delete(kuaforSiras);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Ok("Sıra Başarıyla Silindi");
        }


        [HttpGet]
        public IHttpActionResult GetHizliSiraEleman(int id)
        {
            List<KuaforElemanlari> elemanlar = unitofwork.KuaforElemanlari.List(x => x.KuaforIdi == id);
            if (elemanlar != null)
            {
                return Ok(elemanlar);
            }
            else
            {
                return Ok("Kuaforun Elemanı Bulunmamaktadır.");
            }
        }

        [HttpGet]
        public IHttpActionResult GetHizliSiraSaat(int id)
        {
            KuaforElemanlari kuaforElemanlari = unitofwork.KuaforElemanlari.Find(x => x.KuaforIdi == id);
            //  KuaforTrasSaatiAralik saataralik = unitofwork.KuaforTrasSaatiAralik.Find(x => x.ElemanId == id);
            IEnumerable<KuaforTrasSaatiAralik> kuaforTrasSaatiAraliks = unitofwork.KuaforTrasSaatiAralik.List().Where(x => x.ElemanId == id);
            if (kuaforTrasSaatiAraliks != null)
            {
                return Ok(kuaforTrasSaatiAraliks);
            }
            else
            {
                return Ok("Geçersiz İşlem");
            }
        }

        [HttpPost]
        public IHttpActionResult HizliSiraniAl(KuaforHizliSiraRequest kuaforHizliSiraRequest)
        {
            List<int> saatler = kuaforHizliSiraRequest.saatAraligi;
            KuaforSira kuaforSira;
            KuaforElemanlari kuaforElemanlari = unitofwork.KuaforElemanlari.Find(x => x.Id == kuaforHizliSiraRequest.eleman);
            int i = 0;
            while (i < saatler.Count())
            {
                int saatId = saatler[i];
                KuaforTrasSaatiAralik kuaforSaatAraligi = unitofwork.KuaforTrasSaatiAralik.Find(x => x.Id == saatId);
                kuaforSira = new KuaforSira();
                kuaforSira.KuaforCesitAdi = "admin";
                kuaforSira.KuaforElemanlariAdiSoyadi = kuaforElemanlari.Adi + " " + kuaforElemanlari.Soyadi;
                kuaforSira.KuaforIdi = kuaforElemanlari.KuaforIdi;
                kuaforSira.KuaforSaatAralik = kuaforSaatAraligi.BaslamaSaati + "-" + kuaforSaatAraligi.BitisSaati;
                kuaforSira.KullaniciIdi = 1;//system olacak
                kuaforSira.SiraDurum = true;
                kuaforSira.Tarih = kuaforHizliSiraRequest.tarih;
                unitofwork.KuaforSira.Insert(kuaforSira);
                unitofwork.Complete();
                i++;
            }

            return Ok();
        }



    }
}
