//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuarios_promocion
    {
        public int usuarioId { get; set; }
        public int promocionId { get; set; }
        public Nullable<System.DateTime> fecha_inicial_promocion { get; set; }
        public Nullable<System.DateTime> fecha_final_promocion { get; set; }
        public Nullable<int> id_estado { get; set; }
    
        public virtual promociones promociones { get; set; }
        public virtual usuarios usuarios { get; set; }
        public virtual estados estados { get; set; }
    }
}
