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
            return View("~/Views/Admin/FacturacionProductosAdmin/Index.cshtml", productoVM);
        }

        // GET: FacturacionProductos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturacionProductos/Create
        public ActionResult Create()
        {
            FacturacionProductosViewModels facturacionProductosVM = new FacturacionProductosViewModels();

            //lista productos
            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                facturacionProductosVM.productos = unidad.genericDAL.GetAll().ToList();
            }

            //lista factruaciones
            using (UnidadDeTrabajo<facturaciones> unidad = new UnidadDeTrabajo<facturaciones>(new BDContext()))
            {
                facturacionProductosVM.facturaciones = unidad.genericDAL.GetAll().ToList();
            }

           

            return View("~/Views/Admin/FacturacionProductosAdmin/Create.cshtml", facturacionProductosVM);
        }

        // POST: FacturacionProductos/Create
        [HttpPost]
        public ActionResult Create(FacturacionProductosViewModels facturacionProductosVM)
        {
            try
            {

                IProductosFacturacionDAL productosFacturacionDAL = new ProductosFacturacionDALImpl();
                // TODO: Add insert logic here
                sp_obtenerFacturacionesProducto_Result  facturacion = new sp_obtenerFacturacionesProducto_Result
                {
                    facturacionId = facturacionProductosVM.facturacionId,
                    productoId = facturacionProductosVM.productoId,
                    cantidad = facturacionProductosVM.cantidad
                };


                if (productosFacturacionDAL.agregarProductoFacturacion(facturacion) == true)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }
           
              



            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

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
