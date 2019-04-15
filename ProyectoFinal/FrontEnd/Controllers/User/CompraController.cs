using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.User
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            UsuarioInfoCompraViewModel compraVM = new UsuarioInfoCompraViewModel();
            BDContext context = new BDContext();
            UnidadDeTrabajo<Provincia> unidad_provincias = new UnidadDeTrabajo<Provincia>(context);
            List<Provincia> lista_provincias = new List<Provincia>();
            lista_provincias = unidad_provincias.genericDAL.GetAll().ToList();

            // valor por defecto
            compraVM.lista_provincias.Add(new SelectListItem()
            {
                Text = "Seleccionar",
                Value = "0"
            });

            foreach (var provincia in lista_provincias)
            {
                compraVM.lista_provincias.Add(new SelectListItem()
                {
                    Text = provincia.nombre,
                    Value = provincia.provinciaId.ToString()
                });
            }

            return View("~/Views/User/Compra/Index.cshtml", compraVM);
        }

        public ActionResult Procesar(UsuarioInfoCompraViewModel compraVM)
        {
            UnidadDeTrabajo<productos> unidad_productos = new UnidadDeTrabajo<productos>(new BDContext());
            UnidadDeTrabajo<facturaciones> unidad_facturaciones = new UnidadDeTrabajo<facturaciones>(new BDContext());
            UnidadDeTrabajo<usuario_facturaciones> unidad_usuario_facturaciones = new UnidadDeTrabajo<usuario_facturaciones>(new BDContext());
            UnidadDeTrabajo<facturacion_producto> unidad_facturacion_producto = new UnidadDeTrabajo<facturacion_producto>(new BDContext());
            BDContext context = new BDContext();

            try
            {
                // obtener el id del usuario que esta logueado
                var userID = User.Identity.GetUserId();

                // obtener el usuario con ese id de base de datos
                var usuario_BD = context.usuarios.Where(u => u.Usuario_ID.Equals(userID)).Single();

                // obtener todos los productos en su carrito
                List<sp_obtenerProductosUsuarioCarrito_Result> lista_productos_cliente = context.sp_obtenerProductosUsuarioCarrito(usuario_BD.userId).ToList();
                productos producto_BD;

                // calcular total y subtotal
                double total = 0, subtotal = 0, impuesto = 0.13;
                foreach (var producto in lista_productos_cliente)
                {
                    producto_BD = unidad_productos.genericDAL.Get(producto.productoId);
                    subtotal += (double)(producto.cantidad_producto * producto_BD.precio);
                }
                impuesto = impuesto * subtotal;
                total = subtotal + impuesto;

                // obtener el siguiente id de facturaciones
                sp_obtenerUltimoIdFactura_Result2 id_factura = context.sp_obtenerUltimoIdFactura().FirstOrDefault();

                // crear una nueva factura
                facturaciones factura = new facturaciones
                {
                    nombre = compraVM.nombre_tarjeta,
                    fecha = DateTime.UtcNow,
                    impuesto = 13,
                    subtotal = subtotal,
                    total = total,
                    id_estado = 2
                };

                // agregar factura
                unidad_facturaciones.genericDAL.Add(factura);
                unidad_facturaciones.Complete();

                // asignar factura a usuario
                usuario_facturaciones factura_usuario = new usuario_facturaciones
                {
                    usuarioId = usuario_BD.userId,
                    facturacionId = (int) id_factura.Column1,
                    id_estado = 2
                };
                unidad_usuario_facturaciones.genericDAL.Add(factura_usuario);
                unidad_usuario_facturaciones.Complete();

                // asignar productos a factura
                /*facturacion_producto facturacion_producto;
                List<facturacion_producto> lista_facturaciones_producto = new List<facturacion_producto>();*/

                IProductosFacturacionDAL productosFacturacionDAL = new ProductosFacturacionDALImpl();

                sp_obtenerFacturacionesProducto_Result facturacionProducto;
                foreach (var producto in lista_productos_cliente)
                {
                    /*facturacion_producto = new facturacion_producto
                    {
                        productoId = producto.productoId,
                        cantidad = producto.cantidad_producto,
                        id_estado = 2,
                        facturacionId = (int)id_factura.Column1,
                    };
                    lista_facturaciones_producto.Add(facturacion_producto);*/

                    facturacionProducto = new sp_obtenerFacturacionesProducto_Result
                    {
                        productoId = producto.productoId,
                        facturacionId = (int)id_factura.Column1,
                        cantidad = producto.cantidad_producto,
                        id_estado = 2
                    };

                    productosFacturacionDAL.agregarProductoFacturacion(facturacionProducto);

                }

               /* unidad_facturacion_producto.genericDAL.AddRange(lista_facturaciones_producto);
                unidad_facturacion_producto.Complete();
                */
                // limipar el carrito del usuario
                context.sp_eliminarCarritoCliente(usuario_BD.userId);

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
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
