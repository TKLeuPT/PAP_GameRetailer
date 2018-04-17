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
    public class ViaturasController : Controller
    {
        private GameRetailerEntities db = new GameRetailerEntities();

        // GET: Viaturas
        public ActionResult Index()
        {
            return View(db.Viatura.ToList());
        }

        // GET: Viaturas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viatura viatura = db.Viatura.Find(id);
            if (viatura == null)
            {
                return HttpNotFound();
            }
            return View(viatura);
        }

        // GET: Viaturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Viaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Matricula,Marca,Modelo,Kms")] Viatura viatura)
        {
            if (ModelState.IsValid)
            {
                db.Viatura.Add(viatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viatura);
        }

        // GET: Viaturas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viatura viatura = db.Viatura.Find(id);
            if (viatura == null)
            {
                return HttpNotFound();
            }
            return View(viatura);
        }

        // POST: Viaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Matricula,Marca,Modelo,Kms")] Viatura viatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viatura);
        }

        // GET: Viaturas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viatura viatura = db.Viatura.Find(id);
            if (viatura == null)
            {
                return HttpNotFound();
            }
            return View(viatura);
        }

        // POST: Viaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Viatura viatura = db.Viatura.Find(id);
            db.Viatura.Remove(viatura);
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
