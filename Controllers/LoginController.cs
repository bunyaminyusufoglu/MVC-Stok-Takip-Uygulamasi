using StokTakip.Filters;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View(new Kullanicilar());
        }

        [HttpPost]
        public ActionResult SignIn(Kullanicilar model)
        {
            DatabaseContext db = new DatabaseContext();

            Kullanicilar user = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == model.KullaniciAdi && x.Sifre == model.Sifre);

            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                return View(model);
            }
            else
            {
                Session["Login"] = user;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}