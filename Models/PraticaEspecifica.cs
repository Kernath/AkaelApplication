//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AkaelApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PraticaEspecifica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PraticaEspecifica()
        {
            this.PraticaEspecificaProdutoTrabalho = new HashSet<PraticaEspecificaProdutoTrabalho>();
            this.ProdutoTrabalho = new HashSet<ProdutoTrabalho>();
        }
    
        public int IdPraticaEspecifica { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdMetaEspecifica { get; set; }
    
        public virtual MetaEspecifica MetaEspecifica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PraticaEspecificaProdutoTrabalho> PraticaEspecificaProdutoTrabalho { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdutoTrabalho> ProdutoTrabalho { get; set; }
    }
}
