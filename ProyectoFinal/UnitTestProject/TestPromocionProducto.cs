using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestPromocionProducto
    {

        IProductoPromocionDAL productoPromocionDAL = new ProductoPromocionDALImpl();


        [TestMethod]
        public void agregarPromocionProducto()
        {
            int result;

            using (UnidadDeTrabajo<promociones_productos> unidad = new UnidadDeTrabajo<promociones_productos>(new BDContext()))
            {

                promociones_productos promociones_Productos = new promociones_productos
                {
                    productoId = 1,
                    promocionId = 1,
                    fecha_inicial_promocion = DateTime.Now,
                    fecha_final_promocion = DateTime.Today



                };

                result = promociones_Productos.productoId;

                unidad.genericDAL.Add(promociones_Productos);
                unidad.Complete();
            }

            Assert.AreEqual(1, result);


        }


        [TestMethod]

        public void actualizarPromocionProducto()
        {

            using (UnidadDeTrabajo<promociones_productos> unidad = new UnidadDeTrabajo<promociones_productos>(new BDContext()))
            {
                promociones_productos promociones_Productos = new promociones_productos
                {
                    productoId = 1,
                    promocionId = 1,
                    fecha_inicial_promocion = DateTime.Now,
                    fecha_final_promocion = DateTime.Now,


                };

                unidad.genericDAL.Update(promociones_Productos);
                unidad.Complete();
            }

        }

        [TestMethod]



        public void eliminarProductoPromocion()
        {
            bool result = false;

            result = productoPromocionDAL.eliminarPromocionProducto(1, 1);

            Assert.AreEqual(true, result);

        }


    }


}