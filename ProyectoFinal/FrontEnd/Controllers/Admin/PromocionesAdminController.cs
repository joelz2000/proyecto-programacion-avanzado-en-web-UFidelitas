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
    public class PromocionesAdminController : Controller
    {
        // GET: PromocionesAdmin
        public ActionResult Index()
        {
            string mensaje = "";
            if (Session["mensaje"] != null)
            {
                mensaje = Session["mensaje"].ToString();
            }

            List<promociones> promociones;
            using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
            {
                promociones = unidad.genericDAL.GetAll().ToList();
            }
            List<estados> estadoBD;
            using (UnidadDeTrabajo<estados> unidad = new UnidadDeTrabajo<estados>(new BDContext()))
            {
                estadoBD = unidad.genericDAL.GetAll().ToList();
            }

            List<PromocionesViewModel> promocionesVM = new List<PromocionesViewModel>();
            PromocionesViewModel promocionVM;
            estados estados = new estados();


            foreach (var item in promociones)
            {

                foreach (var itemEstado in estadoBD)
                {
                    if (item.id_estado == itemEstado.id_estado)
                    {
                        estados = new estados
                        {
                            estado = itemEstado.estado
                        };
                    }
                }

                promocionVM = new PromocionesViewModel
                {
                    promocionId = item.promocionId,
                    nombre = item.nombre,
                    descripcion = item.descripcion,
                    valor =(int)item.valor,
                    estado = estados.estado
                };
                promocionesVM.Add(promocionVM);
            }
            return View("~/Views/Admin/PromocionesAdmin/Index.cshtml", promocionesVM);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {
            PromocionesViewModel promocionVM = new PromocionesViewModel();
            using (UnidadDeTrabajo<estados> unidad = new UnidadDeTrabajo<estados>(new BDContext()))
            {
                promocionVM.estados = unidad.genericDAL.GetAll().ToList();
            }

            return View("~/Views/Admin/PromocionesAdmin/Create.cshtml", promocionVM);
        }

        public ActionResult Create(PromocionesViewModel promocionVM)
        {
            try
            {
                // TODO: Add insert logic here
                promociones promocion = new promociones
                {
                    nombre = promocionVM.nombre,
                    descripcion = promocionVM.descripcion
                };

                using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
                {
                    unidad.genericDAL.Add(promocion);
                    unidad.Complete();
                }
                Session["mensaje"] =
                        "<div class='alert alert-success alert-dismissible'>" +
                        "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                        "   <h4><i class='icon fa fa-check'></i> Alerta!</h4>" +
                        "       Promocion Agregada" +
                        "</div> ";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            PromocionesViewModel promocionesViewModel;
            promociones promocion;
            using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
            {
                promocion = unidad.genericDAL.Get(id);
            }

            promocionesViewModel = new PromocionesViewModel
            {
                promocionId = promocion.promocionId,
                nombre = promocion.nombre,
                descripcion = promocion.descripcion
            };

            return View("~/Views/Admin/PromocionesAdmin/Edit.cshtml", promocionesViewModel);
        }

        [HttpPost]
        public ActionResult Edit(PromocionesViewModel promocionesViewModel)
        {
            try
            {
                using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
                {
                    promociones promocion = new promociones
                    {
                        promocionId = promocionesViewModel.promocionId,
                        nombre = promocionesViewModel.nombre,
                        descripcion = promocionesViewModel.descripcion
                    };

                    unidad.genericDAL.Update(promocion);
                    unidad.Complete();
                }
                // TODO: Add update logic here
                Session["mensaje"] =
                        "<div class='alert alert-success alert-dismissible'>" +
                        "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                        "   <h4><i class='icon fa fa-check'></i> Alerta!</h4>" +
                        "       Promocion actualizada correctamente" +
                        "</div> ";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                promociones promocion;
                using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
                {

                    promocion = unidad.genericDAL.Get(id);
                }
                using (UnidadDeTrabajo<promociones> unidad = new UnidadDeTrabajo<promociones>(new BDContext()))
                {

                    unidad.genericDAL.Remove(promocion);
                    unidad.Complete();
                }
                Session["mensaje"] =
                       "<div class='alert alert-success alert-dismissible'>" +
                       "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                       "   <h4><i class='icon fa fa-check'></i> Alerta!</h4>" +
                       "      Promocion Eliminada Correctamente" +
                       "</div> ";
                return RedirectToAction("Index");
            }
            catch
            {
                Session["mensaje"] =
                      "<div class='alertalert-danger alert-dismissible'>" +
                      "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                      "   <h4><i class='icon fa fa-ban'></i> Alerta!</h4>" +
                      "      Promocion Eliminada Correctamente" +
                      "</div> ";
                return View("~/Views/Admin/PromocionesAdmin/Index.cshtml");
            }
        }
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