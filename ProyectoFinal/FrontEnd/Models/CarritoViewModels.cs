using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    // clase utilizada para obtener todos los datos de productos para el Index.html
    public class IndexCarritoViewModels
    {
        [Required]
        [Key]
        [Display(Name = "Codigo")]
        public int Id_Producto { get; set; }

        [Required]
        [Display(Name = "Producto")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public double? Precio { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int? cantidad { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string marca { get; set; }

        [Required]
        [Display(Name = "Agregado")]
        public DateTime fecha_agregado { get; set; }

        [Required]
        [Display(Name = "Ultima modificacion")]
        public DateTime fecha_modificado { get; set; }

    }
}