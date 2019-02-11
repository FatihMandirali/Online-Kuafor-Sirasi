using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Core.Domain.Modeller;
using BeefKuaforSiram.Core.Domain.Modeller.YoneticiAdminModel;
using BeefKuaforSiram.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeefKuaforSiram.Controllers.Api
{
    public class KuaforFirsatlarController : ApiController
    {
        Unit unitofwork = new Unit(new PlutoContext());
        [HttpGet]
        public IHttpActionResult TumuGenel()
        {
            var users = unitofwork.KuaforFirsat.List();
            List<KuaforFirsatlarResponse> kuaforFirsatlarResponse = new List<KuaforFirsatlarResponse>();
            for (int i = 0; i < users.Count(); i++)
            {
                int kuaId = users[i].KuaforIdi;
                Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Id == kuaId);
                kuaforFirsatlarResponse.Add(new KuaforFirsatlarResponse()
                {
                    firsatAdi = users[i].FirsatIcerik,
                    id = users[i].Id,
                    kuaforAdi = kuaforler.Ad,
                    sehir = kuaforler.Sehir,
                    tarih = users[i].FirsatYayinTarih.ToString("dd-MM-yyyy"),
                    onayTuru = users[i].YoneticiOnayi

                });


            }


            return Ok(kuaforFirsatlarResponse);

        }

        [HttpGet]
        public IHttpActionResult Tumu(string id)
        {

            DateTime bugun = DateTime.Now;
            var users = unitofwork.KuaforFirsat.List(x => x.KuaforId.Sehir == id );
            List<KuaforFirsatlarMainPageResponse> kuaforFirsatlarResponse = new List<KuaforFirsatlarMainPageResponse>();
            for (int i = 0; i < users.Count(); i++)
            {
                DateTime dateTime = users[i].FirsatYayinTarih;
                TimeSpan kalangun = bugun -dateTime;
                int fark =Convert.ToInt32(kalangun.Days.ToString());
                if (fark>=0  && fark <= 7)
                {
                int kuaforIdi = users[i].KuaforIdi;
                Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Id == kuaforIdi);
                kuaforFirsatlarResponse.Add(new KuaforFirsatlarMainPageResponse()
                {
                    firsat = users[i].FirsatIcerik,
                    kuaforAdi = kuaforler.Ad,
                    yoneticiOnay = users[i].YoneticiOnayi
                });
                }
               
            }
            return Ok(kuaforFirsatlarResponse);

        }

        [HttpGet]
        public IHttpActionResult TumuOzel(int id)
        {

          //  DateTime bugun = DateTime.Now;
            var users = unitofwork.KuaforFirsat.List(x => x.KuaforId.Id == id);
            //List<KuaforFirsatlarMainPageResponse> kuaforFirsatlarResponse = new List<KuaforFirsatlarMainPageResponse>();
            //for (int i = 0; i < users.Count(); i++)
            //{
            //    DateTime dateTime = users[i].FirsatYayinTarih;
            //    TimeSpan kalangun = bugun - dateTime;
            //  //  int fark = Convert.ToInt32(kalangun.Days.ToString());
            // //   if (fark > 0 && fark <= 7)
            //  //  {
            //        int kuaforIdi = users[i].KuaforIdi;
            //        Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Id == kuaforIdi);
            //        kuaforFirsatlarResponse.Add(new KuaforFirsatlarMainPageResponse()
            //        {
            //            firsat = users[i].FirsatIcerik,
            //            kuaforAdi = kuaforler.Ad,
            //            yoneticiOnay = users[i].YoneticiOnayi
            //        });
            //  //  }

            //}
            return Ok(users);

        }
        

        [HttpGet]
        public IHttpActionResult Ozellestirilmis(int id)
        {
            var languages = unitofwork.KuaforFirsat.Find(x => x.Id == id);
            int kuaId = languages.KuaforIdi;
            Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Id == kuaId);
            KuaforFirsatlarResponse kuaforFirsatlarResponse = new KuaforFirsatlarResponse();
            kuaforFirsatlarResponse.firsatAdi = languages.FirsatIcerik;
            kuaforFirsatlarResponse.id = languages.Id;
            kuaforFirsatlarResponse.kuaforAdi = kuaforler.Ad;
            kuaforFirsatlarResponse.sehir = kuaforler.Sehir;
            kuaforFirsatlarResponse.tarih = languages.FirsatYayinTarih.ToString("dd-MM-yyyy");
            kuaforFirsatlarResponse.onayTuru = languages.YoneticiOnayi;
            return Ok(kuaforFirsatlarResponse);

        }

        [HttpGet]
        public IHttpActionResult OzellestirilmisKuaforAdmin(int id)
        {
            var languages = unitofwork.KuaforFirsat.Find(x => x.Id == id);
            return Ok(languages);

        }
        
        [HttpPut]
        public IHttpActionResult Guncelle(int id, KuaforFirsat languages)
        {


            KuaforFirsat ff = unitofwork.KuaforFirsat.Find(x => x.Id == languages.Id);
         //   ff.FirsatIcerik = languages.FirsatIcerik;
          //  ff.FirsatYayinTarih = languages.FirsatYayinTarih;
         //   ff.KuaforIdi = ff.KuaforIdi;
            ff.YoneticiOnayi = languages.YoneticiOnayi;
            unitofwork.KuaforFirsat.Update(ff);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Ok();



        }
        [HttpPost]
        public KuaforFirsat Ekle(KuaforFirsat languages)
        {

            Kuaforler k = unitofwork.Kuaforler.Find(x => x.Id == languages.Id);
            KuaforFirsat ff = new KuaforFirsat();
            ff.FirsatIcerik = languages.FirsatIcerik;
            ff.FirsatYayinTarih = languages.FirsatYayinTarih;
            ff.KuaforIdi = k.Id;
            ff.YoneticiOnayi = languages.YoneticiOnayi;
            unitofwork.KuaforFirsat.Insert(ff);
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
                KuaforFirsat ff = unitofwork.KuaforFirsat.Find(x => x.Id == id);
                unitofwork.KuaforFirsat.Delete(ff);
                unitofwork.Complete();
                unitofwork.Dispose();
                return Ok();
                //return StatusCode(HttpStatusCode.NoContent);//buda olur
            }
        }
    }
}
