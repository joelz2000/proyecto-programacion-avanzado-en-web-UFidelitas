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
    
    public partial class promociones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public promociones()
        {
            this.promociones_productos = new HashSet<promociones_productos>();
            this.usuarios_promocion = new HashSet<usuarios_promocion>();
        }
    
        public int promocionId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> valor { get; set; }
        public Nullable<int> id_estado { get; set; }
    
        public virtual estados estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<promociones_productos> promociones_productos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuarios_promocion> usuarios_promocion { get; set; }
    }
}
