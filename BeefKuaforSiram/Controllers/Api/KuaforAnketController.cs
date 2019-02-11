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
    public class KuaforAnketController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());
        [HttpGet]
        public IHttpActionResult Tumu()
        {
            var users = unitofwork.KuaforAnket.List();
            return Ok(users);

        }
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

            }
        }
    }
}
