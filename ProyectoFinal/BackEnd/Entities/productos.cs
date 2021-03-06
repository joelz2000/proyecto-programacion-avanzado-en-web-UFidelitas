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
    
    public partial class productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public productos()
        {
            this.facturacion_producto = new HashSet<facturacion_producto>();
            this.imagen_producto = new HashSet<imagen_producto>();
            this.promociones_productos = new HashSet<promociones_productos>();
        }
    
        public int productoId { get; set; }
        public string nombre { get; set; }
        public Nullable<double> precio { get; set; }
        public string descripcion { get; set; }
        public string modelo { get; set; }
        public Nullable<int> id_categoria { get; set; }
        public Nullable<int> id_marca { get; set; }
        public Nullable<int> id_coleccion { get; set; }
        public Nullable<int> id_bodega { get; set; }
        public Nullable<int> id_distribuidor { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<int> id_estado { get; set; }
    
        public virtual categorias categorias { get; set; }
        public virtual colecciones colecciones { get; set; }
        public virtual distribuidor distribuidor { get; set; }
        public virtual estados estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<facturacion_producto> facturacion_producto { get; set; }
        public virtual genero_producto genero_producto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imagen_producto> imagen_producto { get; set; }
        public virtual marcas marcas { get; set; }
        public virtual medida_producto medida_producto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<promociones_productos> promociones_productos { get; set; }
    }
}
