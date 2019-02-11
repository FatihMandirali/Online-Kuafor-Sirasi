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
    public class KuaforSahipController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpGet]
        public IHttpActionResult Tumu()
        {
            var users = unitofwork.KuaforSahip.List();
            return Ok(users);

        }
        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.KuaforSahip.Find(x => x.Id == id);
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);

        }
        [HttpPut]
        public IHttpActionResult Guncelle(int id, KuaforSahip languages)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                KuaforSahip ff = unitofwork.KuaforSahip.Find(x => x.Id == languages.Id);
                ff.Ad = languages.Ad;
               // ff.DogumTarihi = languages.DogumTarihi;
                ff.Email = languages.Email;
                ff.KullaniciAdi = languages.KullaniciAdi;
                ff.Sehir = karakterCevir(languages.Sehir);
                ff.Semt = languages.Semt;
                ff.Sifre = languages.Sifre;
                ff.Soyad = languages.Soyad;
                ff.Tc = languages.Tc;
                ff.Telefon = languages.Telefon;
                unitofwork.KuaforSahip.Update(ff);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok();
            }


        }
        [HttpPost]
        public KuaforSahip Ekle(KuaforSahip languages)
        {
            KuaforSahip ff = new KuaforSahip();
            ff.Ad = languages.Ad;
         //   ff.DogumTarihi = languages.DogumTarihi;
            ff.Email = languages.Email;
            ff.KullaniciAdi = languages.KullaniciAdi;
            ff.Sehir = karakterCevir(languages.Sehir);
            ff.Semt = languages.Semt;
            ff.Sifre = languages.Sehir;
            ff.Soyad = languages.Soyad;
            ff.Tc = languages.Tc;
            ff.Telefon = languages.Telefon;
            unitofwork.KuaforSahip.Insert(ff);
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
                KuaforSahip ff = unitofwork.KuaforSahip.Find(x => x.Id == id);
                unitofwork.KuaforSahip.Delete(ff);
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
