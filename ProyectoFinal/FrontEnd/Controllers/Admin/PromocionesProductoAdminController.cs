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
    public class PromocionesProductoAdminController : Controller
    {
        // GET: PromocionesProducto
        public ActionResult Index(int id)
        {

            List<promociones_productos> promocionesProducto;
            List<promociones> promociones;
            List<productos> productos;

            //lista productos por facturacion
            using (UnidadDeTrabajo<promociones_productos> unidad = new UnidadDeTrabajo<promociones_productos>(new BDContext()))
            {
                promocionesProducto = unidad.genericDAL.GetAll().ToList();
            }

            //lista productos
            using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
            {
                promociones = unidad.genericDAL.GetAll().ToList();
            }

            //lista factruaciones
            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                productos = unidad.genericDAL.GetAll().ToList();
            }

            //lista view model promociones productos
            List<PromocionesProductoViewModels> promocionesProductoVM = new List<PromocionesProductoViewModels>();

            //objeto promociones producto view models
            PromocionesProductoViewModels promocionProductoVM;

            //objeto producto
            productos producto = new productos();

            //objeto promociones
            promociones promocion = new promociones();

            foreach (var itemPromocionProducto in promocionesProducto)
            {
                if (itemPromocionProducto.promocionId == id)
                {

                    //facturaciones

                    foreach (var itemPromociones in promociones)
                    {
                        if (itemPromociones.promocionId == itemPromocionProducto.promocionId)
                        {
                            promocion = new promociones
                            {
                                promocionId = itemPromociones.promocionId,
                                nombre = itemPromociones.nombre,
                                valor = itemPromociones.valor
                            };
                        }


                    }

                    //productos
                    foreach (var itemProducto in productos)
                    {
                        if (itemProducto.productoId == itemPromocionProducto.productoId)
                        {
                            producto = new productos
                            {
                                productoId = itemProducto.productoId,
                                nombre = itemProducto.nombre
                            };
                        }


                    }

                    //promociones productos
                    promocionProductoVM = new PromocionesProductoViewModels
                    {
                        promocionId = itemPromocionProducto.promocionId,
                        productoId = itemPromocionProducto.productoId,
                        nombrePromocion = promocion.nombre,
                        nombreProducto = producto.nombre,
                        fecha_inicial_promocion = itemPromocionProducto.fecha_inicial_promocion,
                        fecha_final_promocion = itemPromocionProducto.fecha_final_promocion,
                        valor = promocion.valor

                    };
                    promocionesProductoVM.Add(promocionProductoVM);
                }
            }
            return View("~/Views/Admin/PromocionesProductoAdmin/Index.cshtml", promocionesProductoVM);
        }

        // GET: PromocionesProducto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PromocionesProducto/Create
        public ActionResult Create()
        {
            PromocionesProductoViewModels PromocionesProductosVM = new PromocionesProductoViewModels();

            //lista productos
            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                PromocionesProductosVM.productos = unidad.genericDAL.GetAll().ToList();
            }

            //lista factruaciones
            using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
            {
                PromocionesProductosVM.promociones = unidad.genericDAL.GetAll().ToList();
            }



            return View("~/Views/Admin/PromocionesProductoAdmin/Create.cshtml", PromocionesProductosVM);
        }

        // POST: PromocionesProducto/Create
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

        // GET: PromocionesProducto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PromocionesProducto/Edit/5
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

        // GET: PromocionesProducto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PromocionesProducto/Delete/5
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
