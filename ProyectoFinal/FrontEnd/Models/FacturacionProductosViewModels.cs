using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Models
{
    public class FacturacionProductosViewModels
    {
        [Key]
        [Display(Name = "Facturacion Id")]
        public int facturacionId { get; set; }

        [Display(Name = "Nombre Facturacion")]
        public string nombre { get; set; }

        [Display(Name = "Producto Id")]
        public int productoId { get; set; }

        [Display(Name = "Nombre Producto")]
        public string nombre1 { get; set; }

        [Display(Name = "Cantidad Vendida")]
        public Nullable<int> cantidad { get; set; }

        [Display(Name = "Precio Producto")]
        public Nullable<double> precio { get; set; }

        public List<SelectListItem> lista_productos = new List<SelectListItem>();
    }
}