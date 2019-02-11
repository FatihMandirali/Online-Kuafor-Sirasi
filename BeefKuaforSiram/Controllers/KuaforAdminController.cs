using KuaforBeef.Belgeler.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeefKuaforSiram.Controllers
{
    public class KuaforAdminController : BaseController
    {
        // GET: KuaforAdmin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KuaforSecimi()
        {
            return View();
        }

        public ActionResult TrasCesitleri()
        {
            return View();
        }

        public ActionResult TrasCesitleriOlustur()
        {
            return View();
        }


        public ActionResult TrasCesitleriIncele(int? id)
        {
            return View();
        }

        public ActionResult CalismaSaatleri()
        {
            return View();
        }

        public ActionResult KuaforElemanlari()
        {
            return View();
        }


        public ActionResult KuaforElemanEkle()
        {
            return View();
        }

        public ActionResult KuaforElemanIncele()
        {
            return View();
        }

        public ActionResult Firsatlar()
        {
            return View();
        }

        public ActionResult FirsatOlustur()
        {
            return View();
        }

        public ActionResult FirsatIncele()
        {
            return View();
        }

        public ActionResult GelecekSira()
        {
            return View();
        }

        public ActionResult GelecekSiraIncele()
        {
            return View();
        }

        public ActionResult GecmisSira()
        {
            return View();
        }

        public ActionResult OkunmamisMesajlar()
        {
            return View();
        }
        

        public ActionResult GecmisSiraIncele()
        {
            return View();
        }

        public ActionResult Yorumlar()
        {
            return View();
        }

        public ActionResult YorumlarIncele()
        {
            return View();
        }

        public ActionResult SiraOlustur()
        {
            return View();
        }
        

        public ActionResult Aktiflik()
        {
            return View();
        }

        [HttpPost]
        public JsonResult KuaforSecimSession(int id)
        {
                Session["kuaforsecim"] = id;
                return Json("Admine Yönlendiriliyorsunuz.", JsonRequestBehavior.AllowGet);
           

        }
        public ActionResult CikisYap()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}