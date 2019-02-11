using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeefKuaforSiram.Controllers.Api
{
    public class KullaniciController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpGet]
        public IHttpActionResult Tumu()
        {
            var users = unitofwork.Kullanici.List();
            return Ok(users);

        }


        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.Kullanici.Find(x => x.Id == id);
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);

        }
        [HttpPut]
        public IHttpActionResult Guncelle(int id, Kullanici languages)
        {


            Kullanici ff = unitofwork.Kullanici.Find(x => x.Id == languages.Id);
            ff.Ad = languages.Ad;
          //  ff.DogumTarihi = languages.DogumTarihi;
            ff.Email = languages.Email;
            ff.KullaniciAdi = languages.KullaniciAdi;
            ff.Sehir = karakterCevir(languages.Sehir);
            ff.Semt = languages.Semt;
            ff.Sifre = languages.Sifre;
            ff.Slug = karakterCevir(ff.KullaniciAdi);
            ff.Soyad = languages.Soyad;
            ff.Telefon = languages.Telefon;
            unitofwork.Kullanici.Update(ff);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Ok();



        }
        [HttpPost]
        public Kullanici Ekle(Kullanici languages)
        {
            Kullanici ff = new Kullanici();
            ff.Ad = languages.Ad;
            ff.Avatar = "avatar3.png";
           // ff.DogumTarihi = languages.DogumTarihi;
            ff.Email = languages.Email;
            ff.KullaniciAdi = languages.KullaniciAdi;
            ff.Sehir = karakterCevir(languages.Sehir);
            ff.Semt = languages.Semt;
            ff.Sifre = languages.Sifre;
            ff.Slug = karakterCevir(ff.KullaniciAdi);
            ff.Soyad = languages.Soyad;
            ff.Telefon = languages.Telefon;
            unitofwork.Kullanici.Insert(ff);
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
                Kullanici ff = unitofwork.Kullanici.Find(x => x.Id == id);
                unitofwork.Kullanici.Delete(ff);
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
