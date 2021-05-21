using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x => x.CariDurum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler p)
        {
            p.CariDurum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var car = c.Carilers.Find(id);
            car.CariDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var car = c.Carilers.Find(id);
            return View("CariGetir", car);
        }
        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var car = c.Carilers.Find(p.CariID);
            car.CariAd = p.CariAd;
            car.CariMail = p.CariMail;
            car.CariSehir = p.CariSehir;
            car.CariSoyad = p.CariSoyad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            var carad = c.Carilers.Find(id);
            ViewBag.cariad = carad.CariAd;
            ViewBag.carisad = carad.CariSoyad;
            return View(degerler);
        }
    }
}