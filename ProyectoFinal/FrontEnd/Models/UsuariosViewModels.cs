using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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

    public class NavbarUsuarioViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string nombre;

    }

}