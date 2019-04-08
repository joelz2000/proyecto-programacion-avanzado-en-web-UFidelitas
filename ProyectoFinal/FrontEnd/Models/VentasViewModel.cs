using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class VentasViewModel
    {
        [Key]
        [Display(Name = "FacturacionID")]
        public int facturacionId { get; set; }

        [Key]
        [Display(Name = "ProductoID")]
        public int productoId { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Cantidad")]
        public int? cantidad { get; set; }        

        [Display(Name = "Precio")]
        public double? precio { get; set; }

        [Display(Name = "Fecha de compra")]
        
        public Nullable<System.DateTime> fecha { get; set; }
    }
}