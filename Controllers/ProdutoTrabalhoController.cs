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
    public class ProdutoTrabalhoController : Controller
    {
        private DatabaseAkaelEntities db = new DatabaseAkaelEntities();

        // GET: ProdutoTrabalho
        public ActionResult Index()
        {
            var produtoTrabalho = db.ProdutoTrabalho.Include(p => p.PraticaEspecifica);
            return View(produtoTrabalho.ToList());
        }

        // GET: ProdutoTrabalho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoTrabalho produtoTrabalho = db.ProdutoTrabalho.Find(id);
            if (produtoTrabalho == null)
            {
                return HttpNotFound();
            }
            return View(produtoTrabalho);
        }

        // GET: ProdutoTrabalho/Create
        public ActionResult Create()
        {
            ViewBag.IdPraticaEspecifica = new SelectList(db.PraticaEspecifica, "IdPraticaEspecifica", "Sigla");
            return View();
        }

        // POST: ProdutoTrabalho/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProdutoTrabalho,Nome,Template,IdPraticaEspecifica")] ProdutoTrabalho produtoTrabalho)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoTrabalho.Add(produtoTrabalho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPraticaEspecifica = new SelectList(db.PraticaEspecifica, "IdPraticaEspecifica", "Sigla", produtoTrabalho.IdPraticaEspecifica);
            return View(produtoTrabalho);
        }

        // GET: ProdutoTrabalho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoTrabalho produtoTrabalho = db.ProdutoTrabalho.Find(id);
            if (produtoTrabalho == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPraticaEspecifica = new SelectList(db.PraticaEspecifica, "IdPraticaEspecifica", "Sigla", produtoTrabalho.IdPraticaEspecifica);
            return View(produtoTrabalho);
        }

        // POST: ProdutoTrabalho/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProdutoTrabalho,Nome,Template,IdPraticaEspecifica")] ProdutoTrabalho produtoTrabalho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoTrabalho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPraticaEspecifica = new SelectList(db.PraticaEspecifica, "IdPraticaEspecifica", "Sigla", produtoTrabalho.IdPraticaEspecifica);
            return View(produtoTrabalho);
        }

        // GET: ProdutoTrabalho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoTrabalho produtoTrabalho = db.ProdutoTrabalho.Find(id);
            if (produtoTrabalho == null)
            {
                return HttpNotFound();
            }
            return View(produtoTrabalho);
        }

        // POST: ProdutoTrabalho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoTrabalho produtoTrabalho = db.ProdutoTrabalho.Find(id);
            db.ProdutoTrabalho.Remove(produtoTrabalho);
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
