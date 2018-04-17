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
    public class ComprasController : Controller
    {
        private GameRetailerEntities db = new GameRetailerEntities();

        // GET: Compras
        public ActionResult Index()
        {
            var compra = db.Compra.Include(c => c.Armazem).Include(c => c.Jogo);
            return View(compra.ToList());
        }

        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);

        }
        //// POST: Stocks/Delete/5
        [HttpPost, ActionName("Buy")]
        [ValidateAntiForgeryToken]
        public ActionResult BuyConfirmed(int id)
        {
            Stock stock = db.Stock.Find(id);
            Compra compra = db.Compra.Find(id);
            stock.Quantidade = stock.Quantidade - compra.Quantidade;
            db.Compra.Add(compra);
            db.SaveChanges();
            return RedirectToAction("List");

        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.NumArmazem = new SelectList(db.Armazem, "CodArmazem", "CodPostal");
            ViewBag.CodBarras = new SelectList(db.Jogo, "CodBarras", "Nome");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumCompra,DataCompra,NumArmazem,CodBarras,Quantidade")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NumArmazem = new SelectList(db.Armazem, "CodArmazem", "CodPostal", compra.NumArmazem);
            ViewBag.CodBarras = new SelectList(db.Jogo, "CodBarras", "Nome", compra.CodBarras);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.NumArmazem = new SelectList(db.Armazem, "CodArmazem", "CodPostal", compra.NumArmazem);
            ViewBag.CodBarras = new SelectList(db.Jogo, "CodBarras", "Nome", compra.CodBarras);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumCompra,DataCompra,NumArmazem,CodBarras,Quantidade")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NumArmazem = new SelectList(db.Armazem, "CodArmazem", "CodPostal", compra.NumArmazem);
            ViewBag.CodBarras = new SelectList(db.Jogo, "CodBarras", "Nome", compra.CodBarras);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compra.Find(id);
            db.Compra.Remove(compra);
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
