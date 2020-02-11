
using System.Web.Mvc;
using Model;
using proyecto.Areas.Admin.Filters;
using System.Linq;
using System.Data.Sql;
using System.Collections.Generic;
using System;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class OrdenController : Controller
    {

        private Orden orden = new Orden();
        private Empresa miempresalista = new Empresa();
        private Sucursal misucursal = new Sucursal();

        private DetalleOrden detalleorden = new DetalleOrden();
        private Hardware inventario = new Hardware();

        private HardwareInfo hwdetail = new HardwareInfo();


        // GET: Admin/Empresa
        public ActionResult Index()

        {
            return View();
        }
        //PARA CONSULTAR LAS CARACTERITICAS COMPLETAS DEL HARDWARE
        public JsonResult GetHardwareDetail(int idhardware = 0)
        {

            var lista_hardwaredetail = hwdetail.GetHardwareDetail(idhardware);

            return Json(lista_hardwaredetail, JsonRequestBehavior.AllowGet);

        }

  

        public ActionResult formatos()

        {
            return View();
        }

        public ActionResult gremission()

        {
            return View();
        }

        public JsonResult CargarOrden(AnexGRID grid)
        {
            return Json(orden.Listar(grid));
        }

        //PARA CARGAR DETALLE ORDEN - 
        //public JsonResult CargarDetalleOrden(AnexGRID grid)
        //{
        //    return Json(orden.ListarDetalleOrden(grid));
        //}



        public ActionResult Crud(int id = 0, int id_em=3)
        {
            //ViewBag.miempresa = miempresalista.ListarEmpresa();

            //para mostrar empresa
            Cascada empresasucursal = new Cascada();
            var list_empresa = empresasucursal.GetEmpresa();
            ViewBag.miempresa = list_empresa;


            return View(
                id == 0 ? new Orden()
                        : orden.Obtener(id)
            );
        }


 


        public JsonResult GetSucursal(int idempresa)
        {

            Cascada sucursal = new Cascada();

            var lista_sucursal = sucursal.GetSucursal(idempresa);

            return Json(lista_sucursal,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCliente(int idempresa)
        {

            Cascada cliente = new Cascada();

            var lista_Cliente = cliente.GetCliente(idempresa);

            return Json(lista_Cliente,JsonRequestBehavior.AllowGet);
        }





        public ActionResult ViewDetailorden(int id)
        {

            //PARA PODER TRAER EL LISTADO DE DETALLEORDEN DE ACUERDO AL ID DEL ORDEN

            ViewBag.InventarioElegido = detalleorden.Listar(id);

            return View(orden.ObtenerVerorden(id));
        }


        [HttpPost]
        public JsonResult Search_Cliente(string Prefix)
        {
            using (ProyectoContext ctx = new ProyectoContext())
            {
                var resultado = (from N in ctx.Cliente.ToList()
                                 where N.nmcliente.ToLower().StartsWith(Prefix.ToLower())
                                 select new { N.nmcliente });

                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
        }

        //Para Buscar Cliente
        [HttpPost]
        public JsonResult Search_Empresa(string Prefix_empresa)
        {
            using (ProyectoContext ctx = new ProyectoContext())
            {
               
                var resultado = (from N in ctx.Empresa.ToList()
                                 where N.nmempresa.ToLower().StartsWith(Prefix_empresa.ToLower())
                                 select new { N.nmempresa });

                return Json(resultado, JsonRequestBehavior.AllowGet);
          
            }
        }


        [HttpPost]
        public JsonResult Search_Sucursal(string Prefix_Sucursal)
        {
            using (ProyectoContext ctx = new ProyectoContext())
            {

                var resultado = (from N in ctx.Sucursal.ToList()
                                 where N.nmsucursal.ToLower().StartsWith(Prefix_Sucursal.ToLower())
                                 select new { N.nmsucursal });

                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
        }


        public JsonResult Guardar(Orden model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    rm.href = Url.Content("~/Admin/orden/");
                }
            }

            return Json(rm);
        }

        public ActionResult Eliminar(int id)
        {
            orden.idorden = id;
            orden.Eliminar();
            return Redirect("~/admin/orden/");
        }


        //Una Vista Parcial
        public PartialViewResult Inventario(int orden_id)
        {

            //lISTAMOS LOS EQUIPOS EN PROCESO

            ViewBag.InventarioElegido = detalleorden.Listar(orden_id);


            //pasamos todos el inventario por un viewbag

            ViewBag.Inventarios = inventario.Todos(orden_id);

            detalleorden.Orden_Id = orden_id;
            return PartialView(detalleorden);

        }


        public JsonResult GuardarInventario(DetalleOrden model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    rm.function = "CargarInventario()";
                }
            }

            return Json(rm);
        }



    }
}