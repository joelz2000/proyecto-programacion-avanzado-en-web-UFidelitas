using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Models
{
    public class ComprasViewModels
    {
        [Key]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }

        [Key]
        [Display(Name = "Producto")]
        public int idProducto { get; set; }


        [Display(Name = "Cantidad")]
        public Nullable<int> cantidad { get; set; }

       
        [Display(Name = "Fecha de compra")]
        [Required]
        public Nullable<System.DateTime> fecha { get; set; }

        [Key]
        [Display(Name = "Facturacion")]
        public int idFacturacion { get; set; }

        [Display(Name = "Telefono")]
        public int telefono { get; set; }

        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Key]
        [Display(Name = "Pais")]
        public int idPais { get; set; }

        [Key]
        [Display(Name = "Provincia")]
        public int idProvincia { get; set; }

        [Key]
        [Display(Name = "Canton")]
        public int idCanton { get; set; }

        [Key]
        [Display(Name = "Distrito")]
        public int idDistrito { get; set; }

        public List<SelectListItem> lista_pais = new List<SelectListItem>();
        public List<SelectListItem> lista_provincia = new List<SelectListItem>();
        public List<SelectListItem> lista_canton = new List<SelectListItem>();
        public List<SelectListItem> lista_distrito = new List<SelectListItem>();





    }
}