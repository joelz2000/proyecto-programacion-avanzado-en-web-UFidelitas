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
    
    public partial class rol_user
    {
        public int rolId { get; set; }
        public int userId { get; set; }
        public Nullable<int> id_estado { get; set; }
    
        public virtual estados estados { get; set; }
        public virtual rol rol { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}