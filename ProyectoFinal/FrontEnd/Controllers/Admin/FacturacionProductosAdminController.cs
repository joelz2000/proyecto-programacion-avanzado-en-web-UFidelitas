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
    public class FacturacionProductosAdminController : Controller
    {
        int id_promocion = 0;
        // GET: FacturacionProductos
        public ActionResult Index(int id)
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
                if (item.id_estado == 1)
                {
                    continue;
                }
                else
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
                    id_promocion = id;
                }
            }
            return View("~/Views/Admin/FacturacionProductosAdmin/Index.cshtml", productoVM);
        }

        // GET: FacturacionProductos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturacionProductos/Create
        /*public ActionResult Create(int id)
        {
            
             FacturacionProductosViewModels facturacionProductoVM = new FacturacionProductosViewModels();

            List<productos> productos = new List<productos>();

            //lista productos
            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {

                productos = unidad.genericDAL.GetAll().ToList();

            }

            facturacionProductoVM.facturacionId = id;

            foreach (var producto in productos)
            {
                if (producto.id_estado != 1)
                {
                    facturacionProductoVM.lista_productos.Add(new SelectListItem()
                    {
                        Text = producto.nombre,
                        Value = producto.productoId.ToString()
                    });


                }
            }


            return View("~/Views/Admin/FacturacionProductosAdmin/Create.cshtml", facturacionProductoVM);
        }
        */
        // POST: FacturacionProductos/Create
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturacionProductosViewModels facturacionProductosVM)
        {
            try
            {
                facturacion_producto facturacion_producto = new facturacion_producto
                {
                    productoId = facturacionProductosVM.productoId,
                    facturacionId = facturacionProductosVM.facturacionId,
                    cantidad = facturacionProductosVM.cantidad
                };

                using (UnidadDeTrabajo<facturacion_producto> unidad = new UnidadDeTrabajo<facturacion_producto>(new BDContext()))
                {
                    unidad.genericDAL.Add(facturacion_producto);
                    unidad.Complete();
                }

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
        */
        // GET: FacturacionProductos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturacionProductos/Edit/5
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

        // GET: FacturacionProductos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturacionProductos/Delete/5
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
