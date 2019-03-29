using FrontEnd.Models;
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
        // GET: Carrito
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Usuario")) 
            {
                return View("~/Views/User/Carrito/Index.cshtml");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
        }

        // POST: HomeAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AgregarProductoViewModels productoVM)
        {
            return View();
        }


    }
}