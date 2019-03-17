using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IProductoPromocionDAL


    {
        bool eliminarPromocionProducto(int productoId, int promocionId);
    }
}
