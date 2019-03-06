using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class RolDALImpl : IRolDAL
    {
        private BDContext context;

        public bool actualizarRol(sp_obtenerRoles_Result sp_ObtenerRoles_Result)
        {
            try
            {
                // context.Entry(sp_ObtenerRoles_Result).State = EntityState.Modified;
                using (context = new BDContext())
                {

                    context.sp_actualizarRol(sp_ObtenerRoles_Result.ROLID, sp_ObtenerRoles_Result.NOMBRE, sp_ObtenerRoles_Result.DESCRIPCION);
                    context.SaveChanges();
                }

              
                return true;
            }

            catch (Exception)
            {

                return false;
            }
        }

        public bool agregarRol(sp_obtenerRoles_Result sp_ObtenerRoles_Result)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_agregarRol
                    (
                        sp_ObtenerRoles_Result.NOMBRE,
                        sp_ObtenerRoles_Result.DESCRIPCION
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

        public bool eliminarRol(int id)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_deleteRol(id);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public sp_obtenerRolId_Result obtenerRolById(int id)
        {

            try
            {
                sp_obtenerRolId_Result sp_ObtenerRolId_Result;

                using (context = new BDContext())
                {
                    sp_ObtenerRolId_Result = context.sp_obtenerRolId(id).FirstOrDefault();
                }

                return sp_ObtenerRolId_Result;
            }
            catch (Exception)
            {

                return null;
            }

           
        }

        public List<sp_obtenerRoles_Result> obtenerRoles()
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
