using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.Admin
{
    [CustomAuthorize(Roles = "Admin")]
    public class ProductosAdminController : Controller
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
            foreach (var producto in lista_productos)
            {
                // no tomar en cuenta los productos con estado bloqueado
                if(producto.id_estado == 1)
                {
                    continue;
                }
                else { 
                    foreach (var marca in lista_marcas)
                    {
                        if (marca.id_marca == producto.id_marca)
                        {
                            producto_VM = new IndexProductoViewModels()
                            {
                                Id_Producto = producto.productoId,
                                Nombre = producto.nombre,
                                Precio = producto.precio,
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

            return View("~/Views/Admin/ProductosAdmin/Index.cshtml", lista_productos_VM);
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
            productos producto = unidad_productos.genericDAL.Get((int)id);
            marcas marca = unidad_marcas.genericDAL.Get((int)producto.id_marca);
            colecciones coleccion = unidad_colecciones.genericDAL.Get((int)producto.id_coleccion);
            categorias categoria = unidad_categorias.genericDAL.Get((int)producto.id_categoria);
            distribuidor distribuidor = unidad_distribuidor.genericDAL.Get((int)producto.id_distribuidor);

            // ver si el producto tiene estado bloqueado. Si si, devolver 404
            if(producto.id_estado == 1)
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
                cantidad = producto.cantidad,
                marca = marca.nombre,
                coleccion = coleccion.nombre,
                categoria = categoria.nombre,
                distribuidor = distribuidor.nombre
            };

            return View("~/Views/Admin/ProductosAdmin/Detalles.cshtml", producto_VM);
        }

        // GET: HomeAdmin/Create
        public ActionResult Create()
        {
            List<distribuidor> distribuidores = unidad_distribuidor.genericDAL.GetAll().ToList();
            List<categorias> categorias = unidad_categorias.genericDAL.GetAll().ToList();
            List<marcas> marcas = unidad_marcas.genericDAL.GetAll().ToList();
            List<colecciones> colecciones = unidad_colecciones.genericDAL.GetAll().ToList();

            AgregarProductoViewModels productoVM = new AgregarProductoViewModels();

            foreach (var distribuidor in distribuidores)
            {
               productoVM.lista_distribuidores.Add(new SelectListItem()
               {
                   Text = distribuidor.nombre,
                   Value = distribuidor.id_distribuidor.ToString()
               });
            }

            foreach (var categoria in categorias)
            {
                
                productoVM.lista_categorias.Add(new SelectListItem()
                {
                    Text = categoria.nombre,
                    Value = categoria.id_categoria.ToString()
                });
            }

            foreach (var marca in marcas)
            {
                productoVM.lista_marcas.Add(new SelectListItem()
                {
                    Text = marca.nombre,
                    Value = marca.id_marca.ToString()
                });
            }

            foreach(var coleccion in colecciones)
            {
                productoVM.lista_colecciones.Add(new SelectListItem()
                {
                    Text = coleccion.nombre,
                    Value = coleccion.id_coleccion.ToString()
                });
            }

            return View("~/Views/Admin/ProductosAdmin/Create.cshtml", productoVM);
        }

        // POST: HomeAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgregarProductoViewModels productoVM)
        {
            try
            {
                productos producto = new productos
                {
                    nombre = productoVM.Nombre,
                    precio = productoVM.Precio,
                    descripcion = productoVM.Descripcion,
                    modelo = productoVM.Modelo,
                    cantidad = productoVM.cantidad,
                    id_marca = productoVM.id_marca,
                    id_distribuidor = productoVM.id_distribuidor,
                    id_categoria = productoVM.id_categoria,
                    id_coleccion = productoVM.id_coleccion,
                    id_estado = 2
                };

                unidad_productos.genericDAL.Add(producto);
                unidad_productos.Complete();

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: HomeAdmin/Edit/5
        public ActionResult Editar(int id)
        {
            // revisar si el URL contiene un ID, si no entonces devolver 404
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // buscar el producto y los demas datos
            productos producto = unidad_productos.genericDAL.Get(id);
            List<marcas> lista_marcas = unidad_marcas.genericDAL.GetAll().ToList();
            List<colecciones> lista_colecciones = unidad_colecciones.genericDAL.GetAll().ToList();
            List<categorias> lista_categorias = unidad_categorias.genericDAL.GetAll().ToList();
            List<distribuidor> lista_distribuidor = unidad_distribuidor.genericDAL.GetAll().ToList();

            // ver si el producto tiene estado bloqueado. Si si, devolver 404
            if (producto.id_estado == 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // asignar los valores necesarios al objecto de producto 
            EditarProductoViewModels producto_VM = new EditarProductoViewModels
            {
                Id_Producto = producto.productoId,
                Nombre = producto.nombre,
                Precio = producto.precio,
                Descripcion = producto.descripcion,
                Modelo = producto.modelo,
                cantidad = producto.cantidad
            };

            // obtener el objeto de marcas que tiene todos los datos de la marca del producto
            foreach (var marca in lista_marcas)
            {
                if (producto.id_marca == marca.id_marca)
                {
                    producto_VM.marca = marca;
                    break;
                }
            }

            // obtener el objeto de coleccion que tiene todos los datos de la coleccion del producto
            foreach (var coleccion in lista_colecciones)
            {
                if(producto.id_coleccion == coleccion.id_coleccion)
                {
                    producto_VM.coleccion = coleccion;
                    break;
                }
            }

            // obtener el objeto de coleccion que tiene todos los datos de la coleccion del producto
            foreach(var categoria in lista_categorias)
            {
                if(producto.id_categoria == categoria.id_categoria)
                {
                    producto_VM.categoria = categoria;
                    break;
                }
            }

            // obtener el objeto de coleccion que tiene todos los datos de la coleccion del producto
            foreach(var distribuidor in lista_distribuidor)
            {
                if(producto.id_distribuidor == distribuidor.id_distribuidor)
                {
                    producto_VM.distribuidor = distribuidor;
                    break;
                }
            }

            // agregar a una lista todas las marcas
            foreach (var marca in lista_marcas)
            {
                if (marca.id_marca != producto.id_marca)
                {
                    producto_VM.lista_marcas.Add(new SelectListItem()
                    {
                        Text = marca.nombre,
                        Value = marca.id_marca.ToString()
                    });
                }
            }

            // agregar a una lista todas las colecciones
            foreach (var coleccion in lista_colecciones)
            {
                if (coleccion.id_coleccion != producto.id_coleccion)
                {
                    producto_VM.lista_categorias.Add(new SelectListItem()
                    {
                        Text = coleccion.nombre,
                        Value = coleccion.id_coleccion.ToString()
                    });
                }
            }

            // agregar a una lista todas las categorias
            foreach (var categoria in lista_categorias)
            {
                if(categoria.id_categoria != producto.id_categoria)
                {
                    producto_VM.lista_categorias.Add(new SelectListItem()
                    {
                        Text = categoria.nombre,
                        Value = categoria.id_categoria.ToString()
                    });
                }
            }

            // agregar a una lista todos los distribuidores
            foreach (var distribuidor in lista_distribuidor)
            {
                if(distribuidor.id_distribuidor == producto.id_distribuidor)
                {
                    producto_VM.lista_distribuidores.Add(new SelectListItem()
                    {
                        Text = distribuidor.nombre,
                        Value = distribuidor.id_distribuidor.ToString()
                    });
                }
            }

            producto_VM.lista_marcas.Insert(0, new SelectListItem() { Text = producto_VM.marca.nombre, Value = producto_VM.marca.id_marca.ToString()});
            producto_VM.lista_colecciones.Insert(0, new SelectListItem() { Text = producto_VM.coleccion.nombre, Value = producto_VM.coleccion.id_coleccion.ToString()});
            producto_VM.lista_categorias.Insert(0, new SelectListItem() { Text = producto_VM.categoria.nombre, Value = producto_VM.categoria.id_categoria.ToString()});
            producto_VM.lista_distribuidores.Insert(0, new SelectListItem() { Text = producto_VM.distribuidor.nombre, Value = producto_VM.distribuidor.id_distribuidor.ToString()});


            return View("~/Views/Admin/ProductosAdmin/Editar.cshtml", producto_VM);
        }

        // POST: HomeAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EditarProductoViewModels producto_VM)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    productos producto = new productos
                    {
                        productoId = producto_VM.Id_Producto,
                        nombre = producto_VM.Nombre,
                        precio = producto_VM.Precio,
                        descripcion = producto_VM.Descripcion,
                        modelo = producto_VM.Modelo,
                        cantidad = producto_VM.cantidad,
                        id_marca = producto_VM.id_marca_seleccionada,
                        id_categoria = producto_VM.id_categoria_seleccionada,
                        id_coleccion = producto_VM.id_coleccion_seleccionada,
                        id_distribuidor = producto_VM.id_distribuidor_seleccionado

                    };
                    unidad_productos.genericDAL.Update(producto);
                    unidad_productos.Complete();
                    // devolver que todo bien
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }

                // modelo no valido, devolver error 500
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            catch (DataException /* dex */ )
            {
                // devolver error 500
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

        }
       
        // POST: HomeAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            // revisar si el URL contiene un ID, si no entonces devolver 404
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // buscar el producto y los demas datos
            productos producto = unidad_productos.genericDAL.Get(id);
            producto.id_estado = 1;
            unidad_productos.genericDAL.Update(producto);
            unidad_productos.Complete();

            // devolver que todo bien
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}