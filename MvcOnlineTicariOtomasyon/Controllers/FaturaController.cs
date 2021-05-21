using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar p)
        {
            c.Faturalars.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar p)
        {
            var fatura = c.Faturalars.Find(p.FaturaID);
            fatura.FaturaSaat = p.FaturaSaat;
            fatura.FaturaSeriNo = p.FaturaSeriNo;
            fatura.FaturaSıraNo = p.FaturaSıraNo;
            fatura.FaturaTarih = p.FaturaTarih;
            fatura.FaturaTeslimAlan = p.FaturaTeslimAlan;
            fatura.FaturaTeslimEden = p.FaturaTeslimEden;
            fatura.FaturaVergiDairesi = p.FaturaVergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            var seri = c.Faturalars.Find(id);
            ViewBag.seri = seri.FaturaSeriNo;
            var sira = c.Faturalars.Find(id);
            ViewBag.sira = sira.FaturaSıraNo;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaKalemEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}