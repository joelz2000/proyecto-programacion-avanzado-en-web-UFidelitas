using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Models
{
    public class LoginUsuarioViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string nombre;


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Apellidos")]
        public string apellidos;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password;

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        public string correo;

        [Required]
        private int rol;
    }

    public class UsuarioInfoCompraViewModel
    {

        [Required]
        [Display(Name = "Provincia de envío")]
        public int id_provincia { get; set; }
        public List<SelectListItem> lista_provincias = new List<SelectListItem>();

        [Required]
        [Display(Name = "Canton de envío")]
        public int id_canton { get; set; }

        [Required]
        [Display(Name = "Distrito de envío")]
        public int id_distrito { get; set; }

        [Required]
        [Display(Name = "Dirección exacta")]
        public string direccion { get; set; }

        [Required]
        [Display(Name = "Número de tarjeta de crédito")]
        [DataType(DataType.CreditCard)]
        public string tarjeta_credito { get; set; }

        [Required]
        [Display(Name = "Fecha de vencimiento")]
        public string fecha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "CVV")]
        public string cvv { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre como aparece en la tarjeta")]
        public string nombre_tarjeta { get; set; }
    }

    public class NavbarUsuarioViewModel
    {

        [Key]
        [Required]
        [Display(Name = "Id Usuario:")]
        public int id_usuario { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string nombre;

    }
    public class PerfilUsuarioViewModel
    {
        [Key]
        [Required]
        [Display(Name = "Id Usuario:")]
        public int id_usuario { get; set; }

        [Key]
        public string Usuario_ID { get; set; }

        [Required]
        [Display(Name = "Nombre:")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellidos:")]
        public string apellidos { get; set; }
        [Required]
        [Display(Name = "Correo Electronico:")]
        public string correo { get; set; }

        [Required]
        [Display(Name = "Telefono:")]
        public int Telefono { get; set; }

        [Required]
        [Display(Name = "Provincia:")]
        public int id_provincia { get; set; }
        public List<SelectListItem> lista_provincias = new List<SelectListItem>();

       

        [Required]
        [Display(Name = "Canton:")]
        public int id_canton { get; set; }

        [Display(Name = "Nombre Canton:")]
        public string nombreCanton { get; set; }

        public List<SelectListItem> lista_canton_usuario = new List<SelectListItem>();

        [Required]
        [Display(Name = "Distrito:")]
        public int id_distrito { get; set; }
        public List<SelectListItem> lista_distrito_usuario = new List<SelectListItem>();

        [Display(Name = "Nombre Distrito:")]
        public string nombreDistrito { get; set; }

        [Required]
        [Display(Name = "Dirección:")]
        public string direccion { get; set; }

    }

}