using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Core.Domain.Modeller;
using BeefKuaforSiram.Core.Domain.Modeller.KuaforAdminModel;
using BeefKuaforSiram.Core.Domain.Modeller.YoneticiAdminModel;
using BeefKuaforSiram.KuaforSaatAraligi;
using BeefKuaforSiram.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeefKuaforSiram.Controllers.Api
{
    public class KuaforlerController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());



        [HttpGet]
        public IHttpActionResult KuaforSecimiList(int id)
        {
            List<Kuaforler> kuaforlers = unitofwork.Kuaforler.List(x => x.KuaforSahipIdi == id);
            List<KuaforSecimResponse> kuaforSecimResponses = new List<KuaforSecimResponse>();
            for (int i = 0; i < kuaforlers.Count(); i++)
            {

                kuaforSecimResponses.Add(new KuaforSecimResponse()
                { kuaforAdi = kuaforlers[i].Ad, kuaforAdres = kuaforlers[i].Adres, id = kuaforlers[i].Id });


            }
            return Ok(kuaforSecimResponses);
        }
        [HttpGet]
        public IHttpActionResult Tumu(string id)
        {
            List<Iller> iller = new List<Iller>();
            List<Kuaforler> users = unitofwork.Kuaforler.List(x => x.Sehir == id);

            for (int i = 0; i < users.Count(); i++)
            {
                int kuaforIdd = users[i].Id;
                List<KuaforYorum> kuaforYorum = unitofwork.KuaforYorum.List(x => x.KuaforIdi == kuaforIdd);
                if (kuaforYorum.Count() == 0)
                {
                    int ortalma = 3;
                    KuaforAktiflik kuaforAktiflik = unitofwork.KuaforAktiflik.Find(x => x.KuaforIdi == kuaforIdd);
                    if (kuaforAktiflik.Aktiflik == true)
                    {
                        iller.Add(new Iller() { Ad = users[i].Ad, Adres = users[i].Adres, Puan = ortalma, Slug = users[i].Slug, Sehir = users[i].Sehir });

                    }
                }
                else
                { double ort = unitofwork.KuaforYorum.List(x => x.KuaforIdi == kuaforIdd).Average(x => x.KalitePuan);
                    int ortalma = Convert.ToInt32(ort);
                    KuaforAktiflik kuaforAktiflik = unitofwork.KuaforAktiflik.Find(x => x.KuaforIdi == kuaforIdd);
                    if (kuaforAktiflik.Aktiflik == true)
                    {
                        iller.Add(new Iller() { Ad = users[i].Ad, Adres = users[i].Adres, Puan = ortalma, Slug = users[i].Slug, Sehir = users[i].Sehir });

                    }
                }



            }
            return Ok(iller);

        }

        [HttpGet]
        public IHttpActionResult YoneticiKuaforler()
        {

            List<Kuaforler> kuaforlers = unitofwork.Kuaforler.List();

            List<KuaforlerListResponse> kuaforlerListResponse = new List<KuaforlerListResponse>();

            for (int i = 0; i < kuaforlers.Count(); i++)
            {
                int ii = Convert.ToInt32(kuaforlers[i].KuaforSahipIdi);
                KuaforSahip Sahip = unitofwork.KuaforSahip.Find(x => x.Id == ii);
                kuaforlerListResponse.Add(new KuaforlerListResponse
                {
                    sahip = Sahip.Ad + " " + Sahip.Soyad,
                    acilmaSaati = kuaforlers[i].AcilmaSaati,
                    adres = kuaforlers[i].Adres,
                    cinsiyet = kuaforlers[i].BayBayan,
                    eklenmeTarihi = kuaforlers[i].EklenmeTarihi,
                    kapanmaSaati = kuaforlers[i].KapanmaSaati,
                    kuaforAdi = kuaforlers[i].Ad,
                    mail = kuaforlers[i].EMail,
                    puan = kuaforlers[i].Puan,
                    sehir = kuaforlers[i].Sehir,
                    semt = kuaforlers[i].Semt,
                    telefon = kuaforlers[i].Telefon,
                    id = kuaforlers[i].Id,
                });

            }

            return Ok(kuaforlerListResponse);

        }


        [HttpGet]
        public IHttpActionResult OzellestirilmisIlce(string id)
        {
            int uz = id.Length;
            string ilce = id.Substring(0, uz - 1);
            string baybayan = id.Substring(uz - 1, 1);
            int bayybayan = Convert.ToInt32(baybayan);
            IEnumerable<Kuaforler> users = unitofwork.Kuaforler.List().Where(x => x.Semt == ilce && x.BayBayan == bayybayan);
            return Ok(users);

        }

        [HttpGet]
        public IHttpActionResult DetayBilgiler(string id)
        {
            int ortalma;
            var users = unitofwork.Kuaforler.Find(x => x.Slug == id);
            List<KuaforYorum> kuaforYorum = unitofwork.KuaforYorum.List(x => x.KuaforIdi == users.Id);
            if (kuaforYorum.Count() == 0)
            {
                ortalma = 3;
              
            }
            else
            {
                double ort = unitofwork.KuaforYorum.List(x => x.KuaforIdi == users.Id).Average(x => x.KalitePuan);
                ortalma = Convert.ToInt32(ort);
              
            }
            KuaforDetayResponse kuaforDetayResponse = new KuaforDetayResponse();
            kuaforDetayResponse.calismaSaati = users.AcilmaSaati + "-" + users.KapanmaSaati;
            kuaforDetayResponse.kuaforSlug = users.Slug;
            kuaforDetayResponse.puan = ortalma;
            kuaforDetayResponse.resim = users.Resim;

            return Ok(kuaforDetayResponse);

        }


        [HttpGet]
        public IHttpActionResult DetayBilgilerIcerik(string id)
        {

            var users = unitofwork.Kuaforler.Find(x => x.Slug == id);
            //double ort = unitofwork.KuaforYorum.List(x => x.KuaforIdi == users.Id).Average(x => x.KalitePuan);
            //int ortalma = Convert.ToInt32(ort);
            //KuaforDetayResponse kuaforDetayResponse = new KuaforDetayResponse();
            //kuaforDetayResponse.calismaSaati = users.AcilmaSaati + "-" + users.KapanmaSaati;
            //kuaforDetayResponse.kuaforSlug = users.Slug;
            //kuaforDetayResponse.puan = ortalma;
            //kuaforDetayResponse.resim = users.Resim;

            return Ok(users);

        }


        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.Kuaforler.Find(x => x.Id == id);
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);

        }
        [HttpPut]
        public IHttpActionResult Guncelle(int id, Kuaforler languages)
        {


            Kuaforler ff = unitofwork.Kuaforler.Find(x => x.Id == languages.Id);
            ff.Ad = languages.Ad;
            ff.Adres = languages.Adres;
            ff.EklenmeTarihi = languages.EklenmeTarihi;
            ff.EMail = languages.EMail;
            ff.BayBayan = languages.BayBayan;
            ff.Puan = languages.Puan;
            ff.KuaforSahipId = ff.KuaforSahipId;
            ff.KuaforSahipIdi = ff.KuaforSahipIdi;
            ff.Resim = languages.Resim;
            ff.Sehir = karakterCevir(languages.Sehir);
            ff.Semt = languages.Semt;
            ff.Telefon = languages.Telefon;
            ff.Slug = karakterCevir(ff.Ad);
            ff.Aralik = languages.Aralik;
            ff.AcilmaSaati = languages.AcilmaSaati;
            ff.KapanmaSaati = languages.KapanmaSaati;
            unitofwork.Kuaforler.Update(ff);
            unitofwork.Complete();
            //  unitofwork.Dispose();

            KuaforSaatAralik kuaforss = new KuaforSaatAralik();
            kuaforss.AralikSil(ff);
            //KuaforSaatAralik kuaforss1 = new KuaforSaatAralik();
            var sayi = unitofwork.KuaforElemanlari.List(x => x.KuaforIdi == ff.Id);
            for (int i = 0; i < sayi.Count(); i++)
            {
                int idd = sayi[i].Id;
                kuaforss.Aralik(ff.AcilmaSaati, ff.KapanmaSaati, ff, ff.Aralik, idd);
            }

            return Ok();



        }
        [HttpPost]
        public Kuaforler Ekle(Kuaforler languages)
        {
            KuaforSahip kuaforSahip = unitofwork.KuaforSahip.Find(x => x.Id == languages.KuaforSahipIdi);
            Kuaforler ff = new Kuaforler();
            ff.Ad = languages.Ad;
            ff.Adres = languages.Adres;
            ff.EklenmeTarihi = DateTime.Now;
            ff.EMail = languages.EMail;
            ff.KuaforSahipIdi = languages.KuaforSahipIdi;
            ff.KuaforSahipId = kuaforSahip;
            ff.Resim = languages.Resim;
            ff.Sehir = karakterCevir(languages.Sehir);
            ff.Semt = languages.Semt;
            ff.Telefon = languages.Telefon;
            ff.Puan = 3;
            ff.Aralik = languages.Aralik;
            ff.Slug = karakterCevir(ff.Ad);
            ff.BayBayan = languages.BayBayan;
            ff.Resim = "deneme";
            ff.AcilmaSaati = languages.AcilmaSaati;
            ff.KapanmaSaati = languages.KapanmaSaati;
            unitofwork.Kuaforler.Insert(ff);
            unitofwork.Complete();

            KuaforAktiflik kuaforAktiflik = new KuaforAktiflik();
            kuaforAktiflik.Aktiflik = true;
            kuaforAktiflik.KuaforId = ff;
            kuaforAktiflik.KuaforIdi = ff.Id;
            kuaforAktiflik.Sebep = "Başlangıç";
            unitofwork.KuaforAktiflik.Insert(kuaforAktiflik);
            unitofwork.Complete();
            unitofwork.Dispose();


            return ff;
        }
        [HttpDelete]
        public IHttpActionResult Sil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Kuaforler ff = unitofwork.Kuaforler.Find(x => x.Id == id);
                unitofwork.Kuaforler.Delete(ff);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok();
                //return StatusCode(HttpStatusCode.NoContent);//buda olur
            }
        }

        public string karakterCevir(string kelime)
        {
            string mesaj = kelime;
            char[] oldValue = new char[] { 'ö', 'Ö', 'O', 'ü', 'Ü', 'U', 'ç', 'Ç', 'C', 'İ', 'ı', 'I', 'Ğ', 'ğ', 'G', 'Ş', 'ş', 'S', ' ' };
            char[] newValue = new char[] { 'o', 'o', 'o', 'u', 'u', 'u', 'c', 'c', 'c', 'i', 'i', 'i', 'g', 'g', 'g', 's', 's', 's', '-' };
            for (int sayac = 0; sayac < oldValue.Length; sayac++)
            {
                mesaj = mesaj.Replace(oldValue[sayac], newValue[sayac]).ToLower();
            }
            return mesaj;
        }
    }
}
