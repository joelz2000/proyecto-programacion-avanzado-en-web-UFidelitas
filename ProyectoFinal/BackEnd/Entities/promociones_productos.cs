//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class promociones_productos
    {
        public int productoId { get; set; }
        public int promocionId { get; set; }
        public Nullable<System.DateTime> fecha_inicial_promocion { get; set; }
        public Nullable<System.DateTime> fecha_final_promocion { get; set; }
    
        public virtual productos productos { get; set; }
        public virtual promociones promociones { get; set; }
    }
}