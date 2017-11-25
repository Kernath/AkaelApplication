using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AkaelApplication.Models;

namespace AkaelApplication.Controllers
{
    public class PraticaEspecificaController : Controller
    {
        private DatabaseAkaelEntities db = new DatabaseAkaelEntities();

        // GET: PraticaEspecifica
        public ActionResult Index()
        {
            var praticaEspecifica = db.PraticaEspecifica.Include(p => p.MetaEspecifica);
            return View(praticaEspecifica.ToList());
        }

        // GET: PraticaEspecifica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PraticaEspecifica praticaEspecifica = db.PraticaEspecifica.Find(id);
            if (praticaEspecifica == null)
            {
                return HttpNotFound();
            }
            return View(praticaEspecifica);
        }

        // GET: PraticaEspecifica/Create
        public ActionResult Create()
        {
            ViewBag.IdMetaEspecifica = new SelectList(db.MetaEspecifica, "IdMetaEspecifica", "Sigla");
            return View();
        }

        // POST: PraticaEspecifica/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPraticaEspecifica,Sigla,Nome,Descricao,IdMetaEspecifica")] PraticaEspecifica praticaEspecifica)
        {
            if (ModelState.IsValid)
            {
                db.PraticaEspecifica.Add(praticaEspecifica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMetaEspecifica = new SelectList(db.MetaEspecifica, "IdMetaEspecifica", "Sigla", praticaEspecifica.IdMetaEspecifica);
            return View(praticaEspecifica);
        }

        // GET: PraticaEspecifica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PraticaEspecifica praticaEspecifica = db.PraticaEspecifica.Find(id);
            if (praticaEspecifica == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMetaEspecifica = new SelectList(db.MetaEspecifica, "IdMetaEspecifica", "Sigla", praticaEspecifica.IdMetaEspecifica);
            return View(praticaEspecifica);
        }

        // POST: PraticaEspecifica/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPraticaEspecifica,Sigla,Nome,Descricao,IdMetaEspecifica")] PraticaEspecifica praticaEspecifica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(praticaEspecifica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMetaEspecifica = new SelectList(db.MetaEspecifica, "IdMetaEspecifica", "Sigla", praticaEspecifica.IdMetaEspecifica);
            return View(praticaEspecifica);
        }

        // GET: PraticaEspecifica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PraticaEspecifica praticaEspecifica = db.PraticaEspecifica.Find(id);
            if (praticaEspecifica == null)
            {
                return HttpNotFound();
            }
            return View(praticaEspecifica);
        }

        // POST: PraticaEspecifica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PraticaEspecifica praticaEspecifica = db.PraticaEspecifica.Find(id);
            db.PraticaEspecifica.Remove(praticaEspecifica);
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
