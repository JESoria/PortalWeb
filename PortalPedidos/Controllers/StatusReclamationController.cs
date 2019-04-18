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
        public ActionResult Index(int ID_PEDIDO)
        {
            ViewBag.idP = ID_PEDIDO;
            return View();
        }
        
    }
}