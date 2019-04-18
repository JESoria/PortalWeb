using PortalPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalPedidos.Controllers
{
    public class DetalleController : Controller
    {
        // GET: Detalle
        public ActionResult Index(int  ID_PEDIDO)
        {
            
            //ViewBag.x = detalle;
            // ViewBag.x = model.detalle;
            List<DETALLE_PEDIDO> detalle = new List<DETALLE_PEDIDO>();
            int id = Convert.ToInt32(Session["idSucursal"].ToString());
            using (MEDICFARMAEntities db = new MEDICFARMAEntities()) {
                db.DETALLE_PEDIDO.Where(x => x.ID_PEDIDO == ID_PEDIDO).ToList().ForEach(x =>
                {
                    detalle.Add(new DETALLE_PEDIDO() {
                        CANTIDAD = x.CANTIDAD,
                        PRODUCTO = x.PRODUCTO,
                        PRECIO_VENTA = x.PRECIO_VENTA
                    });
                });
                ViewBag.x = detalle;
                ViewBag.i = ID_PEDIDO;
            }
            if (ViewBag.x != null)
            {
                return View();
            }
            else
            {
                TempData["alertMessage"] = "NO HAY PEDIDOS PARA MOSTRAR";
                return View();
            }
        }
    }
}
