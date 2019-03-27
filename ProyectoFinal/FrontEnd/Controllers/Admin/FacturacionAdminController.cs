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
            FacturacionesViewModels facturacionesVM;
            sp_obtenerFacturacionId_Result facturaciones;
            IFacturacionDAL facturacionDAL = new FacturacionDALImpl();

            facturaciones = facturacionDAL.obtenerFacturacionById(id);

            facturacionesVM = new FacturacionesViewModels
            {
                facturacionId = facturaciones.facturacionId,
                nombre = facturaciones.nombre,
                fecha = facturaciones.fecha,
                descripcion = facturaciones.descripcion,
                impuesto = facturaciones.impuesto,
                subtotal = facturaciones.subtotal,
                total = facturaciones.total,
                tipo = facturaciones.tipo
            };

            return View("~/Views/Admin/FacturacionAdmin/Edit.cshtml", facturacionesVM);
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
            List<facturaciones> facturaciones;

            //lista productos por facturacion
            using (UnidadDeTrabajo<facturacion_producto> unidad = new UnidadDeTrabajo<facturacion_producto>(new BDContext()))
            {
                productosFacturacion = unidad.genericDAL.GetAll().ToList();
            }

            //lista productos
            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                productos = unidad.genericDAL.GetAll().ToList();
            }

            //lista factruaciones
            using (UnidadDeTrabajo<facturaciones> unidad = new UnidadDeTrabajo<facturaciones>(new BDContext()))
            {
                facturaciones = unidad.genericDAL.GetAll().ToList();
            }

            //lista view model facturacion productos
            List<FacturacionProductosViewModels> productoVM = new List<FacturacionProductosViewModels>();

            //objeto facturacion producto view models
            FacturacionProductosViewModels facturacion_Producto;

            //objeto producto
            productos producto = new productos();

            //objeto facturaciones
            facturaciones facturacion = new facturaciones();

            foreach (var item in productosFacturacion)
            {
                if (item.facturacionId == id)
                {
                    
                    //facturaciones

                    foreach (var itemFacturaciones in facturaciones)
                    {
                        if (itemFacturaciones.facturacionId == item.facturacionId)
                        {
                            facturacion = new facturaciones
                            {
                              facturacionId = itemFacturaciones.facturacionId,
                              nombre = itemFacturaciones.nombre,
                            };
                        }


                    }

                    //productos
                    foreach (var itemProducto in productos)
                    {
                        if (itemProducto.productoId == item.productoId)
                        {
                            producto = new productos
                            {
                                productoId = itemProducto.productoId,
                                nombre = itemProducto.nombre,
                                precio = itemProducto.precio
                            };
                        }


                    }

                    //facturacion productos
                    facturacion_Producto = new FacturacionProductosViewModels
                    {
                        facturacionId = facturacion.facturacionId,
                        nombre = facturacion.nombre,
                        productoId = producto.productoId,
                        nombre1 = producto.nombre,
                        precio = producto.precio,
                        cantidad = item.cantidad
                    };
                    productoVM.Add(facturacion_Producto);
                }
            }
            return View("~/Views/Admin/FacturacionAdmin/ProductosFacturacion.cshtml", productoVM);
            
        }
    }
}
