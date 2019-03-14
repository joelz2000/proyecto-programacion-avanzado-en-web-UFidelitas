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
        

        public List<sp_obtenerImagenProducto_Result> obtenerImagenesProductoId(int idProducto)
        {
            
            try
            {
                List<sp_obtenerImagenProducto_Result> imagen_Productos;
                using (context = new BDContext())
                {
                    imagen_producto = context
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public sp_obtenerImagenProducto_Result obtenerImagenProducto(int idProducto, string imagen)
        {
            try
            {
                sp_obtenerImagenProducto_Result imagen_producto;

                using (context = new BDContext())
                {
                    imagen_producto = context.sp_obtenerImagenProducto(idProducto, imagen).FirstOrDefault();
                }

                return imagen_producto;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
