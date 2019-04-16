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
