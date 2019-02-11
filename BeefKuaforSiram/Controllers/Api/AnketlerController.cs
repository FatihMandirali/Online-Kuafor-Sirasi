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
    public class AnketlerController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpGet]
        public IHttpActionResult Tumu()
        {
            var kuaforAnkets = unitofwork.KuaforAnket.List();
            return Ok(kuaforAnkets);

        }
        [HttpGet]
        public string Deneme(int id)
        {
            string dene = "Deneme";
            return dene;

        }
        //[HttpPost]
        //public string Deneme(Dene id)
        //{
           
        //    return id.Name;

        //}
        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.KuaforAnket.Find(x => x.Id == id);
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);

        }
        [HttpPut]
        public IHttpActionResult Guncelle(int id, KuaforAnket languages)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                KuaforAnket ff = unitofwork.KuaforAnket.Find(x => x.Id == languages.Id);
                ff.Soru = languages.Soru;
                ff.CevapA = languages.CevapA;
                ff.CevapB = languages.CevapB;
                ff.CevapC = languages.CevapC;
                ff.CevapD = languages.CevapD;
                unitofwork.KuaforAnket.Update(ff);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok();
            }


        }
        [HttpPost]
        public KuaforAnket Ekle(KuaforAnket languages)
        {
            KuaforAnket ff = new KuaforAnket();
            ff.Soru = languages.Soru;
            ff.CevapA = languages.CevapA;
            ff.CevapB = languages.CevapB;
            ff.CevapC = languages.CevapC;
            ff.CevapD = languages.CevapD;
            unitofwork.KuaforAnket.Insert(ff);
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
                KuaforAnket ff = unitofwork.KuaforAnket.Find(x => x.Id == id);
                unitofwork.KuaforAnket.Delete(ff);
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
