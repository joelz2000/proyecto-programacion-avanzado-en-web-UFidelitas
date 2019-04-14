using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.User
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }

        // GET: Compra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            ComprasViewModels CompraVM = new ComprasViewModels();

            List<Pais> paises = new List<Pais>();
            List<Provincia> provincias = new List<Provincia>();
            List<Canton> cantones = new List<Canton>();
            List<Distrito> distritos = new List<Distrito>();

            //lista paises
            using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new BDContext()))
            {

                paises = unidad.genericDAL.GetAll().ToList();

            }

            foreach (var pais in paises)
            {
                if (pais.id_estado != 1)
                {
                    CompraVM.lista_pais.Add(new SelectListItem()
                    {
                        Text = pais.nombre,
                        Value = pais.paisId.ToString()
                    });


                }
            }

            //lista provincias
            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new BDContext()))
            {

                provincias = unidad.genericDAL.GetAll().ToList();

            }

            foreach (var provincia in provincias)
            {
                if (provincia.id_estado != 1)
                {
                    CompraVM.lista_provincia.Add(new SelectListItem()
                    {
                        Text = provincia.nombre,
                        Value = provincia.provinciaId.ToString()
                    });


                }
            }

            //lista cantones
            using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new BDContext()))
            {

                cantones = unidad.genericDAL.GetAll().ToList();

            }

            foreach (var canton in cantones)
            {
                if (canton.id_estado != 1)
                {
                    CompraVM.lista_canton.Add(new SelectListItem()
                    {
                        Text = canton.nombre,
                        Value = canton.cantonId.ToString()
                    });


                }
            }


            //lista distrito
            using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new BDContext()))
            {

                distritos = unidad.genericDAL.GetAll().ToList();

            }

            foreach (var distrito in distritos)
            {
                if (distrito.id_estado != 1)
                {
                    CompraVM.lista_distrito.Add(new SelectListItem()
                    {
                        Text = distrito.nombre,
                        Value = distrito.distritoId.ToString()
                    });


                }
            }



            return View("~/Views/User/Compra/Create.cshtml", CompraVM);
        }

        // POST: Compra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComprasViewModels comprasViewModels)
        {
            try
            {

                // Crear factura
                IFacturacionDAL facturacionDAL = new FacturacionDALImpl();
                sp_obtenerFacturaciones_Result facturacion;
                facturacionDAL.agregarFactura(facturacion = new sp_obtenerFacturaciones_Result()
                {
                    nombre = "facturacion digital",
                    fecha = DateTime.UtcNow,
                    descripcion = null,
                    impuesto = 13,
                    subtotal = null,
                    total = null,
                    tipo = "Digital",
                    id_estado = 2
                });

                //obtener la ultima factura

                int idFactura;

                idFactura = facturacionDAL.obtenerFacturacion().Last().facturacionId;


                //agregar productos a facturacion
                List<carrito> carritos;

                using (UnidadDeTrabajo<carrito> unidad = new UnidadDeTrabajo<carrito>(new BDContext()))
                {
                    carritos = unidad.genericDAL.GetAll().ToList();
                }

                IProductosFacturacionDAL productosFacturacionDAL = new ProductosFacturacionDALImpl();

                sp_obtenerFacturacionesProducto_Result facturacionProducto;

                foreach (var carrito in carritos)
                {
                    facturacionProducto = new sp_obtenerFacturacionesProducto_Result
                    {
                        productoId = carrito.productoId,
                        facturacionId = idFactura,
                        cantidad = carrito.cantidad_producto,
                        id_estado = 2
                    };

                    productosFacturacionDAL.agregarProductoFacturacion(facturacionProducto);


                }

                return new HttpStatusCodeResult(HttpStatusCode.OK);



                
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Compra/Edit/5
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

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compra/Delete/5
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
