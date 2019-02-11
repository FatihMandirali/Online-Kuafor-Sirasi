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
    public class KuaforSaatleriController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());

        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.Kuaforler.Find(x => x.Id == id);
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);

        }
        [HttpPut]
        public IHttpActionResult Guncelle(int id, KuaforSaatleri languages)
        {


            Kuaforler ff = unitofwork.Kuaforler.Find(x => x.Id == languages.Id);
            ff.AcilmaSaati = languages.AcilmaSaati;
            //  ff.KuaforId = ff.KuaforId;
            ff.Aralik = languages.Aralik;
            ff.KapanmaSaati = languages.KapanmaSaati;
            unitofwork.Kuaforler.Update(ff);
            unitofwork.Complete();

            KuaforSaatAralik kuaforss = new KuaforSaatAralik();
            kuaforss.AralikSil(ff);
            //KuaforSaatAralik kuaforss1 = new KuaforSaatAralik();
            var sayi = unitofwork.KuaforElemanlari.List(x => x.KuaforIdi == ff.Id);
            for (int i = 0; i < sayi.Count(); i++)
            {
                int idd = sayi[i].Id;
                kuaforss.Aralik(ff.AcilmaSaati, ff.KapanmaSaati, ff, ff.Aralik, idd);
            }


            return Ok();



        }
    }
}
