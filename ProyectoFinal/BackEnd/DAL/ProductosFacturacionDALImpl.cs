using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class ProductosFacturacionDALImpl : IProductosFacturacionDAL
    {
        private BDContext context;
        public List<sp_obtenerFacturacionesProducto_Result> obtenerProductosFacturacion()
        {
            try
            {
                List<sp_obtenerFacturacionesProducto_Result> productosFacturacion;
                using (context = new BDContext())
                {
                    productosFacturacion = context.sp_obtenerFacturacionesProducto().ToList();
                }
                return productosFacturacion;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
