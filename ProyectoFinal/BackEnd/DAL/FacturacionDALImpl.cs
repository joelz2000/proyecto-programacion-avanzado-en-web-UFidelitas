using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class FacturacionDALImpl : IFacturacionDAL
    {
        private BDContext context;
        public bool actualizarFactura(sp_obtenerFacturaciones_Result sp_ObtenerFacturaciones_Result)
        {
            throw new NotImplementedException();
        }

        public bool agregarFactura(sp_obtenerFacturaciones_Result factura)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_agregarFacturacion(
                        factura.nombre,
                        factura.fecha,
                        factura.descripcion,
                        factura.impuesto,
                        factura.tipo,
                        (int)factura.total,
                        null,
                        null
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

        public bool eliminarFactura(int id)
        {
            throw new NotImplementedException();
        }

        public List<sp_obtenerFacturaciones_Result> obtenerFacturacion()
        {
            try
            {
                List<sp_obtenerFacturaciones_Result> facturas;

                using (context = new BDContext())
                {
                    facturas = context.sp_obtenerFacturaciones().ToList();
                }

                return facturas;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public sp_obtenerFacturacionId_Result obtenerFacturacionById(int id)
        {
            try
            {
                sp_obtenerFacturacionId_Result factura;

                using (context = new BDContext())
                {
                    factura = context.sp_obtenerFacturacionId(id).FirstOrDefault();
                }

                return factura;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
