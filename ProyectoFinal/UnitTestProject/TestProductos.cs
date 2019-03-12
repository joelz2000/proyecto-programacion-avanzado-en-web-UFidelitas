using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestProductos
    {
        

        [TestMethod]
        public void agregarProducto()
        {
            int resultadoAnterior;
            int resultado;


            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                resultadoAnterior = unidad.genericDAL.GetAll().ToList().Count;
            }

            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                
                productos productos = new productos
                {
                    nombre = "Samsung galaxy 222",
                    precio = 2000,
                    descripcion = "Computadoras,tablets,celulares",
                    modelo = "122SS11",
                    id_categoria = 1,
                    id_marca = 1,
                    id_coleccion = null,
                    id_bodega = null,
                    id_distribuidor = null
                };

                unidad.genericDAL.Add(productos);
                unidad.Complete();
            }

            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                resultado = unidad.genericDAL.GetAll().ToList().Count;
            }

            Assert.AreEqual(resultadoAnterior + 1, resultado);

        }


        [TestMethod]
        public void obtenerProductos()
        {
            List<productos> productos;

            int resultado;

            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                productos = unidad.genericDAL.GetAll().ToList();
            }

            resultado = productos.Count;

            Assert.AreEqual(1, resultado);
        }


        [TestMethod]
        public void obtenerProductoId()
        {
          productos productos;

            int resultado;

            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                productos = unidad.genericDAL.Get(1);
            }

            resultado = productos.productoId;

            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void actualizarProducto()
        {

            double result;
            productos productos;

            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {

                 productos = new productos
                {
                    productoId = 1,
                    nombre = "Samsung galaxy 222",
                    precio = 1000,
                    descripcion = "Computadoras,tablets,celulares",
                    modelo = "122SS11",
                    id_categoria = 1,
                    id_marca = 1,
                    id_coleccion = null,
                    id_bodega = null,
                    id_distribuidor = null
                };

                unidad.genericDAL.Update(productos);
                unidad.Complete();
            }

            result = (double) productos.precio;
            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void eliminarProducto()
        {
            int resultadoAnterior;
            int resultado;
            productos productos;


            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                resultadoAnterior = unidad.genericDAL.GetAll().ToList().Count;
            }

            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                productos = unidad.genericDAL.Get(2);
            }

            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                unidad.genericDAL.Remove(productos);
                unidad.Complete();
            }


            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                resultado = unidad.genericDAL.GetAll().ToList().Count;
            }

            Assert.AreEqual(resultadoAnterior - 1, resultado);
        }
    }
}
