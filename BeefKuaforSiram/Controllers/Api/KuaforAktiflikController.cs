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
    public class KuaforAktiflikController : ApiController
    {

        Unit unitofwork = new Unit(new PlutoContext());

        [HttpPost]
        public Dene1 DenemeApii(Dene dene)
        {
            // var users = unitofwork.KuaforAktiflik.List();
            //List<Dene1> dene1s = new List<Dene1>();
            //dene1s.Add(new Dene1() { ad = "gs" });
            //dene1s.Add(new Dene1() { ad = "FF" });
            Dene1 dene1 = new Dene1();
            dene1.ad = "Dönene değer";
          //  string dn = "Dönene değer";
            return dene1;

        }

        [HttpGet]
        public IHttpActionResult Tumu()
        {
            var users = unitofwork.KuaforAktiflik.List();
            return Ok(users);

        }
        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.KuaforAktiflik.Find(x => x.KuaforIdi == id);
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);

        }
        [HttpPut]
        public IHttpActionResult Guncelle(int id, KuaforAktiflik languages)
        {


            KuaforAktiflik ff = unitofwork.KuaforAktiflik.Find(x => x.KuaforIdi == languages.Id);
            ff.Aktiflik = languages.Aktiflik;
            ff.KuaforIdi = ff.KuaforIdi;
            ff.Sebep = languages.Sebep;
            unitofwork.KuaforAktiflik.Update(ff);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Ok();



        }
        [HttpPost]
        public KuaforAktiflik Ekle(KuaforAktiflik languages)
        {
           // KuaforlerManager km = new KuaforlerManager();
            Kuaforler k = unitofwork.Kuaforler.Find(x => x.KuaforSahipId.Id == languages.Id);
            KuaforAktiflik ff = new KuaforAktiflik();
            ff.Aktiflik = languages.Aktiflik;
            ff.KuaforId = k;
            ff.Sebep = languages.Sebep;
            unitofwork.KuaforAktiflik.Insert(ff);
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
                KuaforAktiflik ff = unitofwork.KuaforAktiflik.Find(x => x.Id == id);
                unitofwork.KuaforAktiflik.Delete(ff);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok();
                //return StatusCode(HttpStatusCode.NoContent);//buda olur
            }
        }
    }
}
