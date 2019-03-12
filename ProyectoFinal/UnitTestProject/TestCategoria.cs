using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
        }

        [TestMethod]
        public void agregarCategoria()
        {


            using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
            {

                categorias categorias = new categorias
                {
                    nombre = "Electronicos",
                    descripcion = "Computadoras,tablets,celulares"

                };

                unidad.genericDAL.Add(categorias);
                unidad.Complete();
            }

        }


        [TestMethod]

        public void actualizarCategoria()
        {

            using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
            {
                categorias producto = new categorias
                {
                    id_categoria = 1,
                    nombre = "Electronicos",
                    descripcion = "Computadoras,tablets,celulares,laptops"

                };

                unidad.genericDAL.Update(producto);
                unidad.Complete();
            }

        }

        [TestMethod]

        public void borrarCategoria()
        {
            categorias categoria;

            using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
            {
                categoria = unidad.genericDAL.Get(1);
                unidad.genericDAL.Remove(categoria);
                unidad.Complete();
            }

        }


    }


}