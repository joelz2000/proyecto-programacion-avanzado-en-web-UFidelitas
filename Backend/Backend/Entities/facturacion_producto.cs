//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Backend.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class facturacion_producto
    {
        public int productoId { get; set; }
        public string facturacionId { get; set; }
        public Nullable<int> cantidad { get; set; }
    
        public virtual facturaciones facturaciones { get; set; }
        public virtual productos productos { get; set; }
    }
}
