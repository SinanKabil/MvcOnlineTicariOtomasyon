using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/Image/"+dosyaadi+uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var pers = c.Personels.Find(id);
            return View("PersonelGetir", pers);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (p.PersonelGorsel!=null)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "/Image/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
                }
            }
            var pers = c.Personels.Find(p.PersonelID);
            pers.PersonelAd = p.PersonelAd;
            pers.PersonelSoyad = p.PersonelSoyad;
            if (p.PersonelGorsel!=null)
            {
                pers.PersonelGorsel = p.PersonelGorsel;
            }
            pers.DepartmanId = p.DepartmanId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var deger = c.Personels.ToList();
            return View(deger);
        }
    }
}