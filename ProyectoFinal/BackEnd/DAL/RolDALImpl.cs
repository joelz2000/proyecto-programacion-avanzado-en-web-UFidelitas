using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class RolDALImpl : IRolDAL
    {
        private BDContext context;

        public bool sp_actualizarRol(int id, string nombre, string descripcion)
        {
            throw new NotImplementedException();
        }

        public bool sp_agregarRol(string nombre, string descripcion)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_agregarRol(nombre, descripcion);
                    context.SaveChanges();
                   
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool sp_eliminarRol(int id)
        {
            throw new NotImplementedException();
        }

        public rol sp_obtenerRolById(int id)
        {
            throw new NotImplementedException();
        }

        public List<sp_obtenerRoles_Result> sp_obtenerRoles()
        {

            try
            {
                List<sp_obtenerRoles_Result> roles;

                using (context = new BDContext())
                {
                    roles = context.sp_obtenerRoles().ToList();
                }

                return roles;
            }
            catch (Exception)
            {

                return null;
            }
           
        }
    }
}
