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


            IRolDAL rolDAL = new RolDALImpl();
            sp_obtenerRoles_Result sp_ObtenerRoles_Result;



            bool result = rolDAL.agregarRol(sp_ObtenerRoles_Result = new sp_obtenerRoles_Result() {
                NOMBRE = "Admin",
                DESCRIPCION = "administradores de la tienda"
            });
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void obtenerRoles()
        {
            int result = 0;
            IRolDAL rolDAL = new RolDALImpl();

            result = rolDAL.obtenerRoles().Count;

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void obtenerRolById()
        {
            int result;
            IRolDAL rolDAL = new RolDALImpl();

            result = rolDAL.obtenerRolById(1).ROLID;

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void actualizarRol()
        {
            IRolDAL rolDAL = new RolDALImpl();

            sp_obtenerRoles_Result sp_ObtenerRoles_Result;

            bool result;

            result = rolDAL.actualizarRol(sp_ObtenerRoles_Result = new sp_obtenerRoles_Result() {
                ROLID = 1,
                NOMBRE = "ADMIN",
                DESCRIPCION = "administradores"
            });

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void eliminarRol()
        {
            IRolDAL rolDAL = new RolDALImpl();

            bool result;

            result = rolDAL.eliminarRol(1);

            Assert.AreEqual(true, result);
        }

    }
}
