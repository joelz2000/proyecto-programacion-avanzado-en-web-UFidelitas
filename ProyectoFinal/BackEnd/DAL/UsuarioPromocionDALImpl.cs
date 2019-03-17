using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UsuarioPromocionDALImpl : IUsuarioPromocionDAL
    {
        BDContext context;
        public bool eliminarPromocionProducto(int usuarioId, int promocionId)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_eliminarUsuarioPromocion(usuarioId, promocionId);
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
