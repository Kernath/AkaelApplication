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
    public class AreaProcessoController : Controller
    {
        private DatabaseAkaelEntities db = new DatabaseAkaelEntities();

        // GET: AreaProcesso
        public ActionResult Index()
        {
            var areaProcesso = db.AreaProcesso.Include(a => a.Categoria).Include(a => a.Modelo).Include(a => a.NivelMaturidade);
            return View(areaProcesso.ToList());
        }

        // GET: AreaProcesso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = (from ap in db.AreaProcesso
                        join mg in db.MetaGenerica on ap.IdAreaProcesso equals mg.IdMetaGenerica
                        join model in db.Modelo on ap.IdAreaProcesso equals model.IdModelo
                        from nc in db.NivelCapacidade
                        from c in db.Categoria
                        join me in db.MetaEspecifica on ap.IdAreaProcesso equals me.IdAreaProcesso
                        where ap.IdAreaProcesso == id.Value
                        select new AreaProcessoModelView()
                        {
                            SiglaMetaGenerica = mg.Sigla,
                            NomeMetaGenerica = mg.Nome,
                            DescricaoMetaGenerica = mg.Descricao,
                            Sigla = ap.Sigla,
                            Nome = ap.Nome,
                            Descricao = ap.Descricao,
                            SiglaModelo = model.Sigla,
                            NomeModelo = model.Nome,
                            DescricaoModelo = model.Descricao,
                            SiglaNivelCapacidade = nc.Sigla,
                            NomeNivelCapacidade = nc.Nome,
                            DescricaoNivelCapacidade = nc.Descricao,
                            NomeCategoria = c.Nome,
                            SiglaMetaEspecifica = me.Sigla,
                            NomeMetaEspecifica = me.Nome,
                            DescricaoMetaEspecifica = me.Descricao
                        }).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();  // Or a return a view with message "item not found"
            }
            return View(item);
        }

        // GET: AreaProcesso/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nome");
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Sigla");
            ViewBag.IdNivelMaturidade = new SelectList(db.NivelMaturidade, "IdNivelMaturidade", "Sigla");
            return View();
        }

        // POST: AreaProcesso/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAreaProcesso,Sigla,Nome,Descricao,IdNivelMaturidade,IdCategoria,IdModelo")] AreaProcesso areaProcesso)
        {
            if (ModelState.IsValid)
            {
                db.AreaProcesso.Add(areaProcesso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nome", areaProcesso.IdCategoria);
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Sigla", areaProcesso.IdModelo);
            ViewBag.IdNivelMaturidade = new SelectList(db.NivelMaturidade, "IdNivelMaturidade", "Sigla", areaProcesso.IdNivelMaturidade);
            return View(areaProcesso);
        }

        // GET: AreaProcesso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaProcesso areaProcesso = db.AreaProcesso.Find(id);
            if (areaProcesso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nome", areaProcesso.IdCategoria);
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Sigla", areaProcesso.IdModelo);
            ViewBag.IdNivelMaturidade = new SelectList(db.NivelMaturidade, "IdNivelMaturidade", "Sigla", areaProcesso.IdNivelMaturidade);
            return View(areaProcesso);
        }

        // POST: AreaProcesso/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAreaProcesso,Sigla,Nome,Descricao,IdNivelMaturidade,IdCategoria,IdModelo")] AreaProcesso areaProcesso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaProcesso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nome", areaProcesso.IdCategoria);
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Sigla", areaProcesso.IdModelo);
            ViewBag.IdNivelMaturidade = new SelectList(db.NivelMaturidade, "IdNivelMaturidade", "Sigla", areaProcesso.IdNivelMaturidade);
            return View(areaProcesso);
        }

        // GET: AreaProcesso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaProcesso areaProcesso = db.AreaProcesso.Find(id);
            if (areaProcesso == null)
            {
                return HttpNotFound();
            }
            return View(areaProcesso);
        }

        // POST: AreaProcesso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaProcesso areaProcesso = db.AreaProcesso.Find(id);
            db.AreaProcesso.Remove(areaProcesso);
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
