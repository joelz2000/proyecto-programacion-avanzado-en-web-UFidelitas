using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestMedidaProducto
    {


        [TestMethod]
        public void agregarMedidaProducto()
        {


            using (UnidadDeTrabajo<medida_producto> unidad = new UnidadDeTrabajo<medida_producto>(new BDContext()))
            {

                medida_producto medida_Producto = new medida_producto
                {
                    productoId = 1,
                    medida = 5.5

                };

                unidad.genericDAL.Add(medida_Producto);
                unidad.Complete();
            }

        }


        [TestMethod]

        public void actualizarMedidaProducto()
        {

            using (UnidadDeTrabajo<medida_producto> unidad = new UnidadDeTrabajo<medida_producto>(new BDContext()))
            {
                medida_producto medida_Producto = new medida_producto
                {
                    productoId = 1,
                    medida = 5.8
                   

                };

                unidad.genericDAL.Update(medida_Producto);
                unidad.Complete();
            }

        }

        [TestMethod]

        public void borrarMedidaProducto()
        {
            medida_producto medida_Producto;

            using (UnidadDeTrabajo<medida_producto> unidad = new UnidadDeTrabajo<medida_producto>(new BDContext()))
            {
                medida_Producto = unidad.genericDAL.Get(1);
                unidad.genericDAL.Remove(medida_Producto);
                unidad.Complete();
            }

        }


    }


}