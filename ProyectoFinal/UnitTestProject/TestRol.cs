using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestRol
    {
        [TestMethod]
        public void agregarRol()
        {
            string nombre = "administrador";
            string descripcion = "administradores de la tienda";

            IRolDAL rolDAL = new RolDALImpl();

            bool result = rolDAL.sp_agregarRol(nombre, descripcion);
            Assert.AreEqual(true, result);

        }
    }
}
