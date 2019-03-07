using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestUsuario
    {
        IUsuarioDAL usuarioDAL = new usuarioDALImpl();
        sp_obtenerUsuarios_Result sp_ObtenerUsuarios_Result;

        [TestMethod]
        public void agregarUsuario()
        {
            bool result = false;

            result = usuarioDAL.agregarUsuario(sp_ObtenerUsuarios_Result = new sp_obtenerUsuarios_Result() {
                nombre = "Joel",
                apellidos = "Zuniga Jimenez",
                contrasena = "1212asas",
                correoElectronico = "joel@live.com",
                fechaNacimiento = DateTime.Parse("1998-03-11"),
                genero ="Masculino",
                fotoPerfil = null,
                telefono = 85689875,
                direccion = "Guanacaste av22",
                paisId = 1,
                distritoId = 1,
                provinciaId = 1,
                cantonId = 1
            });

            Assert.AreEqual(true, result);

        }

        [TestMethod]

        public void obtenerUsuarios()
        {
            int result = 0;

            result = usuarioDAL.obtenerUsuarios().Count;

            Assert.AreEqual(1, result);
        }

        [TestMethod]

        public void obtenerUsuarioById()
        {
            int result = 0;

            result = usuarioDAL.obtenerUsuarioById(1).userId;

            Assert.AreEqual(1, result);
        }
    }
}
