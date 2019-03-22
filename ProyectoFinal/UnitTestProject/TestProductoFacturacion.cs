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
            int resultado;

            

            List<facturacion_producto> productosFacturacion;
            List<productos> productos;

            using (UnidadDeTrabajo<facturacion_producto> unidad = new UnidadDeTrabajo<facturacion_producto>(new BDContext()))
            {
                productosFacturacion = unidad.genericDAL.GetAll().ToList();
            }



            List<facturacion_producto> productoVM = new List<facturacion_producto>();
            facturacion_producto facturacion_Producto;

            
            foreach (var item in productosFacturacion)
            {
                if (item.facturacionId == 1)
                {
                    facturacion_Producto = new facturacion_producto
                    {
                        productoId = item.productoId,
                        facturacionId = item.facturacionId,
                        cantidad = item.cantidad
                    };
                  
                    productoVM.Add(facturacion_Producto);
                }
            }


            
            resultado = productoVM.Count;

            /* List<sp_obtenerFacturacionProductoByIdFacturacion_Result> productosFacturacion;
             IProductosFacturacionDAL productosFacturacionDAL = new ProductosFacturacionDALImpl();

             productosFacturacion = productosFacturacionDAL.obtenerProductosFacturacion(1).ToList();

             int cantidad = productosFacturacion.Count;

             */
             Assert.AreEqual(1, resultado);

        }
    }
}
