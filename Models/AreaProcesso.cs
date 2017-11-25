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

    public partial class AreaProcesso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AreaProcesso()
        {
            this.MetaEspecifica = new HashSet<MetaEspecifica>();
        }
    
        public int IdAreaProcesso { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdNivelMaturidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdModelo { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual NivelMaturidade NivelMaturidade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MetaEspecifica> MetaEspecifica { get; set; }
    }
}
