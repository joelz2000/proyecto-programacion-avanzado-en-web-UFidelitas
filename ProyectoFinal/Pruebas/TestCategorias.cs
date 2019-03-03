using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pruebas
{
    [TestClass]
    public class TestCategorias
    {
        [TestMethod]
        public void obtenerCategorias()
        {

            using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
            {

            }
        }
    }
}
