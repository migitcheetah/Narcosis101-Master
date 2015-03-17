using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Narcosis101.Models;
using ItemContext = Narcosis101.DAL.ItemContext;

namespace Narcosis101.Controllers
{
    public class LensCRUDController : Controller
    {
        private ItemContext db = new ItemContext();
        // GET: LenseCRUD
        public ActionResult Index()
        {
            return View(db.Lenses.ToList());
        }

        // GET: LensesCrud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lense lens = db.Lenses.Find(id);
            if (lens == null)
            {
                return HttpNotFound();
            }
            return View(lens);
        }

        // GET: LensesCrud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LensesCrud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LenseId,AuthorId,Title,Year")] Lense lens)
        {
            if (ModelState.IsValid)
            {
                db.Lenses.Add(lens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lens);
        }

        // GET: LensesCrud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lense lens = db.Lenses.Find(id);
            if (lens == null)
            {
                return HttpNotFound();
            }
            return View(lens);
        }

        // POST: LensesCrud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LenseId,AuthorId,Title,Year")] Lense lens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lens);
        }

        // GET: LensesCrud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lense lens = db.Lenses.Find(id);
            if (lens == null)
            {
                return HttpNotFound();
            }
            return View(lens);
        }

        // POST: LensesCrud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lense lens = db.Lenses.Find(id);
            db.Lenses.Remove(lens);
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
