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
    
    public partial class CabecalhoGuia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CabecalhoGuia()
        {
            this.DetalheGuia = new HashSet<DetalheGuia>();
        }
    
        public int NumGuia { get; set; }
        public System.DateTime DataEmissao { get; set; }
        public int CodArmazem { get; set; }
        public string Matricula { get; set; }
        public int NumCliente { get; set; }
        public int CodDistribuidor { get; set; }
    
        public virtual Armazem Armazem { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Distribuidor Distribuidor { get; set; }
        public virtual Viatura Viatura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalheGuia> DetalheGuia { get; set; }
    }
}
