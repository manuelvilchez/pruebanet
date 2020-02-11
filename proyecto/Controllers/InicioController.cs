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
    
    public class InicioController : Controller
    {
        private Usuario usuario = new Usuario();

        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string correo, string clave)
        {
            var rm = usuario.Acceder(correo, clave);

            if (rm.response)
            {
                rm.href = Url.Content("~/renting/index");
            }

            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/inicio/index");
        }
    }
}