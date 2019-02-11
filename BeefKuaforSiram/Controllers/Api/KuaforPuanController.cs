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
    public class KuaforPuanController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpGet]
        public IHttpActionResult Tumu()
        {
            var users = unitofwork.KuaforPuan.List();
            return Ok(users);

        }
        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.KuaforPuan.Find(x => x.KuaforId.Id == id);
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);

        }
        [HttpPut]
        public IHttpActionResult Guncelle(int id, KuaforPuan languages)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                KuaforPuan ff = unitofwork.KuaforPuan.Find(x => x.Id == languages.Id);
                ff.HizPuan = languages.HizPuan;
                ff.KalitePuan = languages.KalitePuan;
                ff.KuaforId = languages.KuaforId;
                ff.KullaniciId = languages.KullaniciId;
                ff.OzenPuan = languages.OzenPuan;
                unitofwork.KuaforPuan.Update(ff);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok();
            }


        }
        [HttpPost]
        public KuaforPuan Ekle(KuaforPuan languages)
        {
            KuaforPuan ff = new KuaforPuan();
            ff.HizPuan = languages.HizPuan;
            ff.KalitePuan = languages.KalitePuan;
            ff.KuaforId = languages.KuaforId;
            ff.KullaniciId = languages.KullaniciId;
            ff.OzenPuan = languages.OzenPuan;
            unitofwork.KuaforPuan.Insert(ff);
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
                KuaforPuan ff = unitofwork.KuaforPuan.Find(x => x.Id == id);
                unitofwork.KuaforPuan.Delete(ff);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok();
                //return StatusCode(HttpStatusCode.NoContent);//buda olur
            }
        }
    }
}
