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
    public class NivelMaturidadeController : Controller
    {
        private DatabaseAkaelEntities db = new DatabaseAkaelEntities();

        // GET: NivelMaturidade
        public ActionResult Index()
        {
            return View(db.NivelMaturidade.ToList());
        }

        // GET: NivelMaturidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelMaturidade nivelMaturidade = db.NivelMaturidade.Find(id);
            if (nivelMaturidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelMaturidade);
        }

        // GET: NivelMaturidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelMaturidade/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNivelMaturidade,Sigla,Nome,Descricao")] NivelMaturidade nivelMaturidade)
        {
            if (ModelState.IsValid)
            {
                db.NivelMaturidade.Add(nivelMaturidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivelMaturidade);
        }

        // GET: NivelMaturidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelMaturidade nivelMaturidade = db.NivelMaturidade.Find(id);
            if (nivelMaturidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelMaturidade);
        }

        // POST: NivelMaturidade/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNivelMaturidade,Sigla,Nome,Descricao")] NivelMaturidade nivelMaturidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivelMaturidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelMaturidade);
        }

        // GET: NivelMaturidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelMaturidade nivelMaturidade = db.NivelMaturidade.Find(id);
            if (nivelMaturidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelMaturidade);
        }

        // POST: NivelMaturidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NivelMaturidade nivelMaturidade = db.NivelMaturidade.Find(id);
            db.NivelMaturidade.Remove(nivelMaturidade);
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
