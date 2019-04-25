using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalPedidos.Models;

namespace PortalPedidos.Controllers
{
    public class OrderStatusController : Controller
    {
        // GET: OrderStatus
         public ActionResult Index()
         {
             return View();
         }
        

        public ActionResult Entrega(int ID_PEDIDO)
        {
            using (MEDICFARMAEntities db = new MEDICFARMAEntities())
            {
                var pedido = db.PEDIDO.Where(x => x.ID_PEDIDO == ID_PEDIDO);
                pedido.FirstOrDefault().ESTADO_PEDIDO = "ENTREGADO";
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Pago(int ID_PEDIDO)
        {
            using (MEDICFARMAEntities db = new MEDICFARMAEntities())
            {
                var pedido = db.PEDIDO.Where(x => x.ID_PEDIDO == ID_PEDIDO);
                pedido.FirstOrDefault().ESTADO_PAGO = "PAGADO";
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Reclamo(int ID_PEDIDO, string Observaciones) {
            using (MEDICFARMAEntities db = new MEDICFARMAEntities()) {
                var reclamo = db.INCIDENCIA.Where(x => x.ID_PEDIDO == ID_PEDIDO);
                reclamo.FirstOrDefault().ESTADO = "RESUELTO";
                reclamo.FirstOrDefault().OBSERVACION = Observaciones;
                reclamo.FirstOrDefault().FECHA_RESUELTO = DateTime.Now;
                db.SaveChanges();
            }
                return RedirectToAction("Index", "Reclamations");
        }
    }
}