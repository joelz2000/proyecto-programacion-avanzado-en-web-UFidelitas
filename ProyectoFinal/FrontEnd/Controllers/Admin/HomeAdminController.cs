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
    public class HomeAdminController : Controller
    {

        // unidades de trabajo para obtener datos necesarios
        private UnidadDeTrabajo<productos> unidad_productos = new UnidadDeTrabajo<productos>(new BDContext());
        private UnidadDeTrabajo<categorias> unidad_categorias = new UnidadDeTrabajo<categorias>(new BDContext());
        private UnidadDeTrabajo<marcas> unidad_marcas = new UnidadDeTrabajo<marcas>(new BDContext());
        private UnidadDeTrabajo<colecciones> unidad_colecciones = new UnidadDeTrabajo<colecciones>(new BDContext());
        private UnidadDeTrabajo<distribuidor> unidad_distribuidor = new UnidadDeTrabajo<distribuidor>(new BDContext());

        // GET: HomeAdmin
        public ActionResult Index()
        {
            
            List<productos> lista_productos = unidad_productos.genericDAL.GetAll().ToList();
            List<marcas> lista_marcas = unidad_marcas.genericDAL.GetAll().ToList();
            IndexProductoViewModels producto_VM;
            List<IndexProductoViewModels> lista_productos_VM = new List<IndexProductoViewModels>();

            // asignar valores correspondientes
            foreach(var producto in lista_productos)
            {
                foreach(var marca in lista_marcas)
                {
                    if(marca.id_marca == producto.id_marca)
                    {
                        producto_VM = new IndexProductoViewModels()
                        {
                            Id_Producto = producto.productoId,
                            Nombre = producto.nombre,
                            Precio = producto.precio,
                            Descripcion = producto.descripcion,
                            Modelo = producto.modelo,
                            cantidad = producto.cantidad,
                            marca = marca.nombre
                        };
                        lista_productos_VM.Add(producto_VM);
                        break;
                    }
                }
            }

            return View("~/Views/Admin/HomeAdmin/Index.cshtml", lista_productos_VM);
        }

        // GET: HomeAdmin/Details/5
        public ActionResult Detalles(int? id)
        {
            // revisar si el URL contiene un ID, si no entonces devolver 404
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // buscar el producto y los demas datos
            productos producto = unidad_productos.genericDAL.Get((int) id);
            marcas marca = unidad_marcas.genericDAL.Get((int) producto.id_marca);
            colecciones coleccion = unidad_colecciones.genericDAL.Get((int) producto.id_coleccion);
            categorias categoria = unidad_categorias.genericDAL.Get((int) producto.id_categoria);
            distribuidor distribuidor = unidad_distribuidor.genericDAL.Get((int) producto.id_distribuidor);

            // asignar datos al view model correspondiente
            DetallesProductoViewModels producto_VM = new DetallesProductoViewModels
            {
                Id_Producto = producto.productoId,
                Nombre = producto.nombre,
                Precio = producto.precio,
                Descripcion = producto.descripcion,
                Modelo = producto.modelo,
                cantidad = producto.cantidad,
                marca = marca.nombre,
                coleccion = coleccion.nombre,
                categoria = categoria.nombre,
                distribuidor = distribuidor.nombre
            };


            return View("~/Views/Admin/HomeAdmin/Detalles.cshtml", producto_VM);
        }

        // GET: HomeAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeAdmin/Create
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

        // GET: HomeAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            return View();
            
        }

        // GET: HomeAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return View();
        }
    }
}
