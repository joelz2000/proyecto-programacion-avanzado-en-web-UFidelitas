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
    public class MarcasAdminController : Controller
    {
        // GET: MarcasAdmin
        public ActionResult Index()
        {
            string mensaje = "";
            if (Session["mensaje"] != null)
            {
                mensaje = Session["mensaje"].ToString();
            }
            List<marcas> marcas;
            using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
            {
                marcas = unidad.genericDAL.GetAll().ToList();
            }

            List<MarcasViewModel> marcasVM = new List<MarcasViewModel>();
            MarcasViewModel marcaVM;

            foreach (var item in marcas)
            {
                marcaVM = new MarcasViewModel
                {
                    id_marca = item.id_marca,
                    nombre = item.nombre,
                    descripcion = item.descripcion
                };

                marcasVM.Add(marcaVM);
            }
            return View("~/Views/Admin/MarcasAdmin/Index.cshtml", marcasVM);
        }

        // GET: CategoriasAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriasAdmin/Create
        public ActionResult Create()
        {
            return View("~/Views/Admin/MarcasAdmin/Create.cshtml");
        }

        // POST: CategoriasAdmin/Create
        [HttpPost]
        public ActionResult Create(MarcasViewModel marcaVM)
        {

            try
            {
                // TODO: Add insert logic here
                marcas marca = new marcas
                {
                    nombre = marcaVM.nombre,
                    descripcion = marcaVM.descripcion
                };

                using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
                {
                    unidad.genericDAL.Add(marca);
                    unidad.Complete();
                }
                Session["mensaje"] =
                        "<div class='alert alert-success alert-dismissible'>" +
                        "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                        "   <h4><i class='icon fa fa-check'></i> Alerta!</h4>" +
                        "       ¡La marca fue agregada!" +
                        "</div> ";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MarcasAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            MarcasViewModel marcasViewModel;
            marcas marca;
            using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
            {
                marca = unidad.genericDAL.Get(id);
            }

            marcasViewModel = new MarcasViewModel
            {
                id_marca = marca.id_marca,
                nombre = marca.nombre,
                descripcion = marca.descripcion
            };

            return View("~/Views/Admin/MarcasAdmin/Edit.cshtml", marcasViewModel);
        }

        // POST: CategoriasAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(MarcasViewModel marcasViewModel)
        {
            try
            {
                using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
                {
                    marcas marca = new marcas
                    {
                        id_marca = marcasViewModel.id_marca,
                        nombre = marcasViewModel.nombre,
                        descripcion = marcasViewModel.descripcion

                    };

                    unidad.genericDAL.Update(marca);
                    unidad.Complete();
                }
                // TODO: Add update logic here
                Session["mensaje"] =
                        "<div class='alert alert-success alert-dismissible'>" +
                        "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                        "   <h4><i class='icon fa fa-check'></i> Alerta!</h4>" +
                        "       ¡La marca fue actualizada!" +
                        "</div> ";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriasAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                marcas marca;
                using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
                {

                    marca = unidad.genericDAL.Get(id);
                }
                using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
                {

                    unidad.genericDAL.Remove(marca);
                    unidad.Complete();
                }
                Session["mensaje"] =
                       "<div class='alert alert-success alert-dismissible'>" +
                       "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                       "   <h4><i class='icon fa fa-check'></i> Alerta!</h4>" +
                       "      ¡La marca fue eliminada!" +
                       "</div> ";
                return RedirectToAction("Index");
            }
            catch
            {
                Session["mensaje"] =
                      "<div class='alertalert-danger alert-dismissible'>" +
                      "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                      "   <h4><i class='icon fa fa-ban'></i> Alerta!</h4>" +
                      "      ¡La marca fue eliminada correctamente!" +
                      "</div> ";
                return View("~/Views/Admin/MarcasAdmin/Index.cshtml");
            }
        }
        // POST: MarcasAdmin/Delete/5
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