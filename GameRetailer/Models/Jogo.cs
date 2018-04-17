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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
   
    public partial class Jogo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jogo()
        {
            this.DetalheGuia = new HashSet<DetalheGuia>();
            this.Compra = new HashSet<Compra>();
        }
        
        public int CodBarras { get; set; }
        public string Criadora { get; set; }
        public string Categoria { get; set; }
        public int AnoLancamento { get; set; }
        public decimal Preco { get; set; }
        public string Nome { get; set; }
        public int NumDArmazem { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalheGuia> DetalheGuia { get; set; }
        public virtual Armazem Armazem { get; set; }
        public virtual Stock Stock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }
    }
}
