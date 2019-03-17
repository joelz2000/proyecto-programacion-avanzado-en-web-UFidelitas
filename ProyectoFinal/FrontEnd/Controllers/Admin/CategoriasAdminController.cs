using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models.Admin;
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
            List<categorias> categorias;
            using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
            {
                categorias = unidad.genericDAL.GetAll().ToList();
            }

            List<CategoriasAdminViewModel> categoriasVM = new List<CategoriasAdminViewModel>();
            CategoriasAdminViewModel categoriaVM;

            foreach (var item in categorias)
            {
                categoriaVM = new CategoriasAdminViewModel {
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
            return View();
        }

        // POST: CategoriasAdmin/Create
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

        // GET: CategoriasAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriasAdmin/Edit/5
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
