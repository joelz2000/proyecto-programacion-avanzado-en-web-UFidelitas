using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestGeneroProducto
    {


        [TestMethod]
        public void agregarGeneroProducto()
        {


            using (UnidadDeTrabajo<genero_producto> unidad = new UnidadDeTrabajo<genero_producto>(new BDContext()))
            {

                genero_producto genero_Producto = new genero_producto
                {
                   productoId = 1,
                   genero = "Unisex"

                };

                unidad.genericDAL.Add(genero_Producto);
                unidad.Complete();
            }

        }


        [TestMethod]

        public void actualizarGeneroProducto()
        {

            using (UnidadDeTrabajo<genero_producto> unidad = new UnidadDeTrabajo<genero_producto>(new BDContext()))
            {
                genero_producto genero_Producto = new genero_producto
                {
                    productoId = 1,
                    genero = "Unisexx"

                };

                unidad.genericDAL.Update(genero_Producto);
                unidad.Complete();
            }

        }

        [TestMethod]

        public void borrarGeneroProducto()
        {
            genero_producto genero_Producto;

            using (UnidadDeTrabajo<genero_producto> unidad = new UnidadDeTrabajo<genero_producto>(new BDContext()))
            {
                genero_Producto = unidad.genericDAL.Get(1);
                unidad.genericDAL.Remove(genero_Producto);
                unidad.Complete();
            }

        }


    }


}