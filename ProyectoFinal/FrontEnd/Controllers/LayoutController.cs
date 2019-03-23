using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNet.Identity;

namespace FrontEnd.Controllers.Admin
{
    public class LayoutController : Controller
    {

        private static BDContext context = new BDContext();
        private UnidadDeTrabajo<usuarios> unidad_Usuario = new UnidadDeTrabajo<usuarios>(context);

        // GET: Layout/Navbar
        [ChildActionOnly]
        public virtual PartialViewResult Navbar()
        {

            string usuario_id = User.Identity.GetUserId();
            // usuarios usuario = context.sp_obtenerUsuarioPorIDUsuario(usuario_id).FirstOrDefault();
            usuarios usuario = context.usuarios.Where(u => u.Usuario_ID.Equals(usuario_id)).FirstOrDefault();
            NavbarUsuarioViewModel info_usuario = new NavbarUsuarioViewModel();
            info_usuario.nombre = usuario.nombre + " " + usuario.apellidos;
            if (User.IsInRole("Admin"))
            {
                return PartialView("~/Views/Admin/Shared/_Login.cshtml", info_usuario);
            }
            else
            {
                return PartialView("~/Views/Shared/_LoginPartial.cshtml", info_usuario);
            }
            
        }
    }
}