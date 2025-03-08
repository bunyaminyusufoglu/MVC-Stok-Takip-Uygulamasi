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
    public class MusterilerController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Musteriler
        public ActionResult Index()
        {
            return View(db.Musteriler.ToList());
        }

        // GET: Musteriler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musteriler.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // GET: Musteriler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musteriler/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adi,Soyadi,Telefon,Borc")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                db.Musteriler.Add(musteriler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musteriler);
        }

        // GET: Musteriler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musteriler.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // POST: Musteriler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adi,Soyadi,Telefon,Borc")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteriler);
        }

        // GET: Musteriler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musteriler.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // POST: Musteriler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteriler musteriler = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteriler);
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
