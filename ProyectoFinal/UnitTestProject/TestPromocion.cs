using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestPromocion
    {


        [TestMethod]
        public void agregarPromocion()
        {


            using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
            {

                promociones promocion = new promociones
                {
                    nombre = "Segundo Articulo 20%",
                    descripcion = "Celulares S7,S8 20% de descuento",
                    valor = 20

                };

                unidad.genericDAL.Add(promocion);
                unidad.Complete();
            }

        }


        [TestMethod]

        public void actualizarPromocion()
        {

            using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
            {
                promociones promocion = new promociones
                {
                    promocionId = 3,
                    nombre = "Segundo Articulo 20%",
                    descripcion = "Celulares S7,S8,S9 20% de descuento",
                    valor = 20

                };

                unidad.genericDAL.Update(promocion);
                unidad.Complete();
            }

        }

        [TestMethod]

        public void borrarPromocion()
        {
            promociones promocion;

            using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
            {
                promocion = unidad.genericDAL.Get(1);
                unidad.genericDAL.Remove(promocion);
                unidad.Complete();
            }

        }


    }


}