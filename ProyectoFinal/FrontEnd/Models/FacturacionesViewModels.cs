using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class FacturacionesViewModels
    {
        [Key]
        [Display(Name = "Id")]
        public int facturacionId { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Fecha de compra")]
        [Required]
        public Nullable<System.DateTime> fecha { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }


        [Display(Name = "Impuesto")]
        [Required]
        public Nullable<int> impuesto { get; set; }


        [Display(Name = "Subtotal")]
        public Nullable<double> subtotal { get; set; }


        [Display(Name = "Total")]
        public Nullable<double> total { get; set; }


        [Display(Name = "Tipo")]
        public string tipo { get; set; }
    }
}