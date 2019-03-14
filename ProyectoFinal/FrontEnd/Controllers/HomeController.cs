using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static BDContext context = new BDContext();
        private UnidadDeTrabajo<usuarios> unidad_Usuario = new UnidadDeTrabajo<usuarios>(context);
        public ActionResult Index()
        {

            // usuarios usuario = context.usuarios.Where(u => u.Usuario_ID.Equals(User.Identity.GetUserId())).Single();

            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}