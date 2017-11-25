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
    public class PraticaEspecificaProdutoTrabalhoController : Controller
    {
        private DatabaseAkaelEntities db = new DatabaseAkaelEntities();

        // GET: PraticaEspecificaProdutoTrabalho
        public ActionResult Index()
        {
            var praticaEspecificaProdutoTrabalho = db.PraticaEspecificaProdutoTrabalho.Include(p => p.PraticaEspecifica).Include(p => p.ProdutoTrabalho);
            return View(praticaEspecificaProdutoTrabalho.ToList());
        }

        // GET: PraticaEspecificaProdutoTrabalho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PraticaEspecificaProdutoTrabalho praticaEspecificaProdutoTrabalho = db.PraticaEspecificaProdutoTrabalho.Find(id);
            if (praticaEspecificaProdutoTrabalho == null)
            {
                return HttpNotFound();
            }
            return View(praticaEspecificaProdutoTrabalho);
        }

        // GET: PraticaEspecificaProdutoTrabalho/Create
        public ActionResult Create()
        {
            ViewBag.IdPraticaEspecifica = new SelectList(db.PraticaEspecifica, "IdPraticaEspecifica", "Sigla");
            ViewBag.IdProdutoTrabalho = new SelectList(db.ProdutoTrabalho, "IdProdutoTrabalho", "Nome");
            return View();
        }

        // POST: PraticaEspecificaProdutoTrabalho/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPraticaEspecificaProdutoTrabalho,IdPraticaEspecifica,IdProdutoTrabalho")] PraticaEspecificaProdutoTrabalho praticaEspecificaProdutoTrabalho)
        {
            if (ModelState.IsValid)
            {
                db.PraticaEspecificaProdutoTrabalho.Add(praticaEspecificaProdutoTrabalho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPraticaEspecifica = new SelectList(db.PraticaEspecifica, "IdPraticaEspecifica", "Sigla", praticaEspecificaProdutoTrabalho.IdPraticaEspecifica);
            ViewBag.IdProdutoTrabalho = new SelectList(db.ProdutoTrabalho, "IdProdutoTrabalho", "Nome", praticaEspecificaProdutoTrabalho.IdProdutoTrabalho);
            return View(praticaEspecificaProdutoTrabalho);
        }

        // GET: PraticaEspecificaProdutoTrabalho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PraticaEspecificaProdutoTrabalho praticaEspecificaProdutoTrabalho = db.PraticaEspecificaProdutoTrabalho.Find(id);
            if (praticaEspecificaProdutoTrabalho == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPraticaEspecifica = new SelectList(db.PraticaEspecifica, "IdPraticaEspecifica", "Sigla", praticaEspecificaProdutoTrabalho.IdPraticaEspecifica);
            ViewBag.IdProdutoTrabalho = new SelectList(db.ProdutoTrabalho, "IdProdutoTrabalho", "Nome", praticaEspecificaProdutoTrabalho.IdProdutoTrabalho);
            return View(praticaEspecificaProdutoTrabalho);
        }

        // POST: PraticaEspecificaProdutoTrabalho/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPraticaEspecificaProdutoTrabalho,IdPraticaEspecifica,IdProdutoTrabalho")] PraticaEspecificaProdutoTrabalho praticaEspecificaProdutoTrabalho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(praticaEspecificaProdutoTrabalho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPraticaEspecifica = new SelectList(db.PraticaEspecifica, "IdPraticaEspecifica", "Sigla", praticaEspecificaProdutoTrabalho.IdPraticaEspecifica);
            ViewBag.IdProdutoTrabalho = new SelectList(db.ProdutoTrabalho, "IdProdutoTrabalho", "Nome", praticaEspecificaProdutoTrabalho.IdProdutoTrabalho);
            return View(praticaEspecificaProdutoTrabalho);
        }

        // GET: PraticaEspecificaProdutoTrabalho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PraticaEspecificaProdutoTrabalho praticaEspecificaProdutoTrabalho = db.PraticaEspecificaProdutoTrabalho.Find(id);
            if (praticaEspecificaProdutoTrabalho == null)
            {
                return HttpNotFound();
            }
            return View(praticaEspecificaProdutoTrabalho);
        }

        // POST: PraticaEspecificaProdutoTrabalho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PraticaEspecificaProdutoTrabalho praticaEspecificaProdutoTrabalho = db.PraticaEspecificaProdutoTrabalho.Find(id);
            db.PraticaEspecificaProdutoTrabalho.Remove(praticaEspecificaProdutoTrabalho);
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
