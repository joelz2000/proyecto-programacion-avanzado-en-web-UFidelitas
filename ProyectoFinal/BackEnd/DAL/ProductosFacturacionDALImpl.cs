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
        

        
    }
}
