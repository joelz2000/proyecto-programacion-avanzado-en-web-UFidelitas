﻿using System;
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
        sp_ObtenerRolesUser_Result sp_obtenerRolesUser;

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

        [TestMethod]

        public void actualizarUsuario()
        {
            bool result;
            
            

            result = usuarioDAL.actualizarUsuario(sp_ObtenerUsuarios_Result = new sp_obtenerUsuarios_Result
            {
                userId = 1,
                nombre = "Joel2",
                apellidos = "Zuniga Jimenezs",
                contrasena = "1212asas",
                correoElectronico = "joel@live.com",
                fechaNacimiento = DateTime.Parse("1998-03-11"),
                genero = "Masculino",
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

        public void eliminarUsuario()
        {
            bool result = false;

            result = usuarioDAL.eliminarUsuario(1);

            Assert.AreEqual(true, result);

        }

        [TestMethod]

        public void agregarRolUsuario()
        {
            bool result;

            result = usuarioDAL.agregarRolUsuario(sp_obtenerRolesUser = new sp_ObtenerRolesUser_Result {
                    rolId = 1,
                    userId = 1
                    
            });

            Assert.AreEqual(true, result);
        }

        [TestMethod]

        public void actualizarRolUsuario()
        {
            bool result = false;
            int rolIdActual = 1;
            int userId = 1;
            int rolIdNueva = 2;
            int idEstado = 1;

            result = usuarioDAL.actualizarRolUsuario(rolIdActual, userId, rolIdNueva, idEstado);

            Assert.AreEqual(true, result);
        }

        [TestMethod]

        public void obtenerRolUsuarios()
        {
            int result = 0;

            result = usuarioDAL.obtenerRolesUsuario().Count;

            Assert.AreEqual(1, result);
        }

        [TestMethod]

        public void obtenerRolUsuariosById()
        {
            int result = 0;

            result = usuarioDAL.obtenerRolUsuarioById(1).userId;

            Assert.AreEqual(1, result);
        }


    }
}
