using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.Admin
{
    [CustomAuthorize(Roles = "Admin")]
    public class FacturacionAdminController : Controller
    {
        // GET: FacturacionC:\Users\gfumanaf\Documents\Universidad\I_CUA_2019\proyecto-programacion-avanzado-en-web-UFidelitas\ProyectoFinal\FrontEnd\Controllers\Admin\FacturacionAdminController.cs
        public ActionResult Index()
        {
            string mensaje = "";
            if (Session["mensaje"] != null)
            {
                mensaje = Session["mensaje"].ToString();
            }
            List<sp_obtenerFacturaciones_Result> facturaciones;

            IFacturacionDAL facturacionDAL = new FacturacionDALImpl();

            facturaciones = facturacionDAL.obtenerFacturacion().ToList();

            List<FacturacionesViewModels> facturacionesVM = new List<FacturacionesViewModels>();

            FacturacionesViewModels facturacionVM;

            foreach (var item in facturaciones)
            {
                facturacionVM = new FacturacionesViewModels
                {
                    facturacionId = item.facturacionId,
                    nombre = item.nombre,
                    fecha = item.fecha,
                    descripcion = item.descripcion,
                    impuesto = item.impuesto,
                    subtotal = item.subtotal,
                    total = item.total,
                    tipo = item.tipo
                };

                facturacionesVM.Add(facturacionVM);
            }
            return View("~/Views/Admin/FacturacionAdmin/Index.cshtml", facturacionesVM);
        }

        // GET: Facturacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Facturacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facturacion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facturacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Facturacion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {    
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facturacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Facturacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facturacion/Details/5
        public ActionResult ProductosFacturacion(int id)
        {
            List<facturacion_producto> productosFacturacion;
            List<productos> productos;

            using (UnidadDeTrabajo<facturacion_producto> unidad = new UnidadDeTrabajo<facturacion_producto>(new BDContext()))
            {
                productosFacturacion = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                productos = unidad.genericDAL.GetAll().ToList();
            }

            List<FacturacionProductosViewModels> productoVM = new List<FacturacionProductosViewModels>();
            FacturacionProductosViewModels facturacion_Producto;
            productos producto = new productos();

            foreach (var item in productosFacturacion)
            {
                if (item.facturacionId == 1)
                {
                    facturacion_Producto = new FacturacionProductosViewModels
                    {
                      
                        facturacionId = item.facturacionId,
                        cantidad = item.cantidad
                    };

                    foreach (var itemProducto in productos)
                    {
                        if (itemProducto.productoId == item.productoId)
                        {
                            producto = new productos
                            {
                                nombre =itemProducto.nombre
                            };
                        }


                    }
                    facturacion_Producto = new FacturacionProductosViewModels
                    {

                        nombre1 = producto.nombre,
                        precio = producto.precio
                    };
                    productoVM.Add(facturacion_Producto);
                }
            }
            return View("~/Views/Admin/FacturacionAdmin/ProductosFacturacion.cshtml", productoVM);
            /*
            List<facturacion_producto> productosFacturacion;
            using (UnidadDeTrabajo<facturacion_producto> unidad = new UnidadDeTrabajo<facturacion_producto>(new BDContext()))
            {
                productosFacturacion = unidad.genericDAL.GetAll().ToList();
            }

            List<FacturacionProductosViewModels> facturacionProductosVM = new List<FacturacionProductosViewModels>();
            FacturacionProductosViewModels facturacionProductoVM;

            foreach (var item in productosFacturacion)
            {
                facturacionProductoVM = new FacturacionProductosViewModels
                {
                    facturacionId = item.facturacionId,
                    nombre = item.productos,//nombre facturacion
                    productoId = item.productoId,
                    nombre1 = item.nombre1, //nombre producto
                    cantidad = item.cantidad,
                    precio = item.precio
                };

                facturacionProductosVM.Add(facturacionProductoVM);
            }
            return View("~/Views/Admin/CategoriasAdmin/Index.cshtml", facturacionProductosVM);
            */
            /*List<sp_obtenerFacturacionProductoByIdFacturacion_Result> productosFacturacion;

            IFacturacionDAL facturacionDAL = new FacturacionDALImpl();

            productosFacturacion = facturacionDAL.obtenerProductosFacturacion(id);

            List<FacturacionProductosViewModels> facturacionesProductosVM = new List<FacturacionProductosViewModels>();

            FacturacionProductosViewModels facturacionProductoVM;

            foreach (var item in productosFacturacion)
            {
                facturacionProductoVM = new FacturacionProductosViewModels
                {
                    facturacionId = item.facturacionId,
                    nombre = item.nombre,//nombre facturacion
                    productoId = item.productoId,
                    nombre1 = item.nombre1, //nombre producto
                    cantidad = item.cantidad,
                    precio = item.precio
                };

                facturacionesProductosVM.Add(facturacionProductoVM);
            }
            return View("~/Views/Admin/FacturacionAdmin/ProductosFacturacion.cshtml", facturacionesProductosVM);
        */
        }
    }
}
