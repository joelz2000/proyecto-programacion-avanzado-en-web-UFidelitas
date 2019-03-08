using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class usuarioDALImpl : IUsuarioDAL
    {
        private BDContext context;
        public bool actualizarUsuario(sp_obtenerUsuarios_Result usuario)
        {
            
            try
            {
                using (context = new BDContext())
                {
                    context.sp_actualizarUsuario(
                        usuario.userId, 
                        usuario.nombre,
                        usuario.apellidos,
                        usuario.contrasena,
                        usuario.correoElectronico,
                        usuario.fechaNacimiento,
                        usuario.genero,
                        usuario.fotoPerfil,
                        usuario.telefono,
                        usuario.direccion,
                        usuario.paisId,
                        usuario.distritoId,
                        usuario.provinciaId,
                        usuario.cantonId

                    );

                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            throw new NotImplementedException();
        }

        public bool agregarRolUsuario(sp_ObtenerRolesUser_Result rolUser)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_agregarRolUser(
                        rolUser.rolId,
                        rolUser.userId
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

        public bool agregarUsuario(sp_obtenerUsuarios_Result sp_ObtenerUsuarios_Result)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_agregarUsuario
                    (
                        sp_ObtenerUsuarios_Result.nombre,
                        sp_ObtenerUsuarios_Result.apellidos,
                        sp_ObtenerUsuarios_Result.contrasena,
                        sp_ObtenerUsuarios_Result.correoElectronico,
                        sp_ObtenerUsuarios_Result.fechaNacimiento,
                        sp_ObtenerUsuarios_Result.genero,
                        sp_ObtenerUsuarios_Result.fotoPerfil,
                        sp_ObtenerUsuarios_Result.telefono,
                        sp_ObtenerUsuarios_Result.direccion,
                        sp_ObtenerUsuarios_Result.paisId,
                        sp_ObtenerUsuarios_Result.distritoId,
                        sp_ObtenerUsuarios_Result.provinciaId,
                        sp_ObtenerUsuarios_Result.cantonId
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

        public bool eliminarUsuario(int id)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_eliminarUsuario(id);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public sp_obtenerUsuariosId_Result obtenerUsuarioById(int id)
        {
            try
            {
                sp_obtenerUsuariosId_Result usuario;

                using (context = new BDContext())
                {
                    usuario = context.sp_obtenerUsuariosId(id).FirstOrDefault();
                }

                return usuario;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<sp_obtenerUsuarios_Result> obtenerUsuarios()
        {
            try
            {
                List<sp_obtenerUsuarios_Result> usuarios;

                using (context = new BDContext())
                {
                    usuarios = context.sp_obtenerUsuarios().ToList();
                }

                return usuarios;
            }
            catch (Exception)
            {

               return null;
            }
            
        }
    }
}
