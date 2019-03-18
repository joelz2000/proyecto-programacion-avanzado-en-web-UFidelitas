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
    public class CategoriasAdminController : Controller
    {

        // GET: CategoriasAdmin
        public ActionResult Index()
        {
            string mensaje = "";
            if (Session["mensaje"] != null)
            {
                mensaje = Session["mensaje"].ToString();
            }
            List<categorias> categorias;
            using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
            {
                categorias = unidad.genericDAL.GetAll().ToList();
            }

            List<CategoriasViewModel> categoriasVM = new List<CategoriasViewModel>();
            CategoriasViewModel categoriaVM;

            foreach (var item in categorias)
            {
                categoriaVM = new CategoriasViewModel {
                    id_categoria = item.id_categoria,
                    nombre = item.nombre,
                    descripcion = item.descripcion
                };

                categoriasVM.Add(categoriaVM);
            }
            return View("~/Views/Admin/CategoriasAdmin/Index.cshtml", categoriasVM);
        }

        // GET: CategoriasAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriasAdmin/Create
        public ActionResult Create()
        {
            return View("~/Views/Admin/CategoriasAdmin/Create.cshtml");
        }

        // POST: CategoriasAdmin/Create
        [HttpPost]
        public ActionResult Create(CategoriasViewModel categoriaVM)
        {
            
            try
            {
                // TODO: Add insert logic here
                categorias categoria = new categorias
                {
                    nombre = categoriaVM.nombre,
                    descripcion = categoriaVM.descripcion
                };

                using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
                {
                    unidad.genericDAL.Add(categoria);
                    unidad.Complete();
                }
                Session["mensaje"] =
                        "<div class='alert alert-success alert-dismissible'>"+
                        "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                        "   <h4><i class='icon fa fa-check'></i> Alerta!</h4>" +
                        "       Categoria Agregada"+
                        "</div> ";
                     
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriasAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriasViewModel categoriasViewModel;
            categorias categoria;
            using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
            {
                categoria = unidad.genericDAL.Get(id);
            }

            categoriasViewModel = new CategoriasViewModel {
                id_categoria = categoria.id_categoria,
                nombre = categoria.nombre,
                descripcion = categoria.descripcion
            };

            
            return View("~/Views/Admin/CategoriasAdmin/Edit.cshtml", categoriasViewModel);
        }

        // POST: CategoriasAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoriasViewModel categoriasViewModel)
        {
            try
            {
                using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
                {
                    categorias categoria = new categorias
                    {
                        id_categoria = categoriasViewModel.id_categoria,
                        nombre = categoriasViewModel.nombre,
                        descripcion = categoriasViewModel.descripcion

                    };

                    unidad.genericDAL.Update(categoria);
                    unidad.Complete();
                }
                // TODO: Add update logic here
                Session["mensaje"] =
                        "<div class='alert alert-success alert-dismissible'>" +
                        "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                        "   <h4><i class='icon fa fa-check'></i> Alerta!</h4>" +
                        "       Categoria actualizada correctamente" +
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
            return View();
        }

        // POST: CategoriasAdmin/Delete/5
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
