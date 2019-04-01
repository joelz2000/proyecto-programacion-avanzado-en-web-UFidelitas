using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            
            List<sp_obtenerFacturaciones_Result> facturaciones;

            IFacturacionDAL facturacionDAL = new FacturacionDALImpl();

            facturaciones = facturacionDAL.obtenerFacturacion().ToList();

            List<FacturacionesViewModels> facturacionesVM = new List<FacturacionesViewModels>();

            FacturacionesViewModels facturacionVM;

            foreach (var item in facturaciones)
            {
                if (item.id_estado == 1)
                {
                    continue;
                }
                else
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
            // revisar si el URL contiene un ID, si no entonces devolver 404
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FacturacionesViewModels facturacionesVM;
            sp_obtenerFacturacionId_Result facturaciones;
            IFacturacionDAL facturacionDAL = new FacturacionDALImpl();


            facturaciones = facturacionDAL.obtenerFacturacionById(id);

            if (facturaciones.id_estado == 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            facturacionesVM = new FacturacionesViewModels
            {
                facturacionId = facturaciones.facturacionId,
                nombre = facturaciones.nombre,
                fecha = facturaciones.fecha,
                descripcion = facturaciones.descripcion,
                impuesto = facturaciones.impuesto,
                subtotal = facturaciones.subtotal,
                total = facturaciones.total,
                tipo = facturaciones.tipo,
                id_estado = 2
            };

            return View("~/Views/Admin/FacturacionAdmin/Edit.cshtml", facturacionesVM);
        }

        // POST: Facturacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacturacionesViewModels facturacionesVM)
        {
            try
            {
                IFacturacionDAL facturacionDAL = new FacturacionDALImpl();
                sp_obtenerFacturaciones_Result facturaciones;
                if (ModelState.IsValid)
                {
                    
                    
                    facturacionDAL.actualizarFactura(facturaciones = new sp_obtenerFacturaciones_Result()
                    {
                        facturacionId = facturacionesVM.facturacionId,
                        nombre = facturacionesVM.nombre,
                        fecha = facturacionesVM.fecha,
                        descripcion = facturacionesVM.descripcion,
                        impuesto = facturacionesVM.impuesto,
                        tipo = facturacionesVM.tipo,
                        id_estado = 2
                    });

                    
                    // devolver que todo bien
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }

                // modelo no valido, devolver error 500
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            catch (DataException /* dex */ )
            {
                // devolver error 500
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
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

        
    }
}
