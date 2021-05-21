using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var müsterimail = (string)Session["CariMail"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == müsterimail);
            ViewBag.m = müsterimail;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var müsterimail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == müsterimail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar()
        {
            var müsterimail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x=>x.MesajAlıcı==müsterimail).ToList();
            var gelensayi = c.Mesajlars.Count(x => x.MesajAlıcı==müsterimail).ToString();
            ViewBag.gelensayi = gelensayi;
            return View(mesajlar);
        }
        //[HttpGet]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
    }
}