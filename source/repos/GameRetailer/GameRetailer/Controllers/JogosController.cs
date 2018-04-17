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
    public class JogosController : Controller
    {
        private GameRetailerEntities db = new GameRetailerEntities();

        // GET: Jogos
        public ActionResult Index()
        {
            var jogo = db.Jogo.Include(j => j.Armazem);
            return View(jogo.ToList());
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogo.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            ViewBag.NumDArmazem = new SelectList(db.Armazem, "CodArmazem", "CodArmazem");
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodBarras,Criadora,Categoria,AnoLancamento,Preco,Nome,NumDArmazem")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                db.Jogo.Add(jogo);
                db.SaveChanges();
                return RedirectToAction("Create","Stocks");
            }

            ViewBag.NumDArmazem = new SelectList(db.Armazem, "CodArmazem", "CodArmazem", jogo.NumDArmazem);
            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogo.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.NumDArmazem = new SelectList(db.Armazem, "CodArmazem", "CodArmazem", jogo.NumDArmazem);
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodBarras,Criadora,Categoria,AnoLancamento,Preco,Nome,NumDArmazem")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NumDArmazem = new SelectList(db.Armazem, "CodArmazem", "CodArmazem", jogo.NumDArmazem);
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogo.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogo jogo = db.Jogo.Find(id);
            db.Jogo.Remove(jogo);
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
