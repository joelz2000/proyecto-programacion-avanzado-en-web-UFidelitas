using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.Admin
{
    [CustomAuthorize(Roles = "Admin")]
    public class HomeAdminController : Controller
    {
        
        // GET: HomeAdmin
        public ActionResult Index()
        {
            return View("~/Views/Admin/HomeAdmin/Index.cshtml");
        }
        
    }
}
