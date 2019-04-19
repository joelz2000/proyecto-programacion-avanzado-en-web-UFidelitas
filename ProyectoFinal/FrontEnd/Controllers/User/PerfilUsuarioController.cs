using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.User
{
    public class PerfilUsuarioController : Controller
    {
        // GET: PerfilUsuario
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: PerfilUsuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PerfilUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilUsuario/Create
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

        // GET: PerfilUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            usuarios usuario;

            using (UnidadDeTrabajo<usuarios> unidad = new UnidadDeTrabajo<usuarios>(new BDContext()))
            {
                usuario = unidad.genericDAL.Get(id);
            }

            if(usuario.telefono == null)
            {
                usuario.telefono = 0;
            }

            PerfilUsuarioViewModel perfilUsuarioVM = new PerfilUsuarioViewModel
            {
                id_usuario = usuario.userId,
                nombre = usuario.nombre,
                apellidos = usuario.apellidos,
                correo = usuario.correoElectronico,
                Telefono = (int)usuario.telefono
            };
            return View("~/Views/User/PerfilUsuario/Index.cshtml", perfilUsuarioVM);
        }

        // POST: PerfilUsuario/Edit/5
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

        // GET: PerfilUsuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PerfilUsuario/Delete/5
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
