using BeefKuaforSiram.Core.Domain;
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
    public class KuaforElemanlariController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());
        [HttpGet]
        public IHttpActionResult Tumu(int id)
        {
            var users = unitofwork.KuaforElemanlari.List(x => x.KuaforId.Id == id);
            return Ok(users);

        }
        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.KuaforElemanlari.Find(x => x.Id == id);
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);

        }
        [HttpPut]
        public IHttpActionResult Guncelle(int id, KuaforElemanlari languages)
        {


            KuaforElemanlari ff = unitofwork.KuaforElemanlari.Find(x => x.Id == languages.Id);
            ff.Adi = languages.Adi;
            ff.KuaforIdi = ff.KuaforIdi;
            ff.Mail = languages.Mail;
            ff.Soyadi = languages.Soyadi;
            ff.Tc = languages.Tc;
            ff.Telefon = languages.Telefon;
            unitofwork.KuaforElemanlari.Update(ff);
            unitofwork.Complete();
            unitofwork.Dispose();

           
            return Ok();



        }
        [HttpPost]
        public IHttpActionResult Ekle(KuaforElemanlari languages)
        {

            Kuaforler ku = unitofwork.Kuaforler.Find(x => x.Id == languages.Id);
            KuaforElemanlari kuaforeleman = new KuaforElemanlari();
            kuaforeleman.Adi = languages.Adi;
            kuaforeleman.KuaforIdi = ku.Id;
            kuaforeleman.Mail = languages.Mail;
            kuaforeleman.Soyadi = languages.Soyadi;
            kuaforeleman.Tc = languages.Tc;
            kuaforeleman.Telefon = languages.Telefon;
            unitofwork.KuaforElemanlari.Insert(kuaforeleman);
            unitofwork.Complete();
            unitofwork.Dispose();
            KuaforSaatAralik kuaforss = new KuaforSaatAralik();
            kuaforss.Aralik(ku.AcilmaSaati, ku.KapanmaSaati, ku, ku.Aralik,kuaforeleman.Id);

            return Ok();
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
                KuaforElemanlari ff = unitofwork.KuaforElemanlari.Find(x => x.Id == id);
                unitofwork.KuaforElemanlari.Delete(ff);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok();

            }
        }
    }
}
