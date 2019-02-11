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
    public class KullaniciProfilFavorilerController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());
       
        [HttpGet]
        public IHttpActionResult Tumu(string id)
        {
            Kullanici kullanici= unitofwork.Kullanici.Find(x => x.Slug == id);
            var users = unitofwork.KullaniciFavorileri.List(x => x.KullaniciIdi == kullanici.Id);
            List<KullaniciFavorilerResponse> kullaniciFavorilerResponse = new List<KullaniciFavorilerResponse>();
            for (int i = 0; i < users.Count(); i++)
            {
                int deger = users[i].KuaforIdi;
                Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Id ==deger );
                kullaniciFavorilerResponse.Add(new KullaniciFavorilerResponse
                {
                    ad = kuaforler.Ad,
                    adres = kuaforler.Adres,
                    sehir = kuaforler.Sehir
                });
            }
            return Ok(kullaniciFavorilerResponse);

        }

        [HttpPost]
        public IHttpActionResult KullaniciFavoriEkle(KullaniciFavorilerRequest kullaniciFavorilerRequest)
        {
            Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Slug == kullaniciFavorilerRequest.kuaforSlug);
            KullaniciFavorileri kullaniciFavorileriFind = unitofwork.KullaniciFavorileri.Find(x => x.KullaniciIdi == kullaniciFavorilerRequest.kullaniciId && x.KuaforIdi == kuaforler.Id);
            if (kullaniciFavorileriFind != null)
            {
                return Ok("Bu Kuafor Zaten Beğenildi");
            }
            else
            {
            Kullanici kullanici = unitofwork.Kullanici.Find(x => x.Id == kullaniciFavorilerRequest.kullaniciId);
            KullaniciFavorileri kullaniciFavorileri = new KullaniciFavorileri();
            kullaniciFavorileri.KuaforIdi = kuaforler.Id;
            kullaniciFavorileri.KullaniciIdi = kullanici.Id;
            unitofwork.KullaniciFavorileri.Insert(kullaniciFavorileri);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Ok();
            }
           
        }


        [HttpGet]
        public IHttpActionResult Profil(string id)
        {
            KullaniciProfilProfil kpp = new KullaniciProfilProfil();
            var users = unitofwork.Kullanici.Find(x => x.Slug == id);
            kpp.Ad = users.Ad;
            kpp.Soyad = users.Soyad;
            kpp.Mail = users.Email;
            kpp.KullaniciAdi = users.KullaniciAdi;
            kpp.Telefon = users.Telefon;
            kpp.Avatar = users.Avatar;
            return Ok(kpp);

        }

        [HttpGet]
        public IHttpActionResult Ayarlarim(string id)
        {
            Kullanici users = unitofwork.Kullanici.Find(x => x.Slug == id);

            return Ok(users);

        }

        [HttpPut]
        public IHttpActionResult KullaniciGuncelle(string id, Kullanici kff)
        { //kullanıcı geliyo gelen bilgileri alarak güncellemeyi yap slug null geliyo
            Kullanici users = unitofwork.Kullanici.Find(x => x.Slug == id);
            users.Ad = kff.Ad;
          //  users.DogumTarihi = kff.DogumTarihi;
            users.Email = kff.Email;
            users.KullaniciAdi = kff.KullaniciAdi;
            users.Sehir = kff.Sehir;
            users.Semt = kff.Semt;
            users.Sifre = kff.Sifre;
            users.Slug = karakterCevir(users.KullaniciAdi);
            users.Soyad = kff.Soyad;
            users.Telefon = kff.Telefon;
            unitofwork.Kullanici.Update(users);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Ok();

        }


        [HttpPut]
        public IHttpActionResult AvatarGuncelle(string id, KullaniciAvatarSecim kas)
        { //kullanıcı geliyo gelen bilgileri alarak güncellemeyi yap slug null geliyo
            Kullanici users = unitofwork.Kullanici.Find(x => x.Slug == id);
            users.Avatar = kas.Avatar;
            unitofwork.Kullanici.Update(users);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Ok();

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
