using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.Admin
{
    [CustomAuthorize(Roles = "Admin")]
    public class VentasAdminController : Controller
    {
        // GET: VentasAdmin
        public ActionResult Index()
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
            List<VentasViewModel> ventasVM = new List<VentasViewModel>();

            //objeto facturacion producto view models
            VentasViewModel ventaVM;

            //objeto producto
            productos producto = new productos();

            //objeto facturaciones
            facturaciones facturacion = new facturaciones();

            foreach (var itemProductoFacturacion in productosFacturacion)
            {
                
                //facturaciones

                foreach (var itemFacturaciones in facturaciones)
                {
                    if (itemFacturaciones.facturacionId == itemProductoFacturacion.facturacionId)
                    {
                        facturacion = new facturaciones
                        {
                            facturacionId = itemFacturaciones.facturacionId,
                            fecha = itemFacturaciones.fecha
                        };
                    }


                }

                //productos
                foreach (var itemProducto in productos)
                {
                    if (itemProducto.productoId == itemProductoFacturacion.productoId)
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
                ventaVM = new VentasViewModel
                {
                    facturacionId = facturacion.facturacionId,
                    productoId = producto.productoId,
                    nombre = producto.nombre,
                    cantidad = itemProductoFacturacion.cantidad,
                    precio = producto.precio,
                    fecha = facturacion.fecha
                };
                ventasVM.Add(ventaVM);
                
            }
            return View("~/Views/Admin/VentasAdmin/Index.cshtml", ventasVM);
        }

        // GET: VentasAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VentasAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentasAdmin/Create
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

        // GET: VentasAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VentasAdmin/Edit/5
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

        // GET: VentasAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VentasAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
