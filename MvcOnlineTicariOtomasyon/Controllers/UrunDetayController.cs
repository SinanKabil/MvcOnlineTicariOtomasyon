﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs1 = new Class1();
            //var degerler = c.Uruns.Where(x => x.UrunID == 1).ToList();
            cs1.Deger1 = c.Uruns.Where(x => x.UrunID == 1).ToList();
            cs1.Deger2 = c.Detays.Where(x => x.DetayID == 1).ToList();
            return View(cs1);
        }
    }
}