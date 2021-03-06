﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class PromocionesViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int promocionId { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Display(Name = "Valor")]
        public int? valor { get; set; }

        [Display(Name = "id estado")]
        public int?id_estado { get; set; }
    }
}