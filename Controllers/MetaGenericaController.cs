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
    public class MetaGenericaController : Controller
    {
        private DatabaseAkaelEntities db = new DatabaseAkaelEntities();

        // GET: MetaGenerica
        public ActionResult Index()
        {
            var metaGenerica = db.MetaGenerica.Include(m => m.Modelo).Include(m => m.NivelCapacidade);
            return View(metaGenerica.ToList());
        }

        // GET: MetaGenerica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaGenerica metaGenerica = db.MetaGenerica.Find(id);
            if (metaGenerica == null)
            {
                return HttpNotFound();
            }
            return View(metaGenerica);
        }

        // GET: MetaGenerica/Create
        public ActionResult Create()
        {
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Sigla");
            ViewBag.IdNivelCapacidade = new SelectList(db.NivelCapacidade, "IdNivelCapacidade", "Sigla");
            return View();
        }

        // POST: MetaGenerica/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMetaGenerica,Sigla,Nome,Descricao,IdNivelCapacidade,IdModelo")] MetaGenerica metaGenerica)
        {
            if (ModelState.IsValid)
            {
                db.MetaGenerica.Add(metaGenerica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Sigla", metaGenerica.IdModelo);
            ViewBag.IdNivelCapacidade = new SelectList(db.NivelCapacidade, "IdNivelCapacidade", "Sigla", metaGenerica.IdNivelCapacidade);
            return View(metaGenerica);
        }

        // GET: MetaGenerica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaGenerica metaGenerica = db.MetaGenerica.Find(id);
            if (metaGenerica == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Sigla", metaGenerica.IdModelo);
            ViewBag.IdNivelCapacidade = new SelectList(db.NivelCapacidade, "IdNivelCapacidade", "Sigla", metaGenerica.IdNivelCapacidade);
            return View(metaGenerica);
        }

        // POST: MetaGenerica/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMetaGenerica,Sigla,Nome,Descricao,IdNivelCapacidade,IdModelo")] MetaGenerica metaGenerica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metaGenerica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Sigla", metaGenerica.IdModelo);
            ViewBag.IdNivelCapacidade = new SelectList(db.NivelCapacidade, "IdNivelCapacidade", "Sigla", metaGenerica.IdNivelCapacidade);
            return View(metaGenerica);
        }

        // GET: MetaGenerica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaGenerica metaGenerica = db.MetaGenerica.Find(id);
            if (metaGenerica == null)
            {
                return HttpNotFound();
            }
            return View(metaGenerica);
        }

        // POST: MetaGenerica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetaGenerica metaGenerica = db.MetaGenerica.Find(id);
            db.MetaGenerica.Remove(metaGenerica);
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
