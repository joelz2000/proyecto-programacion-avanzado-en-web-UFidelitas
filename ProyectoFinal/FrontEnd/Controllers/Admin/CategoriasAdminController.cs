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

        private UnidadDeTrabajo<categorias> unidad_categorias = new UnidadDeTrabajo<categorias>(new BDContext());

        // GET: CategoriasAdmin
        public ActionResult Index()
        {
            List<categorias> categorias;
            using (UnidadDeTrabajo<categorias> unidad = new UnidadDeTrabajo<categorias>(new BDContext()))
            {
                categorias = unidad.genericDAL.GetAll().ToList();
            }
         
            List<CategoriasViewModel> categoriasVM = new List<CategoriasViewModel>();
            CategoriasViewModel categoriaVM;
            

            
            foreach (var item in categorias)
            {
                if (item.id_estado == 1)
                {
                    continue;
                }
                else
                {

                    categoriaVM = new CategoriasViewModel
                    {
                        id_categoria = item.id_categoria,
                        nombre = item.nombre,
                        descripcion = item.descripcion
                    };
                    categoriasVM.Add(categoriaVM);
                    
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
                descripcion = categoria.descripcion,
                id_estado = 2
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
                            descripcion = categoriasViewModel.descripcion,
                            id_estado = 2
                            
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

        // POST: CategoriasAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            // revisar si el URL contiene un ID, si no entonces devolver 404
            if (id == 0 || id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // buscar la categoria y los demas datos
            categorias categoria = unidad_categorias.genericDAL.Get((int)id);
            categoria.id_estado = 1;
            unidad_categorias.genericDAL.Update(categoria);
            unidad_categorias.Complete();

            // devolver que todo bien
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

    }
}
