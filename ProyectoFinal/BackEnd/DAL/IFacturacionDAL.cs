using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IFacturacionDAL
    {
        bool agregarFactura(sp_obtenerFacturaciones_Result sp_ObtenerFacturaciones_Result);

        List<sp_obtenerFacturaciones_Result> obtenerFacturacion();

        sp_obtenerFacturacionId_Result obtenerFacturacionById(int id);

        bool actualizarFactura(sp_obtenerFacturaciones_Result sp_ObtenerFacturaciones_Result);

        bool eliminarFactura(int id);

    }
}
