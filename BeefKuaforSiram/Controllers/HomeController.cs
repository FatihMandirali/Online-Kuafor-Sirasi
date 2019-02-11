using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Core.Domain.Modeller;
using BeefKuaforSiram.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeefKuaforSiram.Controllers
{
    public class HomeController : Controller
    {
        Unit unitofwork = new Unit(new PlutoContext());
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Iller(string id)
        {
            if (id == null)
            {
                HttpCookie cookie = Response.Cookies["sehir"];
                if (cookie.Value != null)
                {
                    string sehirname = Request.Cookies["sehir"].Value;
                    TempData["sehiradi"] = sehirname;
                    Response.Redirect("/Home/Iller/" + sehirname);

                }
                else
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                HttpCookie cookie = new HttpCookie("sehir");
                cookie.Value = id;
                cookie.Expires = DateTime.Now.AddDays(5);
                Response.Cookies.Add(cookie);
                TempData["sehirad"] = id;
                if (Session["kulanici"] != null)
                {
                    int gelensession = Convert.ToInt32(Session["kulanici"].ToString());

                    Kullanici k = unitofwork.Kullanici.Find(x => x.Id == gelensession);
                    string sessiondeger = k.Ad + " " + k.Soyad;
                    string kullaniciid = karakterCevir(k.KullaniciAdi);
                    TempData["kullaniciessi"] = sessiondeger;
                    TempData["kullaniciId"] = kullaniciid;
                }
                return View();
            }

        }

        [HttpPost]
        public JsonResult SehirSec()
        {

            HttpContext.Response.Cookies["sehir"].Expires = DateTime.Now;

            return Json("", JsonRequestBehavior.AllowGet);
        }


        public ActionResult KuaforAdminLogin()
        {

            return View();
        }

        [HttpPost]
        public JsonResult KuaforAdminLogin(LoginViewModel login)
        {
           
            KuaforSahip ks = unitofwork.KuaforSahip.Find(x => x.KullaniciAdi == login.UserName && x.Sifre == login.Password);
            //Kuaforu bul
            if (ks == null)
            {
                return Json("Lütfen Bilgilerinizi Kontrol Ediniz..", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["kuaforsahip"] = ks.Id;
                return Json("Başarılı Giriş..", JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult KuaforCreateAdminLogin(LoginViewModel login)
        {

            KuaforSahip ks = unitofwork.KuaforSahip.Find(x => x.KullaniciAdi == login.UserName && x.Sifre == login.Password);
            //Kuaforu bul
            if (ks == null)
            {
                return Json("Lütfen Bilgilerinizi Kontrol Ediniz..", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["kuaforsahipCreate"] = ks.Id;
                return Json("Başarılı Giriş.."+ks.Id, JsonRequestBehavior.AllowGet);
            }

        }
        

        public ActionResult YoneticiAdminLogin()
        {

            return View();
        }

        [HttpPost]
        public JsonResult YoneticiAdminLogin(LoginViewModel login)
        {

            Yonetici yonetici = unitofwork.Yonetici.Find(x => x.KullaniciAdi == login.UserName && x.Sifre == login.Password);
            //Kuaforu bul
            if (yonetici == null)
            {
                return Json("Lütfen Bilgilerinizi Kontrol Ediniz..", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["yonetici"] = yonetici.Id;
                return Json("Başarılı Giriş..", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult KullaniciLogin(LoginViewModel login)
        {

            Kullanici ks = unitofwork.Kullanici.Find(x => x.KullaniciAdi == login.UserName && x.Sifre == login.Password);
            if (ks == null)
            {
                return Json("Lütfen Bilgilerinizi Kontrol Ediniz..", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["kulanici"] = ks.Id;

                return Json("Başarılı Giriş..", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult KuaforDetay(string id)
        {
            if (id == null)
            {
                return View("Iller");
            }
            else
            {
                if (Session["kulanici"] != null)
                {
                    int gelensession = Convert.ToInt32(Session["kulanici"].ToString());

                    Kullanici k = unitofwork.Kullanici.Find(x => x.Id == gelensession);
                    string sessiondeger = k.Ad + " " + k.Soyad;
                    string kullaniciid = karakterCevir(k.KullaniciAdi);
                    TempData["kullaniciessi"] = sessiondeger;
                    TempData["kullaniciId"] = kullaniciid;
                }
                return View();
            }

        }

        public ActionResult KullaniciProfil(string id)
        {
            if (Session["kulanici"] != null)
            {
                int gelensession = Convert.ToInt32(Session["kulanici"].ToString());

                Kullanici k = unitofwork.Kullanici.Find(x => x.Id == gelensession);
                string sessiondeger = k.Ad + " " + k.Soyad;
                string kullaniciid = karakterCevir(k.KullaniciAdi);
                TempData["kullaniciessi"] = sessiondeger;
                TempData["kullaniciId"] = kullaniciid;
            }
            return View();
        }

        public ActionResult KuaforSiraAl()
        {

            if (Session["kulanici"] != null)
            {
                int gelensession = Convert.ToInt32(Session["kulanici"].ToString());

                Kullanici k = unitofwork.Kullanici.Find(x => x.Id == gelensession);
                string sessiondeger = k.Ad + " " + k.Soyad;
                string kullaniciid = karakterCevir(k.KullaniciAdi);
                TempData["kullaniciessi"] = sessiondeger;
                TempData["kullaniciId"] = kullaniciid;
            }
            return View();
        }

        public ActionResult KullaniciCuzdan()
        {
            if (Session["kulanici"] != null)
            {
                int gelensession = Convert.ToInt32(Session["kulanici"].ToString());

                Kullanici k = unitofwork.Kullanici.Find(x => x.Id == gelensession);
                string sessiondeger = k.Ad + " " + k.Soyad;
                string kullaniciid = karakterCevir(k.KullaniciAdi);
                TempData["kullaniciessi"] = sessiondeger;
                TempData["kullaniciId"] = kullaniciid;
            }
            return View();
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

        [HttpPost]
        public JsonResult CikisYap()
        {
            Session.Clear();
            return Json("Güncellemeniz Başarılı Bir Şekilde Gerçekleşti.Güvenlik Sebebiyle Çıkışınız Yapıldı Lütfen Tekrar Giriş Yapın.", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CikisYapNormal()
        {
            Session.Clear();
            return Json("Çıkışınız Yapılmıştır.", JsonRequestBehavior.AllowGet);
        }

    }
}