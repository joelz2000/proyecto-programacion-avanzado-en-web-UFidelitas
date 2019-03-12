using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestPais
    {
        
        [TestMethod]
        public void ObtenerPaises()
        {
            List<Pais> paises;

            using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new BDContext()))
            {
                paises = unidad.genericDAL.GetAll().ToList();   
            }

            int result = paises.Count;

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void ObtenerProvincias()
        {
            List<Provincia> provincias;

            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new BDContext()))
            {
                provincias = unidad.genericDAL.GetAll().ToList();
            }

            int result = provincias.Count;

            Assert.AreEqual(7, result);

        }

        [TestMethod]
        public void ObtenerCantones()
        {
            List<Canton> cantones;

            using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new BDContext()))
            {
                cantones = unidad.genericDAL.GetAll().ToList();
            }

            int result = cantones.Count;

            Assert.AreEqual(21, result);

        }

        [TestMethod]
        public void ObtenerDistritos()
        {
            List<Distrito> distritos;

            using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new BDContext()))
            {
                distritos = unidad.genericDAL.GetAll().ToList();
            }

            int result = distritos.Count;

            Assert.AreEqual(173, result);

        }

    }
}
