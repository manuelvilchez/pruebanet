﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using proyecto.Areas.Admin.Filters;
namespace proyecto.Areas.Admin.Controllers
{

    [Autenticado]
    public class DefaultController : Controller
    {


        private Reporting thisreport = new Reporting();
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ServiceInventori()
        {
            return View();
        }

        public ActionResult ServiceHelpDesk()
        {
            return View();
        }

        public JsonResult GetEvents()
        {

            using (ProyectoContext dc = new ProyectoContext())
            {
                var events = dc.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        //PARA VERIFICAR LA CANTIDA DE EQUIPOS CLIENTES

        public JsonResult GetRPT_Hardware_produccion()
        {

            var listaequiposproduccion = thisreport.GetRPT_Hardware_produccion();

          

            return Json(listaequiposproduccion, JsonRequestBehavior.AllowGet);

        }





        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;
            using (ProyectoContext dc = new ProyectoContext())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Events.Add(e);
                }

                dc.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (ProyectoContext dc = new ProyectoContext())
            {
                var v = dc.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}