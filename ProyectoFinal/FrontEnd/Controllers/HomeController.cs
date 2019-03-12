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
        private UnidadDeTrabajo<usuarios> unidad_Usuario = new UnidadDeTrabajo<usuarios>(new BDContext());
        public ActionResult Index()
        {
            var usuario = User.Identity.GetUserId();

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