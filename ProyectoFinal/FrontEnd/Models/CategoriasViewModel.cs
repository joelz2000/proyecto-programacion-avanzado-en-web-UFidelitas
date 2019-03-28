using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class CategoriasViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int id_categoria { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Display(Name = "Id Estado")]
        public Nullable<int> id_estado { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

        public virtual IEnumerable<estados> estados { get; set; }
    }
}