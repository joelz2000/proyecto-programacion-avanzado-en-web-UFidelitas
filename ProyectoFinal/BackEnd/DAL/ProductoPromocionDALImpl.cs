using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class ProductoPromocionDALImpl : IProductoPromocionDAL
    {
        BDContext context;
        public bool eliminarPromocionProducto(int productoId, int promocionId)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_eliminarPromocionProducto(productoId, promocionId);
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