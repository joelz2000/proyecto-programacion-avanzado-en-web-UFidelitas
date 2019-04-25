using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using IronPdf;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.User
{
    [CustomAuthorize(Roles = "Usuario")]
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
                    facturacionId = (int)id_factura.Column1,
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

                //generar factura PDF

                generarFactura((int)id_factura.Column1);
                
                
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
        public void generarFactura(int idfactura)
        {
            List<facturacion_producto> productosFacturacion;
            List<productos> productos;
            List<facturaciones> facturaciones;

            //lista productos por facturacion
            using (UnidadDeTrabajo<facturacion_producto> unidad = new UnidadDeTrabajo<facturacion_producto>(new BDContext()))
            {
                productosFacturacion = unidad.genericDAL.GetAll().ToList();
            }

            //lista productos
            using (UnidadDeTrabajo<productos> unidad = new UnidadDeTrabajo<productos>(new BDContext()))
            {
                productos = unidad.genericDAL.GetAll().ToList();
            }

            //lista factruaciones
            using (UnidadDeTrabajo<facturaciones> unidad = new UnidadDeTrabajo<facturaciones>(new BDContext()))
            {
                facturaciones = unidad.genericDAL.GetAll().ToList();
            }

          
            //objeto producto
            productos producto = new productos();

            //objeto facturaciones
            facturaciones facturacion = new facturaciones();

            using (UnidadDeTrabajo<facturaciones> unidad = new UnidadDeTrabajo<facturaciones>(new BDContext()))
            {
                facturacion = unidad.genericDAL.Get(idfactura);
            }
            var Renderer = new HtmlToPdf();

            var html = @" 
                    <!doctype html>
                    <html>
                    <head>
                        <meta charset=""utf-8"">
                          <title> Factura </title>
  
                          <style>
                            .invoice-container {
                                max-width: 800px;
                                margin: auto;
                                padding: 30px;
                                border: 1px solid #eee;
                                box-shadow: 0 0 10px rgba(0, 0, 0, .15);
                                font-size: 16px;
                                line-height: 24px;
                                font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
                                color: #555;
                            }

                                .invoice-container table {
                                    width: 100%;
                                    line-height: inherit;
                                    text-align: left;
                                }

                                    .invoice-container table td {
                                        padding: 5px;
                                        vertical-align: top;
                                    }

                                    .invoice-container table tr td:nth-child(2) {
                                        text-align: right;
                                    }

                                    .invoice-container table tr.top table td {
                                        padding-bottom: 20px;
                                    }

                                        .invoice-container table tr.top table td.title {
                                            font-size: 45px;
                                            line-height: 45px;
                                            color: #333;
                                        }

                                    .invoice-container table tr.information table td {
                                        padding-bottom: 40px;
                                    }

                                    .invoice-container table tr.heading td {
                                        background: #eee;
                                        border-bottom: 1px solid #ddd;
                                        font-weight: bold;
                                    }

                                    .invoice-container table tr.details td {
                                        padding-bottom: 20px;
                                    }

                                    .invoice-container table tr.item td {
                                        border-bottom: 1px solid #eee;
                                    }

                                    .invoice-container table tr.item.last td {
                                        border-bottom: none;
                                    }

                                    .invoice-container table tr.total td:nth-child(2) {
                                        border-top: 2px solid #eee;
                                        font-weight: bold;
                                    }

                            @@media only print {
                                .invoice-container table tr.top table td {
                                    width: 100%;
                                    display: block;
                                    text-align: center;
                                }

                                .invoice-container table tr.information table td {
                                    width: 100%;
                                    display: block;
                                    text-align: center;
                                }
                            }
                        </style>
                         </head>
                     <body>
                        <div class=""invoice-container"">
                                <table cellpadding=""0"" cellspacing =""0"">
     
                                    <tr class=""top"">
                                        <td colspan=""2"">
                                            <table>
                                                <tr>
                                                    <td class=""title"">
                                                        Amaz@n.Cr
                                                    </td>
                                                    <td>
                                                        Numero de Factura:" + idfactura + @"<br>
                                                        Fecha de la compra:" + facturacion.fecha + @"<br>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                </tr>
                                <tr class=""information"">
                                    <td colspan= ""2"">
                                        <table>
                                            <tr>
                                                <td>
                                                    Amaz@n Cr, Inc.<br>
                                                    Rohmoser Pavas<br>
                                                    San Jose , Costa Rica
                                                    
                                                </td>
                                                <td>
                                                    2295-4909 <br>
                                                    Dudas o consultas : servicio-cliente@amazoncr.com
                                                </td>
                                            </tr>
                                        </table>
                                     </td>
                                 </tr>
 
                                <tr class=""heading"">
                                    <td>
                                        Nombre del Producto
                                    </td>
                                    <td>
                                        Cantidad
                                    </td>
                                    <td>Precio</td>
                                </tr>";

            
            foreach (var itemProductoFacturacion in productosFacturacion)
            {
                if (itemProductoFacturacion.id_estado == 1)
                {
                    continue;
                }
                else
                {

                    if (itemProductoFacturacion.facturacionId == idfactura)
                    {

                        //facturaciones

                        foreach (var itemFacturaciones in facturaciones)
                        {
                            if (itemFacturaciones.facturacionId == itemProductoFacturacion.facturacionId)
                            {
                                facturacion = new facturaciones
                                {
                                    facturacionId = itemFacturaciones.facturacionId,
                                    nombre = itemFacturaciones.nombre,
                                    total = itemFacturaciones.total,
                                    subtotal= itemFacturaciones.subtotal
                                };
                            }


                        }
                        
                        //productos
                        foreach (var itemProducto in productos)
                        {
                            if (itemProducto.productoId == itemProductoFacturacion.productoId)
                            {
                                producto = new productos
                                {
                                    productoId = itemProducto.productoId,
                                    nombre = itemProducto.nombre,
                                    precio = itemProducto.precio
                                };

                                html += @"<tr class=""item"">
                                            <td>" + producto.nombre + @"</td>
                                            <td>" + itemProductoFacturacion.cantidad + @"</td>
                                            <td>" + producto.precio + @"</td>
                                        </tr>";
                            }

                                
                        }

                    }
                }
            }

                        html += @"
                                <br><br>
                                <tr class=""total"">
                                    <td></td>
                                    <td>IVA:</td>
                                    <td>13%</td>
                                </tr>
                                <tr class=""total"">
                                    <td></td>
                                    <td>Subtotal:</td>
                                    <td>" + facturacion.subtotal + @"</td>

                                </tr>
                                <tr class=""total"">
                                    <td></td>
                                    <td>Total:</td>
                                    <td>" + facturacion.total + @"</td>

                                </tr>


                           </table>
                       </div>
                    </body>
                    </html>

                    ";
            /*  FacturacionPDF facturacionPDF;

              facturacionPDF = new FacturacionPDF
              {
                  nombreProducto = producto.nombre,
                  idFacturacion = facturacion.facturacionId,
                  nombreFactura = facturacion.nombre,
                  subtotal = facturacion.subtotal,
                  precio = producto.precio,
                  fecha = facturacion.fecha
              };

              List<FacturacionPDF> facturacionesPDF = new List<FacturacionPDF>();
              facturacionesPDF.Add(facturacionPDF);*/

         
            var PDF = Renderer.RenderHtmlAsPdf(html);

            // save resulting pdf into file
            PDF.SaveAs("~/Content/dist/facturacionesPDF/"+facturacion.nombre+facturacion.facturacionId+".pdf");

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
