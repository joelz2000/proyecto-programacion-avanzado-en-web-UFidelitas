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
