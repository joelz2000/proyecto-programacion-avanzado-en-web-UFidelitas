using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private static BDContext context = new BDContext();
        private UnidadDeTrabajo<usuarios> unidad_Usuario = new UnidadDeTrabajo<usuarios>(context);

        // unidades de trabajo para obtener datos necesarios
        private UnidadDeTrabajo<productos> unidad_productos = new UnidadDeTrabajo<productos>(new BDContext());
        private UnidadDeTrabajo<categorias> unidad_categorias = new UnidadDeTrabajo<categorias>(new BDContext());
        private UnidadDeTrabajo<marcas> unidad_marcas = new UnidadDeTrabajo<marcas>(new BDContext());
        private UnidadDeTrabajo<colecciones> unidad_colecciones = new UnidadDeTrabajo<colecciones>(new BDContext());
        private UnidadDeTrabajo<distribuidor> unidad_distribuidor = new UnidadDeTrabajo<distribuidor>(new BDContext());

        public ActionResult Index()
        {
            // revisar si el usuario no es administrador
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
            // usuario no es admin, continuar
            else
            {
                List<productos> lista_productos = unidad_productos.genericDAL.GetAll().ToList();
                List<marcas> lista_marcas = unidad_marcas.genericDAL.GetAll().ToList();
                IndexProductoViewModels producto_VM;
                List<IndexProductoViewModels> lista_productos_VM = new List<IndexProductoViewModels>();

                // asignar valores correspondientes
                foreach (var producto in lista_productos)
                {
                    // no tomar en cuenta los productos con estado bloqueado
                    if (producto.id_estado == 1)
                    {
                        continue;
                    }
                    else
                    {
                        foreach (var marca in lista_marcas)
                        {
                            if (marca.id_marca == producto.id_marca)
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
                }

                return View(lista_productos_VM);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}