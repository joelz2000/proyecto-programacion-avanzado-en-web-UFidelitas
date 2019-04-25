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
        public ActionResult MostrarFacturasUsuario(int id_usuario)
        {
            List<usuarios> usuarios = new List<usuarios>();
            List<facturaciones> facturaciones;
            List<usuario_facturaciones> usuario_Facturaciones;

            using (UnidadDeTrabajo<facturaciones> unidad = new UnidadDeTrabajo<facturaciones>(new BDContext()))
            {
                facturaciones = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<usuario_facturaciones> unidad = new UnidadDeTrabajo<usuario_facturaciones>(new BDContext()))
            {
                usuario_Facturaciones = unidad.genericDAL.GetAll().ToList();
            }


            List<FacturacionesViewModels> facturacionesVM = new List<FacturacionesViewModels>();

            FacturacionesViewModels facturacionVM;

            foreach (var itemFacturacion in facturaciones)
            {
                if (itemFacturacion.id_estado == 1)
                {
                    continue;
                }
                else
                {
                    foreach (var itemUsuarioFacturacion in usuario_Facturaciones)
                    {
                        if(itemUsuarioFacturacion.usuarioId == id_usuario && itemFacturacion.facturacionId == itemUsuarioFacturacion.facturacionId)
                        {
                            facturacionVM = new FacturacionesViewModels
                            {
                                facturacionId = itemFacturacion.facturacionId,
                                nombre = itemFacturacion.nombre,
                                fecha = itemFacturacion.fecha,
                                descripcion = itemFacturacion.descripcion,
                                impuesto = itemFacturacion.impuesto,
                                subtotal = itemFacturacion.subtotal,
                                total = itemFacturacion.total,
                                tipo = itemFacturacion.tipo
                            };
                            facturacionesVM.Add(facturacionVM);
                        }
                    }
                    
                }



            }
            return View("~/Views/User/PerfilUsuario/Facturas.cshtml", facturacionesVM);

        }

        public ActionResult obtenerPDF(int id, string nombre)
        {
            /*
            var htmlToPdf = new HtmlToPdf();
            var html = @"<h1>Hello World!</h1><br><p>This is IronPdf.</p>";
            // turn html to pdf
            var pdf = htmlToPdf.RenderHtmlAsPdf(html);
            // save resulting pdf into file
            pdf.SaveAs("~/Content/dist/facturacionesPDF/HtmlToPdf.Pdf");*/


            return Redirect("~/Content/dist/facturacionesPDF/" + nombre + id + ".pdf");
        }
        // GET: PerfilUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            usuarios usuario;
            List<Provincia> provincias = new List<Provincia>();
            List<Canton> cantones = new List<Canton>();
            List<Distrito> distritos = new List<Distrito>();
            PerfilUsuarioViewModel perfilUsuarioVM = new PerfilUsuarioViewModel();
            Canton canton = new Canton();
            Distrito distrito = new Distrito();

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
            int valorProvincia;
            if (usuario.provinciaId == 0)
            {
                textProvincia = "Seleccionar";
                valorProvincia = 0;
            }
            else
            {
                textProvincia = provincia.nombre;
                valorProvincia = provincia.provinciaId;
            }
            // valor por defecto de provincia
            perfilUsuarioVM.lista_provincias.Add(new SelectListItem()
            {
                Text = textProvincia,
                Value = valorProvincia.ToString()
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

            //cantones por provincia por usuario

            using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new BDContext()))
            {
                cantones = unidad.genericDAL.GetAll().ToList();
            }

           

            
            if(usuario.cantonId == null)
            {
                usuario.cantonId = 0;
            }
            
                //obtener canton del usuario
            canton = obtenerCantonUsuario((int)usuario.cantonId);

           
            string textCantones;
            int valor;
            if (canton.cantonId == 0)
            {
                textCantones = "Seleccionar";
                valor = 0;
            }
            else
            {
                textCantones = canton.nombre;
                valor = (int)usuario.cantonId;
            }
            // valor por defecto
            perfilUsuarioVM.lista_canton_usuario.Add(new SelectListItem()
            {
                Text = textCantones,
                Value = valor.ToString()
            });


           
            foreach (var itemCanton in cantones)
            {
                if (usuario.provinciaId == itemCanton.provinciaId && usuario.cantonId != itemCanton.cantonId)
                {
                    perfilUsuarioVM.lista_canton_usuario.Add(new SelectListItem()
                    {
                        Text = itemCanton.nombre,
                        Value = itemCanton.cantonId.ToString()
                    });
                }

            }
            
            

            //distritos por canton del usuario

            using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new BDContext()))
            {
                distritos = unidad.genericDAL.GetAll().ToList();
            }

            if (usuario.distritoId == null)
            {
                usuario.distritoId = 0;
            }
            //obtener ditrito por usuario
            distrito = obtenerDistritoUsuario((int)usuario.distritoId);

            string textDistrito;
            if (distrito == null)
            {
                textDistrito = "Seleccionar";
            }
            else
            {
                textDistrito = distrito.nombre;
            }
            // valor por defecto distrito por usuario
            perfilUsuarioVM.lista_distrito_usuario.Add(new SelectListItem()
            {
                Text = textDistrito,
                Value = usuario.distritoId.ToString()
            });

            foreach (var itemDistrito in distritos)
            {
                if (usuario.cantonId == itemDistrito.cantonId && usuario.distritoId != itemDistrito.distritoId)
                {
                    perfilUsuarioVM.lista_distrito_usuario.Add(new SelectListItem()
                    {
                        Text = itemDistrito.nombre,
                        Value = itemDistrito.cantonId.ToString()
                    });
                }

            }

            //Asignar ruta de imagen de perfil
            string ruta;

           
            if (usuario.fotoPerfil == null)
            {
                 ruta = "/Content/dist/img/avatar5.png";
                perfilUsuarioVM.imagenUsuario = ruta;
            }
            else
            {
                perfilUsuarioVM.imagenUsuario = usuario.fotoPerfil;
            }
          
            perfilUsuarioVM.id_usuario = usuario.userId;
            perfilUsuarioVM.nombre = usuario.nombre;
            perfilUsuarioVM.apellidos = usuario.apellidos;
            perfilUsuarioVM.correo = usuario.correoElectronico;
            perfilUsuarioVM.Telefono = (int)usuario.telefono;
            perfilUsuarioVM.id_provincia = (int)usuario.provinciaId;
            perfilUsuarioVM.Usuario_ID = usuario.Usuario_ID;
            perfilUsuarioVM.id_canton = canton.cantonId;
            perfilUsuarioVM.id_distrito = distrito.distritoId;
            perfilUsuarioVM.direccion = usuario.direccion;








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
                    fotoPerfil = perfilUsuarioVM.imagenUsuario,
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

       
        //obtener canton por usuario

        public Canton obtenerCantonUsuario(int idDistrito)
        {
            
            Canton canton = new Canton();
            if (idDistrito != 0)
            {

                using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new BDContext()))
                {
                    canton = unidad.genericDAL.Get(idDistrito);
                }
            }
            return canton;
        }

        //obtener distrito por usuario

        public Distrito obtenerDistritoUsuario(int id)
        {
            Distrito distrito = new Distrito();
            if (id != 0)
            {

                using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new BDContext()))
                {
                    distrito = unidad.genericDAL.Get(id);
                }
            }

            return distrito;

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

        //Subir imagenes en el servidor y guardar nombre en la base de datos.
        [HttpPost]
        public ActionResult SubirImagenPerfil(HttpPostedFileBase file)
        {
            
                var id_usuario = Request["id_usuario"];
                var Usuario_ID = Request["Usuario_ID"];
                var nombre = Request["nombre"];
                var apellidos = Request["apellidos"];
                var correo = Request["correo"];
                var telefono = Request["telefono"];
                var direccion = Request["direccion"];
                var provinciaId = Request["id_provincia"];
                var id_canton = Request["id_canton"];
                var id_distrito = Request["id_distrito"];
                //var fotoPerfil = Request.Files["fotoPerfil"]; 


                string ruta = "";

                if (file == null)
                {
                    ruta = "/Content/dist/img/avatar5.png";

                }
                else
                {
                    string archivo = (file.FileName).ToLower();

                    file.SaveAs(Server.MapPath("/Content/dist/img/usuarios/" + archivo));

                    ruta = "/Content/dist/img/usuarios/" + archivo;

                }

                usuarios usuario;

                if (direccion != null)
                {
                    direccion = "No tiene direccion";
                }
                using (UnidadDeTrabajo<usuarios> unidad = new UnidadDeTrabajo<usuarios>(new BDContext()))
                {
                    usuario = new usuarios
                    {
                        userId = Int32.Parse(id_usuario),
                        Usuario_ID = Usuario_ID,
                        nombre = nombre,
                        apellidos = apellidos,
                        telefono = Int32.Parse(telefono),
                        correoElectronico = correo,
                        direccion = direccion,
                        provinciaId = Int32.Parse(provinciaId),
                        cantonId = Int32.Parse(id_canton),
                        distritoId = Int32.Parse(id_distrito),
                        fotoPerfil = ruta,
                    };
                    unidad.genericDAL.Update(usuario);
                    unidad.Complete();
                    //return new HttpStatusCodeResult(HttpStatusCode.OK);

                   return RedirectToAction("Edit","PerfilUsuario" , new { id = id_usuario });
                }
            
            
            
        }

       
    }
}
