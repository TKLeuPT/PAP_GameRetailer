using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameRetailer.Models;

namespace GameRetailer.Controllers
{
    public class DistribuidoresController : Controller
    {
        private GameRetailerEntities db = new GameRetailerEntities();

        // GET: Distribuidors
        public ActionResult Index()
        {
            return View(db.Distribuidor.ToList());
        }

        // GET: Distribuidors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidor distribuidor = db.Distribuidor.Find(id);
            if (distribuidor == null)
            {
                return HttpNotFound();
            }
            return View(distribuidor);
        }

        // GET: Distribuidors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distribuidors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodDistribuidor,Nome,Telemovel,Email")] Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                db.Distribuidor.Add(distribuidor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distribuidor);
        }

        // GET: Distribuidors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidor distribuidor = db.Distribuidor.Find(id);
            if (distribuidor == null)
            {
                return HttpNotFound();
            }
            return View(distribuidor);
        }

        // POST: Distribuidors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodDistribuidor,Nome,Telemovel,Email")] Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distribuidor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distribuidor);
        }

        // GET: Distribuidors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidor distribuidor = db.Distribuidor.Find(id);
            if (distribuidor == null)
            {
                return HttpNotFound();
            }
            return View(distribuidor);
        }

        // POST: Distribuidors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distribuidor distribuidor = db.Distribuidor.Find(id);
            db.Distribuidor.Remove(distribuidor);
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
