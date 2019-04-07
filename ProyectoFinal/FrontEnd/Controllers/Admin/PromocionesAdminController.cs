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
    public class PromocionesAdminController : Controller
    {

        UnidadDeTrabajo<promociones> unidad_promocion = new UnidadDeTrabajo<promociones>(new BDContext());
        UnidadDeTrabajo<estados> unidad_estados = new UnidadDeTrabajo<estados>(new BDContext());

        // GET: PromocionesAdmin
        public ActionResult Index()
        {
   
            List<promociones> promociones = unidad_promocion.genericDAL.GetAll().ToList();
            List<estados> estadoBD = unidad_estados.genericDAL.GetAll().ToList();

            List<PromocionesViewModel> promocionesVM = new List<PromocionesViewModel>();
            PromocionesViewModel promocionVM;

            foreach (var promocion in promociones)
            {
                if (promocion.id_estado == 1)
                {
                    continue;
                }
                else
                {
                    promocionVM = new PromocionesViewModel
                    {
                        promocionId = promocion.promocionId,
                        nombre = promocion.nombre, 
                        descripcion = promocion.descripcion,
                        valor = promocion.valor
                    };
                    promocionesVM.Add(promocionVM);
                }
            }
            return View("~/Views/Admin/PromocionesAdmin/Index.cshtml", promocionesVM);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            PromocionesViewModel promocionVM = new PromocionesViewModel();
            return View("~/Views/Admin/PromocionesAdmin/Create.cshtml", promocionVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PromocionesViewModel promocionVM)
        {
            try
            {
                // TODO: Add insert logic here
                promociones promocion = new promociones
                {
                    nombre = promocionVM.nombre,
                    descripcion = promocionVM.descripcion,
                    valor = promocionVM.valor,
                    id_estado = 2
                };

                using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
                {
                    unidad.genericDAL.Add(promocion);
                    unidad.Complete();
                }

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        public ActionResult Edit(int id)
        {
            // revisar si el URL contiene un ID, si no entonces devolver 404
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PromocionesViewModel promocionesViewModel;
            promociones promocion;

           

            using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
            {
                promocion = unidad.genericDAL.Get(id);
            }

            // ver si el producto tiene estado bloqueado. Si si, devolver 404
            if (promocion.id_estado == 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            promocionesViewModel = new PromocionesViewModel
            {
                promocionId = promocion.promocionId,
                nombre = promocion.nombre,
                descripcion = promocion.descripcion,
                valor = promocion.valor,
                id_estado = 2
                
            };

            return View("~/Views/Admin/PromocionesAdmin/Edit.cshtml", promocionesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PromocionesViewModel promocionesViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    promociones promocion = new promociones
                    {
                        promocionId = promocionesViewModel.promocionId,
                        nombre = promocionesViewModel.nombre,
                        descripcion = promocionesViewModel.descripcion,
                        valor = promocionesViewModel.valor,
                        id_estado = 2
                    };

                    using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
                    {
                        unidad.genericDAL.Update(promocion);
                        unidad.Complete();
                        return new HttpStatusCodeResult(HttpStatusCode.OK);
                    }
                   
                }

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            catch (DataException /* dex */ )
            {
                // devolver error 500
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // revisar si el URL contiene un ID, si no entonces devolver 404
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                promociones promocion;
                using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
                {

                    promocion = unidad.genericDAL.Get(id);
                    promocion.id_estado = 1;
                }

                using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
                {

                    unidad.genericDAL.Update(promocion);
                    unidad.Complete();
                }

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
        }
    }
}