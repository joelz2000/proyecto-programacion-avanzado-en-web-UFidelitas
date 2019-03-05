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

        [TestMethod]
        public void obtenerRoles()
        {
            int result = 0;
            IRolDAL rolDAL = new RolDALImpl();

            result = rolDAL.sp_obtenerRoles().Count;

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void obtenerRolById()
        {
            int result;
            IRolDAL rolDAL = new RolDALImpl();

            result = rolDAL.sp_obtenerRolById(1).ROLID;

            Assert.AreEqual(1, result);
        }
    }
}
