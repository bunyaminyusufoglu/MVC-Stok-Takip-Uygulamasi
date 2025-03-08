using StokTakip.Filters;
using StokTakip.Models;
using StokTakip.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.Controllers
{
    [AuthorizationFilter]
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        HomePageViewModel model = new HomePageViewModel();

        // GET: Home
        public ActionResult Index()
        {
            model.Urunler = db.Urunler.ToList();
            model.Musteriler = db.Musteriler.ToList();
            model.Satislar = db.Satislar.ToList();

            int ToplamBorc = 0;
            int ToplamStok = 0;

            foreach (var item in model.Musteriler)
            {
                ToplamBorc += item.Borc;
            }

            foreach (var item in model.Urunler)
            {
                ToplamStok += item.Stok;
            }

            ViewBag.UrunSayisi = model.Urunler.Count();
            ViewBag.MusteriSayisi = model.Musteriler.Count();
            ViewBag.SatisSayisi = model.Satislar.Count();
            ViewBag.ToplamBorc = ToplamBorc;
            ViewBag.ToplamStok = ToplamStok;

            return View(model);
        }
    }
}