using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.User
{
    public class CarritoController : Controller
    {
        private UnidadDeTrabajo<carrito> unidad_carrito = new UnidadDeTrabajo<carrito>(new BDContext());
        private UnidadDeTrabajo<usuarios> unidad_usuario = new UnidadDeTrabajo<usuarios>(new BDContext());
        private UnidadDeTrabajo<marcas> unidad_marcas = new UnidadDeTrabajo<marcas>(new BDContext());
        private UnidadDeTrabajo<productos> unidad_productos = new UnidadDeTrabajo<productos>(new BDContext());

        // GET: Carrito
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Usuario")) 
            {
                BDContext context = new BDContext();

                // obtener el id del usuario que esta logueado
                var userID = User.Identity.GetUserId();

                // obtener el usuario con ese id de base de datos
                var usuario_BD = context.usuarios.Where(u => u.Usuario_ID.Equals(userID)).Single();
                
                // obtener todos los productos en su carrito
                List<sp_obtenerProductosUsuarioCarrito_Result> lista_productos_cliente = context.sp_obtenerProductosUsuarioCarrito(usuario_BD.userId).ToList();
                
                // obtener todos los demas datos necesarios
                List<marcas> lista_marcas = unidad_marcas.genericDAL.GetAll().ToList();
                List<IndexCarritoViewModels> lista_productos_VM = new List<IndexCarritoViewModels>();
                productos producto_BD;
                IndexCarritoViewModels producto_VM;

                // asignar valores correspondientes
                foreach (var producto in lista_productos_cliente)
                {
                    producto_BD = unidad_productos.genericDAL.Get(producto.productoId);

                    // no tomar en cuenta los productos con estado bloqueado
                    if (producto_BD.id_estado == 1)
                    {
                        continue;
                    }
                    else
                    {
                        foreach (var marca in lista_marcas)
                        {
                            if (marca.id_marca == producto_BD.id_marca)
                            {
                                producto_VM = new IndexCarritoViewModels()
                                {
                                    Id_Producto = producto_BD.productoId,
                                    Nombre = producto_BD.nombre,
                                    Precio = producto_BD.precio,
                                    Modelo = producto_BD.modelo,
                                    cantidad = producto.cantidad_producto,
                                    marca = marca.nombre
                                };
                                lista_productos_VM.Add(producto_VM);
                                break;
                            }
                        }
                    }
                }
                return View("~/Views/User/Carrito/Index.cshtml", lista_productos_VM);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
        }

        // POST: HomeAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(DetallesProductoViewModels productoVM)
        {
            BDContext context = new BDContext();

            try
            {
                // obtener el id del usuario que esta logueado
                var userID = User.Identity.GetUserId();

                // obtener el usuario con ese id de base de datos
                var usuario_BD = context.usuarios.Where(u => u.Usuario_ID.Equals(userID)).Single();

                // obtener productos del carrito del usuario
                List<sp_obtenerProductosUsuarioCarrito_Result> lista_productos_cliente = context.sp_obtenerProductosUsuarioCarrito(usuario_BD.userId).ToList();

                // verificar si el usuario ya tiene ese producto en el carrito
                foreach(var producto in lista_productos_cliente)
                {
                    if(producto.productoId == productoVM.Id_Producto)
                    {
                        // usuario ya tiene ese producto en el carrito, preguntar si desea modificar
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }

                // crear el producto que se va a agregar al carrito
                carrito producto_carrito = new carrito
                {
                    productoId = productoVM.Id_Producto,
                    userId = usuario_BD.userId,
                    cantidad_producto = (int)productoVM.cantidad,
                    fecha_agregado = DateTime.UtcNow,
                    fecha_modificado = DateTime.UtcNow
                };

                unidad_carrito.genericDAL.Add(producto_carrito);
                unidad_carrito.Complete();
                
                // devolver http 200
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                // error, devolver http 500
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }


    }
}