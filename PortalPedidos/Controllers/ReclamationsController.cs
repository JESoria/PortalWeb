using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalPedidos.Models;

namespace PortalPedidos.Controllers
{
    public class ReclamationsController : Controller
    {
        // GET: Reclamations
        public ActionResult Index()
        {
            using (MEDICFARMAEntities db = new MEDICFARMAEntities()) {
                List<ReclamosModel> reclamos = new List<ReclamosModel>();
                db.INCIDENCIA.OrderBy(x => x.ID_INCIDENCIA).Where(x =>x.ESTADO.Equals("SIN RESOLVER")).ToList().ForEach(x =>
                {
                    db.PEDIDO.Where(y => y.ID_PEDIDO == x.ID_PEDIDO).ToList().ForEach(y =>
                    {
                        db.USUARIO.Where(z => z.ID_USUARIO == y.ID_USUARIO).ToList().ForEach(z =>
                        {
                            reclamos.Add(new ReclamosModel()
                            {
                                idIncidencia = x.ID_INCIDENCIA,
                                idPedido = x.ID_PEDIDO,
                                FechaIncidencia = x.FECHA_INCIDENCIA,
                                estado = x.ESTADO,
                                cliente = z.NOMBRES + " " + z.APELLIDOS,
                                telefono = y.TELEFONO,
                                incidencia = x.INCIDENCIA1
                            });
                        });
                    });
                });
                ViewBag.reclamos = reclamos;
            }
                return View();
        }

        [HttpPost]
        public ActionResult cambiarEstadoReclamo(int ID_PEDIDO) {
            ViewBag.id = ID_PEDIDO;
            return View();
        }
    }
}