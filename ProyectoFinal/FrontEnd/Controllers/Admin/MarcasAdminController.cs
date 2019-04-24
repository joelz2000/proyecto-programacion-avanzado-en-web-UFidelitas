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
    public class MarcasAdminController : Controller
    {
        // GET: MarcasAdmin
        public ActionResult Index()
        {
           
            List<marcas> marcas;
            using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
            {
                marcas = unidad.genericDAL.GetAll().ToList();
            }

            List<MarcasViewModel> marcasVM = new List<MarcasViewModel>();
            MarcasViewModel marcaVM;

            foreach (var item in marcas)
            {
                if (item.id_estado == 1)
                {
                    continue;
                }
                else
                {
                    marcaVM = new MarcasViewModel
                    {
                        id_marca = item.id_marca,
                        nombre = item.nombre,
                        descripcion = item.descripcion
                    };
                    marcasVM.Add(marcaVM);
                }
            
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
                    descripcion = marcaVM.descripcion,
                    id_estado = 2
                };

                if (marca.nombre != null)
                {
                    using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
                    {
                        unidad.genericDAL.Add(marca);
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

        // GET: MarcasAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            // revisar si el URL contiene un ID, si no entonces devolver 404
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MarcasViewModel marcasViewModel;
            marcas marca;
            using (UnidadDeTrabajo<marcas> unidad = new UnidadDeTrabajo<marcas>(new BDContext()))
            {
                marca = unidad.genericDAL.Get(id);
            }
            if (marca.id_estado == 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            marcasViewModel = new MarcasViewModel
            {
                id_marca = marca.id_marca,
                nombre = marca.nombre,
                descripcion = marca.descripcion,
            };

            return View("~/Views/Admin/MarcasAdmin/Edit.cshtml", marcasViewModel);
        }

        // POST: CategoriasAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(MarcasViewModel marcasViewModel)
        {
            try
            {
                if (ModelState.IsValid)
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
                        return new HttpStatusCodeResult(HttpStatusCode.OK);
                    }
                }
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

       
        // POST: MarcasAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            // revisar si el URL contiene un ID, si no entonces devolver 404
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marcas marca = new marcas();
            using (UnidadDeTrabajo<marcas> unidad_marca = new UnidadDeTrabajo<marcas>(new BDContext()))
            {
                // buscar el producto y los demas datos
                marca = unidad_marca.genericDAL.Get(id);
                marca.id_estado = 1;

            }

            using (UnidadDeTrabajo<marcas> unidad_marca = new UnidadDeTrabajo<marcas>(new BDContext()))
            {
                unidad_marca.genericDAL.Update(marca);
                unidad_marca.Complete();
            }
            // devolver que todo bien
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}