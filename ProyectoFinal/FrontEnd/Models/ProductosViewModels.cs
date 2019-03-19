using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    // clase utilizada para obtener todos los datos de productos para el Index.html
    public class IndexProductoViewModels
    {
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public double? Precio { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public int? cantidad { get; set; }
        public string marca { get; set; }
    }
}