using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StokTakip.Filters;
using StokTakip.Models;

namespace StokTakip.Controllers
{
    [AuthorizationFilter]
    public class SatislarController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Satislar
        public ActionResult Index()
        {
            var satislar = db.Satislar.Include(s => s.Musteri).Include(s => s.Urun);
            return View(satislar.ToList());
        }

        // GET: Satislar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Satislar satislar = db.Satislar.Find(id);

            if (satislar == null)
            {
                return HttpNotFound();
            }

            Musteriler musteri = db.Musteriler.Find(satislar.MusteriId);
            if (musteri != null)
            {
                ViewBag.MusteriAdi = musteri.Adi;
            }
            else
            {
                ViewBag.MusteriAdi = "Bilinmeyen Müşteri";
            }

            Urunler urun = db.Urunler.Find(satislar.UrunId);
            if (urun != null)
            {
                ViewBag.UrunAdi = urun.UrunAdi;
            }
            else
            {
                ViewBag.UrunAdi = "Bilinmeyen Müşteri";
            }


            return View(satislar);
        }


        // GET: Satislar/Create
        public ActionResult Create()
        {
            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "Adi");
            ViewBag.UrunId = new SelectList(db.Urunler, "Id", "UrunAdi");
            return View();
        }

        // POST: Satislar/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MusteriId,UrunId,Adet,Tarih")] Satislar satislar)
        {
            if (ModelState.IsValid)
            {
                var urun = db.Urunler.FirstOrDefault(u => u.Id == satislar.UrunId);

                if (urun != null)
                {
                    urun.Stok -= satislar.Adet;

                    db.Entry(urun).State = EntityState.Modified;
                }


                db.Satislar.Add(satislar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "Adi", satislar.MusteriId);
            ViewBag.UrunId = new SelectList(db.Urunler, "Id", "UrunAdi", satislar.UrunId);
            return View(satislar);
        }

        // GET: Satislar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satislar satislar = db.Satislar.Find(id);
            if (satislar == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "Adi", satislar.MusteriId);
            ViewBag.UrunId = new SelectList(db.Urunler, "Id", "UrunAdi", satislar.UrunId);
            return View(satislar);
        }

        // POST: Satislar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MusteriId,UrunId,Adet,Tarih")] Satislar satislar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satislar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "Adi", satislar.MusteriId);
            ViewBag.UrunId = new SelectList(db.Urunler, "Id", "UrunAdi", satislar.UrunId);
            return View(satislar);
        }

        // GET: Satislar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satislar satislar = db.Satislar.Find(id);
            if (satislar == null)
            {
                return HttpNotFound();
            }

            Musteriler musteri = db.Musteriler.Find(satislar.MusteriId);
            if (musteri != null)
            {
                ViewBag.MusteriAdi = musteri.Adi;
            }
            else
            {
                ViewBag.MusteriAdi = "Bilinmeyen Müşteri";
            }

            Urunler urun = db.Urunler.Find(satislar.UrunId);
            if (urun != null)
            {
                ViewBag.UrunAdi = urun.UrunAdi;
            }
            else
            {
                ViewBag.UrunAdi = "Bilinmeyen Müşteri";
            }

            return View(satislar);
        }

        // POST: Satislar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Satislar satislar = db.Satislar.Find(id);
            db.Satislar.Remove(satislar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
