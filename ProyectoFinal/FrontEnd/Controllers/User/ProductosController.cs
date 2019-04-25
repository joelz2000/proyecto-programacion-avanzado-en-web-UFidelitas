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
    public class ProductosController : Controller
    {

        // unidades de trabajo para obtener datos necesarios
        private UnidadDeTrabajo<productos> unidad_productos = new UnidadDeTrabajo<productos>(new BDContext());
        private UnidadDeTrabajo<categorias> unidad_categorias = new UnidadDeTrabajo<categorias>(new BDContext());
        private UnidadDeTrabajo<marcas> unidad_marcas = new UnidadDeTrabajo<marcas>(new BDContext());
        private UnidadDeTrabajo<colecciones> unidad_colecciones = new UnidadDeTrabajo<colecciones>(new BDContext());
        private UnidadDeTrabajo<distribuidor> unidad_distribuidor = new UnidadDeTrabajo<distribuidor>(new BDContext());

        // GET: Productos
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Productos/Detalles/5
        public ActionResult Detalles(int? id)
        {

            if (!User.IsInRole("Usuario"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            // revisar si el URL contiene un ID, si no entonces devolver 404
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // buscar el producto y los demas datos
            productos producto = unidad_productos.genericDAL.Get((int)id);
            marcas marca = unidad_marcas.genericDAL.Get((int)producto.id_marca);
            colecciones coleccion = unidad_colecciones.genericDAL.Get((int)producto.id_coleccion);
            categorias categoria = unidad_categorias.genericDAL.Get((int)producto.id_categoria);
            distribuidor distribuidor = unidad_distribuidor.genericDAL.Get((int)producto.id_distribuidor);

            // ver si el producto tiene estado bloqueado. Si si, devolver 404
            if (producto.id_estado == 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // asignar datos al view model correspondiente
            DetallesProductoViewModels producto_VM = new DetallesProductoViewModels
            {
                Id_Producto = producto.productoId,
                Nombre = producto.nombre,
                Precio = producto.precio,
                Descripcion = producto.descripcion,
                Modelo = producto.modelo,
                marca = marca.nombre,
                coleccion = coleccion.nombre,
                categoria = categoria.nombre,
                distribuidor = distribuidor.nombre
            };

            return View(producto_VM);
        }
    }
}