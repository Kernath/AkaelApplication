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
    
    public partial class PraticaEspecificaProdutoTrabalho
    {
        public int IdPraticaEspecificaProdutoTrabalho { get; set; }
        public int IdPraticaEspecifica { get; set; }
        public int IdProdutoTrabalho { get; set; }
    
        public virtual PraticaEspecifica PraticaEspecifica { get; set; }
        public virtual ProdutoTrabalho ProdutoTrabalho { get; set; }
    }
}
