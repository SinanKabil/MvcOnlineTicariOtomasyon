using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmen.Where(x => x.DepartmanDurum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmen.Add(d);
            d.DepartmanDurum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmen.Find(id);
            dep.DepartmanDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dep = c.Departmen.Find(id);
            return View("DepartmanGetir", dep);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dep = c.Departmen.Find(d.DepartmanID);
            dep.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanId == id).ToList();
            var dep = c.Departmen.Find(id);
            ViewBag.depad = dep.DepartmanAd;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var per = c.Personels.Find(id);
            ViewBag.perad = per.PersonelAd;
            ViewBag.persad = per.PersonelSoyad;
            return View(degerler);
        }
    }
}