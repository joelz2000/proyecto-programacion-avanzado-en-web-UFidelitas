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
    public class DistribuidoresAdminController : Controller
    {
        // GET: Distribuidores
        public ActionResult Index()
        {
            List<distribuidor> distribuidores;
            using (UnidadDeTrabajo<distribuidor> unidad = new UnidadDeTrabajo<distribuidor>(new BDContext()))
            {
                distribuidores = unidad.genericDAL.GetAll().ToList();
            }

            List<DistribuidoresViewModel> distribuidoresVM = new List<DistribuidoresViewModel>();
            DistribuidoresViewModel distribuidorVM;



            foreach (var itemDistribuidor in distribuidores)
            {
                if (itemDistribuidor.id_estado == 1)
                {
                    continue;
                }
                else
                {

                    distribuidorVM = new DistribuidoresViewModel
                    {
                       id_distribuidor = itemDistribuidor.id_distribuidor,
                       nombre = itemDistribuidor.nombre,
                       email = itemDistribuidor.email

                    };
                    distribuidoresVM.Add(distribuidorVM);

                }

            }
            return View("~/Views/Admin/DistribuidoresAdmin/Index.cshtml", distribuidoresVM);
        }

        // GET: Distribuidores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Distribuidores/Create

        public ActionResult Create()
        {
            return View("~/Views/Admin/DistribuidoresAdmin/Create.cshtml");
        }

        // POST: Distribuidores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DistribuidoresViewModel distribuidorVM)
        {
            try
            {
                // TODO: Add insert logic here
                distribuidor distribuidor = new distribuidor
                {
                    id_distribuidor = distribuidorVM.id_distribuidor,
                    nombre = distribuidorVM.nombre,
                    email = distribuidorVM.email,
                    direccion = distribuidorVM.direccion,
                    id_estado = 2
                };
                if ((distribuidor.nombre != null) && (distribuidor.email != null))
                {
                    using (UnidadDeTrabajo<distribuidor> unidad = new UnidadDeTrabajo<distribuidor>(new BDContext()))
                    {
                        unidad.genericDAL.Add(distribuidor);
                        unidad.Complete();
                    }
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

        // GET: Distribuidores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Distribuidores/Edit/5
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

        // GET: Distribuidores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Distribuidores/Delete/5
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
