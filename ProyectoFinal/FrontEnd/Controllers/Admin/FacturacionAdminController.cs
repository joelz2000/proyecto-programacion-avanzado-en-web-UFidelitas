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
    public class FacturacionAdminController : Controller
    {
        // GET: Facturacion
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
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facturacion/Details/5
      /*  public ActionResult ProductosFacturacion(int id)
        {

            List<sp_obtenerFacturacionProductoByIdFacturacion_Result> productosFacturacion;

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
        }*/
    }
}
