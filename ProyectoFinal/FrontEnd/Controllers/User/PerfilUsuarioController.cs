using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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



            //canton del usuario

            Canton canton = new Canton();
            if (usuario.cantonId != null)
            {
               
                using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new BDContext()))
                {
                    canton = unidad.genericDAL.Get((int)usuario.cantonId);
                }
            }


            //Distrito del usuario
            Distrito distrito = new Distrito();
            if (usuario.distritoId != null)
            {
              
                using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new BDContext()))
                {
                    distrito = unidad.genericDAL.Get((int)usuario.distritoId);
                }
            }

           

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
            if (provincia == null)
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
                if (usuario.provinciaId != itemProvincia.provinciaId)
                {
                    perfilUsuarioVM.lista_provincias.Add(new SelectListItem()
                    {
                        Text = itemProvincia.nombre,
                        Value = itemProvincia.provinciaId.ToString()
                    });
                }

            }


            perfilUsuarioVM.id_usuario = usuario.userId;
            perfilUsuarioVM.nombre = usuario.nombre;
            perfilUsuarioVM.apellidos = usuario.apellidos;
            perfilUsuarioVM.correo = usuario.correoElectronico;
            perfilUsuarioVM.Telefono = (int)usuario.telefono;
            perfilUsuarioVM.id_provincia = (int)usuario.provinciaId;
            perfilUsuarioVM.Usuario_ID = usuario.Usuario_ID;
            perfilUsuarioVM.nombreCanton = canton.nombre;
            perfilUsuarioVM.nombreDistrito = distrito.nombre;


           




            return View("~/Views/User/PerfilUsuario/Index.cshtml", perfilUsuarioVM);
        }

        // POST: PerfilUsuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarInformacionPersonal(PerfilUsuarioViewModel perfilUsuarioVM)
        {
            try
            {
                usuarios usuario ;

                usuario = new usuarios()
                {
                    userId = perfilUsuarioVM.id_usuario,
                    Usuario_ID = perfilUsuarioVM.Usuario_ID,
                    nombre = perfilUsuarioVM.nombre,
                    apellidos = perfilUsuarioVM.apellidos,
                    telefono = perfilUsuarioVM.Telefono,
                    correoElectronico = perfilUsuarioVM.correo,
                    direccion = perfilUsuarioVM.direccion,
                    provinciaId = perfilUsuarioVM.id_provincia,
                    cantonId = perfilUsuarioVM.id_canton,
                    distritoId = perfilUsuarioVM.id_distrito,
                };


                using (UnidadDeTrabajo<usuarios> unidad = new UnidadDeTrabajo<usuarios>(new BDContext()))
                {
                    unidad.genericDAL.Update(usuario);
                    unidad.Complete();
                }


                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarDireccion(PerfilUsuarioViewModel perfilUsuarioVM)
        {
            try
            {
                usuarios usuario;

                usuario = new usuarios()
                {
                    userId = perfilUsuarioVM.id_usuario,
                    Usuario_ID = perfilUsuarioVM.Usuario_ID,
                    direccion = perfilUsuarioVM.direccion,
                    provinciaId = perfilUsuarioVM.id_provincia,
                    cantonId = perfilUsuarioVM.id_canton,
                    distritoId = perfilUsuarioVM.id_distrito,
                    nombre = perfilUsuarioVM.nombre,
                    apellidos = perfilUsuarioVM.apellidos,
                    telefono = perfilUsuarioVM.Telefono,
                    correoElectronico = perfilUsuarioVM.correo
                };


                using (UnidadDeTrabajo<usuarios> unidad = new UnidadDeTrabajo<usuarios>(new BDContext()))
                {
                    unidad.genericDAL.Update(usuario);
                    unidad.Complete();
                }


                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
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
