using System;
using System.Collections.Generic;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestProductoFacturacion
    {
        [TestMethod]
        public void obtenerProductosFacturacionByIdFacturacion()
        {
            List<sp_obtenerFacturacionProductoByIdFacturacion_Result> productosFacturacion;
            IProductosFacturacionDAL productosFacturacionDAL = new ProductosFacturacionDALImpl();

            productosFacturacion = productosFacturacionDAL.obtenerProductosFacturacion(1);
            int cantidad = productosFacturacion.Count;


            Assert.AreEqual(1, cantidad);

        }
    }
}
