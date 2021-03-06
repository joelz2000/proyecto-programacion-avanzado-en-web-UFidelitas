﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Models
{
    // clase utilizada para obtener todos los datos de productos para el Index.html
    public class IndexProductoViewModels
    {
        [Required]
        [Key]
        [Display(Name = "Codigo")]
        public int Id_Producto { get; set; }

        [Required]
        [Display(Name = "Producto")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public double? Precio { get; set; }

        [Required]
        [Display(Name ="Modelo")]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int? cantidad { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string marca { get; set; }
    }

    // clase utilizada para obtener los datos de producto para ver detalles
    public class DetallesProductoViewModels
    {
        [Required]
        [Key]
        [Display(Name = "Codigo")]
        public int Id_Producto { get; set; }

        [Required]
        [Display(Name = "Producto")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public double? Precio { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int? cantidad { get; set; }
    
        [Display(Name = "Cantidad a comprar")]
        public int? cantidad_compra { get; set; }

        public string identificador { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string marca { get; set; }

        [Required]
        [Display(Name = "Distribuidor")]
        public string distribuidor { get; set; }

        [Required]
        [Display(Name = "Coleccion")]
        public string coleccion { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string categoria { get; set; }
    }

    // clase utilizada para agregaar los datos de producto
    public class AgregarProductoViewModels
    {

        [Required]
        [Display(Name = "Producto")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public double? Precio { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        [DataType(DataType.MultilineText)]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        public int? cantidad { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public int id_marca { get; set; }
        public List<SelectListItem> lista_marcas = new List<SelectListItem>();

        [Required]
        [Display(Name = "Distribuidor")]
        public int id_distribuidor { get; set; }
        public List<SelectListItem> lista_distribuidores = new List<SelectListItem>();

        [Required]
        [Display(Name = "Categoria")]
        public int id_categoria { get; set; }
        public List<SelectListItem> lista_categorias = new List<SelectListItem>();

        [Display(Name = "Coleccion")]
        public int id_coleccion { get; set; }
        public List<SelectListItem> lista_colecciones = new List<SelectListItem>();
    }

    // clase utilizada para obtener los datos de producto para editar
    public class EditarProductoViewModels
    {
        [Required]
        [Key]
        [Display(Name = "Codigo")]
        public int Id_Producto { get; set; }

        [Required]
        [Display(Name = "Producto")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public double? Precio { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        [DataType(DataType.MultilineText)]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        public int? cantidad { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public int? id_marca_seleccionada { get; set; }
        public marcas marca { get; set; }
        public List<SelectListItem> lista_marcas = new List<SelectListItem>();

        [Required]
        [Display(Name = "Distribuidor")]
        public int? id_distribuidor_seleccionado { get; set; }
        public distribuidor distribuidor { get; set; }
        public List<SelectListItem> lista_distribuidores = new List<SelectListItem>();

        [Required]
        [Display(Name = "Categoria")]
        public int? id_categoria_seleccionada { get; set; }
        public categorias categoria { get; set; }
        public List<SelectListItem> lista_categorias = new List<SelectListItem>();

        [Display(Name = "Coleccion")]
        public int? id_coleccion_seleccionada { get; set; }
        public colecciones coleccion { get; set; }        
        public List<SelectListItem> lista_colecciones = new List<SelectListItem>();
    }


}