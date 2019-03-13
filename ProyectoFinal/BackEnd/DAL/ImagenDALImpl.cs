using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class ImagenDALImpl : IImagenProductoDAL
    {
        private BDContext context;
        List<imagen_producto> imagen_Productos;

        public imagen_producto obtenerImagenesProducto(int idProducto, string imagen)
        {
            throw new NotImplementedException();
        }
    }
}
