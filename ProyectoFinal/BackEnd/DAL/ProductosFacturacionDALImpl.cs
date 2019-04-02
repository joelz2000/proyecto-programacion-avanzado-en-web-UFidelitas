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

        /*
        public bool agregarProductoFacturacion(sp_obtenerFacturacionesProducto_Result facturacionProductos)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_agregarFacturacionProducto
                    (
                      facturacionProductos.facturacionId,
                      facturacionProductos.productoId,
                      facturacionProductos.cantidad,
                      facturacionProductos.id_estado
                    );
                    context.SaveChanges();

                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        */

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
