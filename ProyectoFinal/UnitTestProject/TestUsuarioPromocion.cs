using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestUsuarioPromocion
    {

        IUsuarioPromocionDAL usuarioPromocionDAL = new UsuarioPromocionDALImpl();

        [TestMethod]
        public void agregarUsuarioPromocion()
        {
            int result;

            using (UnidadDeTrabajo<usuarios_promocion> unidad = new UnidadDeTrabajo<usuarios_promocion>(new BDContext()))
            {

                usuarios_promocion usuarios_Promocion = new usuarios_promocion
                {
                    usuarioId = 1,
                    promocionId = 1,
                    fecha_inicial_promocion = DateTime.Now,
                    fecha_final_promocion = DateTime.Today



                };

                result = usuarios_Promocion.usuarioId;

                unidad.genericDAL.Add(usuarios_Promocion);
                unidad.Complete();
            }

            Assert.AreEqual(1, result);


        }


        [TestMethod]

        public void actualizarUsuarioPromocion()
        {

            using (UnidadDeTrabajo<usuarios_promocion> unidad = new UnidadDeTrabajo<usuarios_promocion>(new BDContext()))
            {
                usuarios_promocion usuarios_Promocion = new usuarios_promocion
                {
                    usuarioId = 1,
                    promocionId = 1,
                    fecha_inicial_promocion = DateTime.Now,
                    fecha_final_promocion = DateTime.Now,


                };

                unidad.genericDAL.Update(usuarios_Promocion);
                unidad.Complete();
            }

        }
        [TestMethod]



        public void eliminarUsuarioPromocion()
        {
            bool result = false;

            result = usuarioPromocionDAL.eliminarPromocionProducto(1, 1);

            Assert.AreEqual(true, result);

        }



    }
}
