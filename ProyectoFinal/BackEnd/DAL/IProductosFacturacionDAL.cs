using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IProductosFacturacionDAL
    {

        List<sp_obtenerFacturacionesProducto_Result> obtenerProductosFacturacion();
    }
}
