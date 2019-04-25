using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalPedidos.Controllers
{
    public class StatusReclamationController : Controller
    {
        // GET: StatusReclamation
        public ActionResult Index(int ID_PEDIDO, int ID_INCIDENCIA)
        {
            if (Session["NombreUsuario"] != null)
            {
                ViewBag.idP = ID_PEDIDO;
                ViewBag.idI = ID_INCIDENCIA;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        
    }
}