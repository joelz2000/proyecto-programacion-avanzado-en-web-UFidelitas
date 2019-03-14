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
    
    public partial class usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuarios()
        {
            this.usuarios_promocion = new HashSet<usuarios_promocion>();
            this.rol = new HashSet<rol>();
            this.facturaciones = new HashSet<facturaciones>();
        }
    
        public int userId { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string contrasena { get; set; }
        public string correoElectronico { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string genero { get; set; }
        public string fotoPerfil { get; set; }
        public Nullable<int> telefono { get; set; }
        public string direccion { get; set; }
        public Nullable<int> paisId { get; set; }
        public Nullable<int> distritoId { get; set; }
        public Nullable<int> provinciaId { get; set; }
        public Nullable<int> cantonId { get; set; }
        public string Usuario_ID { get; set; }
    
        public virtual Canton Canton { get; set; }
        public virtual Distrito Distrito { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual Provincia Provincia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuarios_promocion> usuarios_promocion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rol> rol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<facturaciones> facturaciones { get; set; }
    }
}
