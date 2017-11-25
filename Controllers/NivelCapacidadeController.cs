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
    public class NivelCapacidadeController : Controller
    {
        private DatabaseAkaelEntities db = new DatabaseAkaelEntities();

        // GET: NivelCapacidade
        public ActionResult Index()
        {
            return View(db.NivelCapacidade.ToList());
        }

        // GET: NivelCapacidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelCapacidade nivelCapacidade = db.NivelCapacidade.Find(id);
            if (nivelCapacidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelCapacidade);
        }

        // GET: NivelCapacidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelCapacidade/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNivelCapacidade,Sigla,Nome,Descricao")] NivelCapacidade nivelCapacidade)
        {
            if (ModelState.IsValid)
            {
                db.NivelCapacidade.Add(nivelCapacidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivelCapacidade);
        }

        // GET: NivelCapacidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelCapacidade nivelCapacidade = db.NivelCapacidade.Find(id);
            if (nivelCapacidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelCapacidade);
        }

        // POST: NivelCapacidade/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNivelCapacidade,Sigla,Nome,Descricao")] NivelCapacidade nivelCapacidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivelCapacidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelCapacidade);
        }

        // GET: NivelCapacidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelCapacidade nivelCapacidade = db.NivelCapacidade.Find(id);
            if (nivelCapacidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelCapacidade);
        }

        // POST: NivelCapacidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NivelCapacidade nivelCapacidade = db.NivelCapacidade.Find(id);
            db.NivelCapacidade.Remove(nivelCapacidade);
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
