using System;
using System.Collections.Generic;
using System.Linq;
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
           /* int cantidad;
            List<facturacion_producto> productos;
            using (UnidadDeTrabajo<facturacion_producto> unidad = new UnidadDeTrabajo<facturacion_producto>(new BDContext()))
            {
                productos = unidad.genericDAL.GetAll().ToList();
            }

            cantidad = productos.Count;*/
            List<sp_obtenerFacturacionesProducto_Result> productosFacturacion;
            IProductosFacturacionDAL productosFacturacionDAL = new ProductosFacturacionDALImpl();

            productosFacturacion = productosFacturacionDAL.obtenerProductosFacturacion().ToList();

            int cantidad = productosFacturacion.Count;
            

            Assert.AreEqual(2, cantidad);

        }
    }
}
