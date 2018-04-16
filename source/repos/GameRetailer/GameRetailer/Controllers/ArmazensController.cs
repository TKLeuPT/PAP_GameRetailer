using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameRetailer.Models;
using Microsoft.AspNet.Identity;

namespace GameRetailer.Controllers
{
    public class ArmazensController : Controller
    {
        private GameRetailerEntities db = new GameRetailerEntities();

        // GET: Armazems
        public ActionResult Index()
        {
            var armazem = db.Armazem.Include(a => a.Login);
            return View(armazem.ToList());
        }

        // GET: Armazems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armazem armazem = db.Armazem.Find(id);
            if (armazem == null)
            {
                return HttpNotFound();
            }
            return View(armazem);
        }

        // GET: Armazems/Create
        public ActionResult Create()
        {
            ViewBag.Dono = new SelectList(db.Login, "ID", "ID");
            return View();
        }

        // POST: Armazems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodArmazem,CodPostal,Nome,Morada,Localidade,Dono")] Armazem armazem,Login login)
        {
            if (ModelState.IsValid)
                {
                    db.Armazem.Add(armazem);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            ViewBag.Dono = new SelectList(db.Login, "ID", "ID", armazem.Dono);
            return View(armazem);
        }
        // GET: Armazems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armazem armazem = db.Armazem.Find(id);
            if (armazem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dono = new SelectList(db.Login, "ID", "ID", armazem.Dono);
            return View(armazem);
        }

        // POST: Armazems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodArmazem,CodPostal,Nome,Morada,Localidade,Dono")] Armazem armazem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(armazem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dono = new SelectList(db.Login, "ID", "ID", armazem.Dono);
            return View(armazem);
        }

        // GET: Armazems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armazem armazem = db.Armazem.Find(id);
            if (armazem == null)
            {
                return HttpNotFound();
            }
            return View(armazem);
        }

        // POST: Armazems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armazem armazem = db.Armazem.Find(id);
            db.Armazem.Remove(armazem);
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
