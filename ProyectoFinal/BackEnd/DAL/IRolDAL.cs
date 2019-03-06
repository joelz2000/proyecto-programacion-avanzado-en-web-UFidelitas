using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IRolDAL
    {
        bool agregarRol(sp_obtenerRoles_Result sp_ObtenerRoles_Result);

        List<sp_obtenerRoles_Result> obtenerRoles();

        sp_obtenerRolId_Result obtenerRolById(int id);

        bool actualizarRol(sp_obtenerRoles_Result sp_ObtenerRoles_Result);

        bool eliminarRol(int id);
    }
}
