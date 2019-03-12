using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestMarca
    {


        [TestMethod]
        public void agregarMarca()
        {


            using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
            {

                marcas marca = new marcas
                {
                    nombre = "Dell",
                    descripcion = "Laptos,Desktops,Switches,Servidores"

                };

                unidad.genericDAL.Add(marca);
                unidad.Complete();
            }

        }


        [TestMethod]

        public void actualizarMarca()
        {

            using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
            {
                marcas marca = new marcas
                {
                    id_marca = 1,
                    nombre = "Electronicos",
                    descripcion = "Laptos,Desktops,Switches,Servidores,Ultrabooks"

                };

                unidad.genericDAL.Update(marca);
                unidad.Complete();
            }

        }

        [TestMethod]

        public void borrarMarca()
        {
            marcas marca;

            using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
            {
                marca = unidad.genericDAL.Get(1);
                unidad.genericDAL.Remove(marca);
                unidad.Complete();
            }

        }


    }


}