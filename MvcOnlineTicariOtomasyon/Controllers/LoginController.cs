using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialKayitOl()
        {
            return PartialView();
        } 
        [HttpPost]
        public PartialViewResult PartialKayitOl(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult MüsteriGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MüsteriGiris(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if (bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            return RedirectToAction("Index","Login");
        }
        [HttpGet]
        public ActionResult PersonelGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelGiris(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.AdminKullaniciAd == p.AdminKullaniciAd && x.AdminSifre == p.AdminSifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AdminKullaniciAd, false);
                Session["CariMail"] = bilgiler.AdminKullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");

            }
            return RedirectToAction("Index", "Login");
        }
    }
}