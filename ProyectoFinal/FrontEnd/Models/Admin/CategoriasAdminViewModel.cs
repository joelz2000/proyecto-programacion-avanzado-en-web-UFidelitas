using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models.Admin
{
    public class CategoriasAdminViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int id_categoria { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
    }
}