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
    public class KuaforTrasCesitleriController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpGet]
        public IHttpActionResult Tumu(int id)
        {

            var users = unitofwork.KuaforTrasCesitleri.List(x => x.KuaforIdi == id);

            return Ok(users);

        }

        [HttpGet]
        public IHttpActionResult DetayTrasCesitleri(string id)
        {
            Kuaforler kk = unitofwork.Kuaforler.Find(x => x.Slug == id);
            var users = unitofwork.KuaforTrasCesitleri.List(x => x.KuaforIdi == kk.Id);

            return Ok(users);

        }

        [HttpGet]
        public IHttpActionResult TumuCesitler(int id)
        {
            string cesitler = "";
            List<KuaforTrasCesitleri> users = unitofwork.KuaforTrasCesitleri.List(x => x.KuaforIdi == id);
            foreach (var item in users)
            {
                cesitler = cesitler + "," + item.Cesit;
            }
            string c = cesitler;
            return Ok(c);

        }


        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.KuaforTrasCesitleri.Find(x => x.Id == id);
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);

        }
        [HttpPut]
        public IHttpActionResult Guncelle(int id, KuaforTrasCesitleri languages)
        {

            KuaforTrasCesitleri ff = unitofwork.KuaforTrasCesitleri.Find(x => x.Id == id);

            //  Kuaforler kk=k.Find(x=>x.Id==languages.Id);
            ff.Cesit = languages.Cesit;
            ff.Dk = languages.Dk;
            ff.Fiyat = languages.Fiyat;
           // ff.KuaforIdi = languages.KuaforIdi;
            unitofwork.KuaforTrasCesitleri.Update(ff);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Ok();



        }
        [HttpPost]
        public KuaforTrasCesitleri Ekle(KuaforTrasCesitleri languages)
        {
            //     KuaforlerManager k = new KuaforlerManager();
             Kuaforler kua = unitofwork.Kuaforler.Find(x => x.Id == languages.Id);
            KuaforTrasCesitleri ff = new KuaforTrasCesitleri();
            ff.Cesit = languages.Cesit;
            ff.Dk = languages.Dk;
            ff.Fiyat = languages.Fiyat;
            ff.KuaforIdi = kua.Id;
            unitofwork.KuaforTrasCesitleri.Insert(ff);
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
                KuaforTrasCesitleri ff = unitofwork.KuaforTrasCesitleri.Find(x => x.Id == id);
                unitofwork.KuaforTrasCesitleri.Delete(ff);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok();
                //return StatusCode(HttpStatusCode.NoContent);//buda olur
            }
        }
    }
}
