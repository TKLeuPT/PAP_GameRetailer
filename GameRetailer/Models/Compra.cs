//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameRetailer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compra
    {
        public int NumCompra { get; set; }
        public System.DateTime DataCompra { get; set; }
        public int NumArmazem { get; set; }
        public int CodBarras { get; set; }
        public int Quantidade { get; set; }
    
        public virtual Armazem Armazem { get; set; }
        public virtual Jogo Jogo { get; set; }
    }
}