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
    public class CabecalhoGuiasController : Controller
    {
        private GameRetailerEntities db = new GameRetailerEntities();

        // GET: CabecalhoGuias
        public ActionResult Index()
        {
            var cabecalhoGuia = db.CabecalhoGuia.Include(c => c.Armazem).Include(c => c.Cliente).Include(c => c.Distribuidor).Include(c => c.Viatura);
            return View(cabecalhoGuia.ToList());
        }

        // GET: CabecalhoGuias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabecalhoGuia cabecalhoGuia = db.CabecalhoGuia.Find(id);
            if (cabecalhoGuia == null)
            {
                return HttpNotFound();
            }
            return View(cabecalhoGuia);
        }

        // GET: CabecalhoGuias/Create
        public ActionResult Create()
        {
            ViewBag.CodArmazem = new SelectList(db.Armazem, "CodArmazem", "Nome");
            ViewBag.NumCliente = new SelectList(db.Cliente, "NumCliente", "Nome");
            ViewBag.CodDistribuidor = new SelectList(db.Distribuidor, "CodDistribuidor", "Nome");
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula");
            return View();
        }

        // POST: CabecalhoGuias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumGuia,DataEmissao,CodArmazem,Matricula,NumCliente,CodDistribuidor")] CabecalhoGuia cabecalhoGuia)
        {
            if (ModelState.IsValid)
            {
                db.CabecalhoGuia.Add(cabecalhoGuia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodArmazem = new SelectList(db.Armazem, "CodArmazem", "Nome", cabecalhoGuia.CodArmazem);
            ViewBag.NumCliente = new SelectList(db.Cliente, "NumCliente", "Nome", cabecalhoGuia.NumCliente);
            ViewBag.CodDistribuidor = new SelectList(db.Distribuidor, "CodDistribuidor", "Nome", cabecalhoGuia.CodDistribuidor);
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula", cabecalhoGuia.Matricula);
            return View(cabecalhoGuia);
        }

        // GET: CabecalhoGuias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabecalhoGuia cabecalhoGuia = db.CabecalhoGuia.Find(id);
            if (cabecalhoGuia == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodArmazem = new SelectList(db.Armazem, "CodArmazem", "Nome", cabecalhoGuia.CodArmazem);
            ViewBag.NumCliente = new SelectList(db.Cliente, "NumCliente", "Nome", cabecalhoGuia.NumCliente);
            ViewBag.CodDistribuidor = new SelectList(db.Distribuidor, "CodDistribuidor", "Nome", cabecalhoGuia.CodDistribuidor);
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula", cabecalhoGuia.Matricula);
            return View(cabecalhoGuia);
        }

        // POST: CabecalhoGuias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumGuia,DataEmissao,CodArmazem,Matricula,NumCliente,CodDistribuidor")] CabecalhoGuia cabecalhoGuia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cabecalhoGuia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodArmazem = new SelectList(db.Armazem, "CodArmazem", "Nome", cabecalhoGuia.CodArmazem);
            ViewBag.NumCliente = new SelectList(db.Cliente, "NumCliente", "Nome", cabecalhoGuia.NumCliente);
            ViewBag.CodDistribuidor = new SelectList(db.Distribuidor, "CodDistribuidor", "Nome", cabecalhoGuia.CodDistribuidor);
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula", cabecalhoGuia.Matricula);
            return View(cabecalhoGuia);
        }

        // GET: CabecalhoGuias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabecalhoGuia cabecalhoGuia = db.CabecalhoGuia.Find(id);
            if (cabecalhoGuia == null)
            {
                return HttpNotFound();
            }
            return View(cabecalhoGuia);
        }

        // POST: CabecalhoGuias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CabecalhoGuia cabecalhoGuia = db.CabecalhoGuia.Find(id);
            db.CabecalhoGuia.Remove(cabecalhoGuia);
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

        public JsonResult FetchGuias() // its a GET, not a POST
        {
            db.Configuration.ProxyCreationEnabled = false;
            var guias = db.CabecalhoGuia.Select(d => new
            {
                ID = d.NumGuia,
                d.Viatura,
                d.Armazem,
                d.Distribuidor,
                d.DetalheGuia,
                d.DataEmissao,
                d.Cliente
            });

            return Json(guias, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FetchGuiasById(int id) // its a GET, not a POST
        {
            db.Configuration.ProxyCreationEnabled = false;
            var guias = db.CabecalhoGuia.Select(d => new
            {
                ID = d.NumGuia,
                d.Viatura,
                d.Armazem,
                d.Distribuidor,
                d.DetalheGuia,
                d.DataEmissao,
                d.Cliente
            }).Where(x => x.ID == id);

            return Json(guias, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FetchDetalhesById(int id) // its a GET, not a POST
        {
            db.Configuration.ProxyCreationEnabled = false;
            var guias = db.DetalheGuia.Select(d => new
            {
                ID = d.NumGuia,
               d.Quantidade,
                d.Jogo,
                d.CodBarras,
                d.NumDGuia,




            }).Where(x => x.ID == id);

            return Json(guias, JsonRequestBehavior.AllowGet);
        }
    }
}
