using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helper;
using Model;
using proyecto.Areas.Admin.Filters;

namespace proyecto.Controllers
{
    [Autenticado]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}