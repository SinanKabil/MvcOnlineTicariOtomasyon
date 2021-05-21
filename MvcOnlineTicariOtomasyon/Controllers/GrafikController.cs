using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(height: 600, width: 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xValue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(x => yValue.Add(x.UrunStok));
            var grafik = new Chart(width: 500, height: 500).AddTitle("Ürün - Stok Grafiği").AddSeries(chartType: "Column", name: "Stok", xValue: xValue, yValues: yValue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif1> UrunListesi()
        {
            List<Sinif1> snf = new List<Sinif1>();
            using (var c=new Context())
            {
                snf = c.Uruns.Select(x => new Sinif1
                {
                    urunad = x.UrunAd,
                    stok = x.UrunStok
                }).ToList();
            }
            return snf;
        }

    }
}