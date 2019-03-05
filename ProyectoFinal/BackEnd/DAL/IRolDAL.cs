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
        bool sp_agregarRol(string nombre, string descripcion);

        List<sp_obtenerRoles_Result> sp_obtenerRoles();

        sp_obtenerRolId_Result sp_obtenerRolById(int id);

        bool sp_actualizarRol(int id, string nombre, string descripcion);

        bool sp_eliminarRol(int id);
    }
}
