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
    public class YoneticiController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpGet]
        public IHttpActionResult Tumu()
        {
            var users = unitofwork.Yonetici.List();
            return Ok(users);

        }
        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.Yonetici.Find(x => x.Id == id);
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);

        }
        [HttpPut]
        public IHttpActionResult Guncelle(int id, Yonetici languages)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Yonetici ff = unitofwork.Yonetici.Find(x => x.Id == languages.Id);
                ff.Ad = languages.Ad;
                ff.DogumTarihi = languages.DogumTarihi;
                ff.Email = languages.Email;
                ff.KullaniciAdi = languages.KullaniciAdi;
                ff.Sehir = karakterCevir(languages.Sehir);
                ff.Semt = languages.Semt;
                ff.Sifre = languages.Sifre;
                ff.Soyad = languages.Soyad;
                ff.Telefon = languages.Telefon;
                unitofwork.Yonetici.Update(ff);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok();
            }


        }
        [HttpPost]
        public Yonetici Ekle(Yonetici languages)
        {
            Yonetici ff = new Yonetici();
            ff.Ad = languages.Ad;
            ff.DogumTarihi = languages.DogumTarihi;
            ff.Email = languages.Email;
            ff.KullaniciAdi = languages.KullaniciAdi;
            ff.Sehir = karakterCevir(languages.Sehir);
            ff.Semt = languages.Semt;
            ff.Sifre = languages.Sifre;
            ff.Soyad = languages.Soyad;
            ff.Telefon = languages.Telefon;
            unitofwork.Yonetici.Insert(ff);
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
                Yonetici ff = unitofwork.Yonetici.Find(x => x.Id == id);
                unitofwork.Yonetici.Delete(ff);
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
