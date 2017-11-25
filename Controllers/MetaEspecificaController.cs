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
    public class MetaEspecificaController : Controller
    {
        private DatabaseAkaelEntities db = new DatabaseAkaelEntities();

        // GET: MetaEspecifica
        public ActionResult Index()
        {
            var metaEspecifica = db.MetaEspecifica.Include(m => m.AreaProcesso);
            return View(metaEspecifica.ToList());
        }

        // GET: MetaEspecifica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaEspecifica metaEspecifica = db.MetaEspecifica.Find(id);
            if (metaEspecifica == null)
            {
                return HttpNotFound();
            }
            return View(metaEspecifica);
        }

        // GET: MetaEspecifica/Create
        public ActionResult Create()
        {
            ViewBag.IdAreaProcesso = new SelectList(db.AreaProcesso, "IdAreaProcesso", "Sigla");
            return View();
        }

        // POST: MetaEspecifica/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMetaEspecifica,Sigla,Nome,Descricao,IdAreaProcesso")] MetaEspecifica metaEspecifica)
        {
            if (ModelState.IsValid)
            {
                db.MetaEspecifica.Add(metaEspecifica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAreaProcesso = new SelectList(db.AreaProcesso, "IdAreaProcesso", "Sigla", metaEspecifica.IdAreaProcesso);
            return View(metaEspecifica);
        }

        // GET: MetaEspecifica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaEspecifica metaEspecifica = db.MetaEspecifica.Find(id);
            if (metaEspecifica == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAreaProcesso = new SelectList(db.AreaProcesso, "IdAreaProcesso", "Sigla", metaEspecifica.IdAreaProcesso);
            return View(metaEspecifica);
        }

        // POST: MetaEspecifica/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMetaEspecifica,Sigla,Nome,Descricao,IdAreaProcesso")] MetaEspecifica metaEspecifica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metaEspecifica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAreaProcesso = new SelectList(db.AreaProcesso, "IdAreaProcesso", "Sigla", metaEspecifica.IdAreaProcesso);
            return View(metaEspecifica);
        }

        // GET: MetaEspecifica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaEspecifica metaEspecifica = db.MetaEspecifica.Find(id);
            if (metaEspecifica == null)
            {
                return HttpNotFound();
            }
            return View(metaEspecifica);
        }

        // POST: MetaEspecifica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetaEspecifica metaEspecifica = db.MetaEspecifica.Find(id);
            db.MetaEspecifica.Remove(metaEspecifica);
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
