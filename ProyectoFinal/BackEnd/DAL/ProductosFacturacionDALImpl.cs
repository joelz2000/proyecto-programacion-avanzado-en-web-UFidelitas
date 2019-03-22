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
        public List<sp_obtenerFacturacionProductoByIdFacturacion_Result> obtenerProductosFacturacion(int id)
        {
            try
            {
                List<sp_obtenerFacturacionProductoByIdFacturacion_Result> productosFacturacion;
                using (context = new BDContext())
                {
                    productosFacturacion = context.sp_obtenerFacturacionProductoByIdFacturacion(id).ToList();
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
