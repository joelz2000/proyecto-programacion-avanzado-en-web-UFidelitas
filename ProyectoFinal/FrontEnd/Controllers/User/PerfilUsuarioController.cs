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

        // GET: PerfilUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            usuarios usuario;
            List<Provincia> provincias = new List<Provincia>();
            PerfilUsuarioViewModel perfilUsuarioVM = new PerfilUsuarioViewModel();

            


            //Usuario
            using (UnidadDeTrabajo<usuarios> unidad = new UnidadDeTrabajo<usuarios>(new BDContext()))
            {
                usuario = unidad.genericDAL.Get(id);
            }

            if(usuario.telefono == null)
            {
                usuario.telefono = 0;
            }

            if(usuario.provinciaId == null)
            {
                usuario.provinciaId = 0;
            }

            perfilUsuarioVM.id_usuario = usuario.userId;
            perfilUsuarioVM.nombre = usuario.nombre;
            perfilUsuarioVM.apellidos = usuario.apellidos;
            perfilUsuarioVM.correo = usuario.correoElectronico;
            perfilUsuarioVM.Telefono = (int)usuario.telefono;
            perfilUsuarioVM.id_provincia = (int)usuario.provinciaId;


            //Provincia

            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new BDContext()))
            {
                provincias = unidad.genericDAL.GetAll().ToList();
            }

            Provincia provincia = new Provincia(); 


            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new BDContext()))
            {
                provincia = unidad.genericDAL.Get((int)usuario.provinciaId);
            }

            string textProvincia;
            if(provincia == null)
            {
                textProvincia = "Seleccionar";
            }
            else
            {
                textProvincia = provincia.nombre;
            }
            // valor por defecto
            perfilUsuarioVM.lista_provincias.Add(new SelectListItem()
            {
                Text = textProvincia,
                Value = usuario.provinciaId.ToString()
            });

            foreach (var itemProvincia in provincias)
            {
                if(usuario.provinciaId != itemProvincia.provinciaId)
                {
                    perfilUsuarioVM.lista_provincias.Add(new SelectListItem()
                    {
                        Text = itemProvincia.nombre,
                        Value = itemProvincia.provinciaId.ToString()
                    });
                }
               
            }




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

        public JsonResult obtenerCantones(int id_provincia)
        {
            BDContext context = new BDContext();
            UnidadDeTrabajo<Canton> unidad_cantones = new UnidadDeTrabajo<Canton>(context);
            List<sp_obtenerCantonesPorIDProvincia_Result> lista_cantones = new List<sp_obtenerCantonesPorIDProvincia_Result>();
            lista_cantones = context.sp_obtenerCantonesPorIDProvincia(id_provincia).ToList();

            var diccionarioCantones = new Dictionary<string, string>();
            foreach (var canton in lista_cantones)
            {
                diccionarioCantones.Add(canton.cantonId.ToString(), canton.nombre);
            }

            return Json(diccionarioCantones, JsonRequestBehavior.AllowGet);
        }

        public JsonResult obtenerDistritos(int id_distrito)
        {
            BDContext context = new BDContext();
            UnidadDeTrabajo<Distrito> unidad_distritos = new UnidadDeTrabajo<Distrito>(context);
            List<sp_obtenerDistritosPorIDCanton_Result> lista_distritos = new List<sp_obtenerDistritosPorIDCanton_Result>();
            lista_distritos = context.sp_obtenerDistritosPorIDCanton(id_distrito).ToList();

            var diccionarioDistritos = new Dictionary<string, string>();
            foreach (var distrito in lista_distritos)
            {
                diccionarioDistritos.Add(distrito.distritoId.ToString(), distrito.nombre);
            }

            return Json(diccionarioDistritos, JsonRequestBehavior.AllowGet);
        }

    }
}
