using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class DistribuidoresViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int id_distribuidor { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Correo")]
        public string email { get; set; }
        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Display(Name = "ID Estado")]
        public Nullable<int> id_estado { get; set; }
    }
}