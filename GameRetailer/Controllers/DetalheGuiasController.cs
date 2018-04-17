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
    public class DetalheGuiasController : Controller
    {
        private GameRetailerEntities db = new GameRetailerEntities();

        // GET: DetalheGuias
        public ActionResult Index()
        {
            var detalheGuia = db.DetalheGuia.Include(d => d.CabecalhoGuia).Include(d => d.Jogo);
            return View(detalheGuia.ToList());
        }

        // GET: DetalheGuias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalheGuia detalheGuia = db.DetalheGuia.Find(id);
            if (detalheGuia == null)
            {
                return HttpNotFound();
            }
            return View(detalheGuia);
        }

        // GET: DetalheGuias/Create
        public ActionResult Create()
        {
            ViewBag.NumGuia = new SelectList(db.CabecalhoGuia, "NumGuia", "NumGuia");
            ViewBag.CodBarras = new SelectList(db.Jogo, "CodBarras", "CodBarras");
            return View();
        }

        // POST: DetalheGuias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumDGuia,CodBarras,Quantidade,NumGuia")] DetalheGuia detalheGuia)
        {
            if (ModelState.IsValid)
            {
                db.DetalheGuia.Add(detalheGuia);
                db.SaveChanges();
                return RedirectToAction("Index","CabecalhoGuias");
            }

            ViewBag.NumGuia = new SelectList(db.CabecalhoGuia, "NumGuia", "NumGuia", detalheGuia.NumGuia);
            ViewBag.CodBarras = new SelectList(db.Jogo, "CodBarras", "CodBarras", detalheGuia.CodBarras);
            return View(detalheGuia);
        }

        // GET: DetalheGuias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalheGuia detalheGuia = db.DetalheGuia.Find(id);
            if (detalheGuia == null)
            {
                return HttpNotFound();
            }
            ViewBag.NumGuia = new SelectList(db.CabecalhoGuia, "NumGuia", "NumGuia", detalheGuia.NumGuia);
            ViewBag.CodBarras = new SelectList(db.Jogo, "CodBarras", "CodBarras", detalheGuia.CodBarras);
            return View(detalheGuia);
        }

        // POST: DetalheGuias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumDGuia,CodBarras,Quantidade,NumGuia")] DetalheGuia detalheGuia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalheGuia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","CabecalhoGuias");
            }
            ViewBag.NumGuia = new SelectList(db.CabecalhoGuia, "NumGuia", "NumGuia", detalheGuia.NumGuia);
            ViewBag.CodBarras = new SelectList(db.Jogo, "CodBarras", "CodBarras", detalheGuia.CodBarras);
            return View(detalheGuia);
        }

        // GET: DetalheGuias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalheGuia detalheGuia = db.DetalheGuia.Find(id);
            if (detalheGuia == null)
            {
                return HttpNotFound();
            }
            return View(detalheGuia);
        }

        // POST: DetalheGuias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalheGuia detalheGuia = db.DetalheGuia.Find(id);
            db.DetalheGuia.Remove(detalheGuia);
            db.SaveChanges();
            return RedirectToAction("Index", "CabecalhoGuias");
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
