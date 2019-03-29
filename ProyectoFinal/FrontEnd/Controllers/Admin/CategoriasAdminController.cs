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
            List<estados> estadoBD;
            using (UnidadDeTrabajo<estados> unidad = new UnidadDeTrabajo<estados>(new BDContext()))
            {
                estadoBD = unidad.genericDAL.GetAll().ToList();
            }

            List<CategoriasViewModel> categoriasVM = new List<CategoriasViewModel>();
            CategoriasViewModel categoriaVM;
            estados estados = new estados();

            
            foreach (var item in categorias)
            {
                if (item.id_estado == 1)
                {
                    continue;
                }
                else
                {
                    foreach (var itemEstado in estadoBD)
                    {
                        if (item.id_estado == itemEstado.id_estado)
                        {
                            categoriaVM = new CategoriasViewModel
                            {
                                id_categoria = item.id_categoria,
                                nombre = item.nombre,
                                descripcion = item.descripcion,
                                estado = itemEstado.estado
                            };
                            categoriasVM.Add(categoriaVM);
                            break;
                        }
                    }
                }
                
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriasViewModel categoriaVM)
        {
            try
            {
                // TODO: Add insert logic here
                categorias categoria = new categorias
                {
                    nombre = categoriaVM.nombre,
                    descripcion = categoriaVM.descripcion,
                    id_estado = 2
                };
                if (categoria.nombre != null)
                {
                    using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
                    {
                        unidad.genericDAL.Add(categoria);
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

        // GET: CategoriasAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            // revisar si el URL contiene un ID, si no entonces devolver 404
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriasViewModel categoriasViewModel;
            categorias categoria;

            // ver si el producto tiene estado bloqueado. Si si, devolver 404
            


            using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
            {
                categoria = unidad.genericDAL.Get(id);
            }

            if (categoria.id_estado == 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                if (ModelState.IsValid)
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
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }


                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: CategoriasAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                categorias categoria;
                using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
                {

                    categoria= unidad.genericDAL.Get(id);
                }
                using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
                {
                 
                    unidad.genericDAL.Remove(categoria);
                    unidad.Complete();
                }
                Session["mensaje"] =
                       "<div class='alert alert-success alert-dismissible'>" +
                       "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                       "   <h4><i class='icon fa fa-check'></i> Alerta!</h4>" +
                       "      Categoria Eliminada Correctamente" +
                       "</div> ";
                return RedirectToAction("Index");
            }
            catch
            {
                Session["mensaje"] =
                      "<div class='alertalert-danger alert-dismissible'>" +
                      "   <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
                      "   <h4><i class='icon fa fa-ban'></i> Alerta!</h4>" +
                      "      Categoria Eliminada Correctamente" +
                      "</div> ";
                return View("~/Views/Admin/CategoriasAdmin/Index.cshtml");
            }
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
