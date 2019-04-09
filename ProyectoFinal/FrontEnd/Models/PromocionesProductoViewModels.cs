using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Models
{
    public class PromocionesProductoViewModels
    {

        [Key]
        [Display(Name = "Producto Id")]
        public int productoId { get; set; }

        [Key]
        [Display(Name = "Promocion Id")]
        public int promocionId { get; set; }

        [Display(Name = "Nombre Promocion")]
        public string nombrePromocion { get; set; }

        [Display(Name = "Nombre Producto")]
        public string nombreProducto { get; set; }

        [Display(Name = "Fecha Inicial")]
        public Nullable<System.DateTime> fecha_inicial_promocion { get; set; }

        [Display(Name = "Fecha Final")]
        public Nullable<System.DateTime> fecha_final_promocion { get; set; }



        [Display(Name = "Valor")]
        public Nullable<int> valor { get; set; }

        [Display(Name = "Id Estado")]
        public Nullable<int> id_estado { get; set; }


        public List<SelectListItem> lista_productos = new List<SelectListItem>();
        public List<SelectListItem> lista_promociones = new List<SelectListItem>();
    }
}