using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AkaelApplication.Models
{
    public class AreaProcessoModelView
    {
        private DatabaseAkaelEntities db = new DatabaseAkaelEntities();

        public int IdAreaProcesso { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string SiglaNivelMaturidade { get; set; }
        public string NomeNivelMaturidade { get; set; }
        public string DescricaoNivelMaturidade { get; set; }

        public string NomeCategoria { get; set; }

        public string SiglaModelo { get; set; }
        public string NomeModelo { get; set; }
        public string DescricaoModelo { get; set; }

        public string SiglaMetaGenerica { get; set; }
        public string NomeMetaGenerica { get; set; }
        public string DescricaoMetaGenerica { get; set; }

        public string SiglaNivelCapacidade { get; set; }
        public string NomeNivelCapacidade { get; set; }
        public string DescricaoNivelCapacidade { get; set; }

        public string SiglaMetaEspecifica { get; set; }
        public string NomeMetaEspecifica { get; set; }
        public string DescricaoMetaEspecifica { get; set; }


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

        private ActionResult View(AreaProcessoModelView item)
        {
            throw new NotImplementedException();
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}