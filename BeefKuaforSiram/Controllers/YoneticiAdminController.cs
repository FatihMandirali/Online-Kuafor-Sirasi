using BeefKuaforSiram.Belgeler.BaseController;
using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Persistence;
using KuaforBeef.Belgeler.ResizeImage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeefKuaforSiram.Controllers
{
    public class YoneticiAdminController : BaseControllerYonetici
    {
        Unit unitofwork = new Unit(new PlutoContext());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kuaforler()
        {
            return View();
        }


        public ActionResult KuaforEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KuaforEkle(Kuaforler kuafor, HttpPostedFileBase ProfileImage)
        {//kUAFOR EKLEME SAYFASINA ACİLMA SAAATİ KAPANMA SAATİ EKLE
            Kuaforler berber = new Kuaforler();
            string filename = $"blog_{Guid.NewGuid()}.png";
            Image imm = ReSizeImage.Resize(Image.FromStream(ProfileImage.InputStream), 500, 500);
            imm.Save(Server.MapPath($"~/Belgeler/Images/KuaforImage/{filename}"), ImageFormat.Png);
            berber.Ad = kuafor.Ad;
            berber.Adres = kuafor.Adres;
            berber.EklenmeTarihi = kuafor.EklenmeTarihi;
            berber.EMail = kuafor.EMail;
            KuaforSahip berbersahip = unitofwork.KuaforSahip.Find(x => x.Tc == kuafor.Resim);
            berber.KuaforSahipId = berbersahip;
            berber.Resim = filename;
            berber.Puan = 2;
            berber.Aralik = kuafor.Aralik;
            berber.BayBayan = kuafor.BayBayan;
            berber.Sehir = karakterCevir(kuafor.Sehir);
            berber.Semt = kuafor.Semt;
            berber.Telefon = kuafor.Telefon;
            berber.Slug = karakterCevir(berber.Ad);
            berber.KapanmaSaati = kuafor.KapanmaSaati;
            berber.AcilmaSaati = kuafor.AcilmaSaati;
            unitofwork.Kuaforler.Insert(berber);
            unitofwork.Complete();
          

            KuaforAktiflik kuaforAktiflik = new KuaforAktiflik();
            kuaforAktiflik.Aktiflik = true;
            kuaforAktiflik.KuaforId = berber;
            kuaforAktiflik.KuaforIdi = berber.Id;
            kuaforAktiflik.Sebep = "Başlangıç";
            unitofwork.KuaforAktiflik.Insert(kuaforAktiflik);
            unitofwork.Complete();
            unitofwork.Dispose();
            // KuaforTrasAralikManager kuaforTrasAralikManager = new KuaforTrasAralikManager();
            // KuaforTrasSaatiAralik trasAralik;
            // string saat = berber.AcilmaSaati;
            // int ilkiki = Convert.ToInt32(saat.Substring(0, 2));
            // int soniki = Convert.ToInt32(saat.Substring(3, 2));
            // DateTime zaman = new DateTime(2019, 10, 10, ilkiki, soniki, 0);
            // string saat1 = berber.KapanmaSaati;
            // int ilkiki1 = Convert.ToInt32(saat1.Substring(0, 2));
            // int soniki1 = Convert.ToInt32(saat1.Substring(3, 2));
            // DateTime zaman1 = new DateTime(2019, 10, 10, ilkiki1, soniki1, 0);
            //while(true)
            // {

            //         trasAralik = new KuaforTrasSaatiAralik();
            //         trasAralik.BaslamaSaati = zaman.ToString("HH:mm");
            //         zaman = zaman.AddMinutes(30);
            //         trasAralik.BitisSaati = zaman.ToString("HH:mm");
            //         trasAralik.Dolu = false;
            //         trasAralik.KuaforId = berber;
            //         kuaforTrasAralikManager.Insert(trasAralik);

            //       if (zaman > zaman1)
            //     {return View();}

            // }//genel fonksiyon yap bunu ve güncellemeyede ekle


            return View();
        }


        public ActionResult KuaforIncele(int? id)
        {
            return View();
        }

        [HttpPost]
        public JsonResult KuaforSil(int id)
        {
            Kuaforler pf = unitofwork.Kuaforler.Find(x => x.Id == id);
            KuaforAktiflik kuaforAktiflik = unitofwork.KuaforAktiflik.Find(x => x.KuaforIdi == pf.Id);
            unitofwork.KuaforAktiflik.Delete(kuaforAktiflik);
            unitofwork.Complete();
            unitofwork.Kuaforler.Delete(pf);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Json("Kuaför başarıyla silindi.", JsonRequestBehavior.AllowGet);
        }


        public ActionResult KuaforSahip()
        {
            return View();
        }

        public ActionResult KuaforSahipEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KuaforSahipEkle(KuaforSahip kuaforsahip)
        {
            KuaforSahip berbersahip = new KuaforSahip();
            berbersahip.Ad = kuaforsahip.Ad;
            berbersahip.Soyad = kuaforsahip.Soyad;
          //  berbersahip.DogumTarihi = kuaforsahip.DogumTarihi;
            berbersahip.Email = kuaforsahip.Email;
            berbersahip.KullaniciAdi = kuaforsahip.KullaniciAdi;
            berbersahip.Sehir = karakterCevir(kuaforsahip.Sehir);
            berbersahip.Semt = kuaforsahip.Semt;
            berbersahip.Sifre = kuaforsahip.Sifre;
            berbersahip.Tc = kuaforsahip.Tc;
            berbersahip.Telefon = kuaforsahip.Telefon;
            unitofwork.KuaforSahip.Insert(berbersahip);
            unitofwork.Complete();
            unitofwork.Dispose();
            return View();
        }

        public ActionResult KuaforSahipIncele(int? id)
        {
            return View();
        }

        [HttpPost]
        public JsonResult KuaforSahipSil(int id)
        {
            KuaforSahip pf = unitofwork.KuaforSahip.Find(x => x.Id == id);

            unitofwork.KuaforSahip.Delete(pf);
            unitofwork.Complete();
            unitofwork.Dispose();

            return Json("Kuaför Sahibi başarıyla silindi.", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Anketler()
        {
            return View();
        }

        public ActionResult AnketlerIncele()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AnketSil(int id)
        {
            KuaforAnket pf = unitofwork.KuaforAnket.Find(x => x.Id == id);

            unitofwork.KuaforAnket.Delete(pf);
            unitofwork.Complete();
            unitofwork.Dispose();
            return Json("Anket başarıyla silindi.", JsonRequestBehavior.AllowGet);
        }

        public ActionResult AnketOlustur()
        {
            return View();
        }


        public ActionResult Kullanicilar()
        {
            return View();
        }

        public ActionResult KullaniciIncele()
        {
            return View();
        }

        public ActionResult KullaniciOlustur()
        {
            return View();
        }

        public ActionResult Yoneticiler()
        {
            return View();
        }


        public ActionResult YoneticiIncele()
        {
            return View();
        }

        public ActionResult YoneticiOlustur()
        {
            return View();
        }


        public ActionResult FirsatOnay()
        {
            return View();
        }

        public ActionResult FirsatIncele()
        {
            return View();
        }

        public ActionResult Gorevler()
        {
            return View();
        }

        public ActionResult GorevlerIncele()
        {
            return View();
        }

        public ActionResult GorevOlustur()
        {
            return View();
        }

        [HttpPost]
        public JsonResult YoneticiAdminLogin(int id)
        {

            Kuaforler kuaforler = unitofwork.Kuaforler.Find(x => x.Id == id);
            //Kuaforu bul
            if (kuaforler == null)
            {
                return Json("Lütfen Bilgilerinizi Kontrol Ediniz..", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["yoneticiYonet"] = kuaforler.Id;
                Session["yoneticiYonetKuaforAd"] = kuaforler.Ad;
                return Json("Başarılı Giriş..", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult CikisYap()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
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