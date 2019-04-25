using PortalPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalPedidos.Controllers
{
    //en la clase css dar formato a las tablas para centrar y que ocupen el 90%
    //crear una pagina html o una ventana emergente para advertir que la sesion no está iniciada

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title="Pedidos";

            if (Session["NombreUsuario"] != null)
            {
                using (MEDICFARMAEntities db = new MEDICFARMAEntities())
                {
                    List<OrdersModel> pedido = new List<OrdersModel>();
                    int id = Convert.ToInt32(Session["idSucursal"].ToString());

                    db.PEDIDO.OrderBy(x => x.ID_PEDIDO).Where(x => x.ID_SUCURSAL == id && x.ESTADO_PEDIDO.Equals("SIN ENTREGAR") || x.ESTADO_PAGO.Equals("SIN PAGAR")).ToList().ForEach(x =>
                    {
                        db.USUARIO.Where(u => u.ID_USUARIO == x.ID_USUARIO).ToList().ForEach(u =>
                        {
                            pedido.Add(new OrdersModel()
                            {
                                idPedido = x.ID_PEDIDO,
                                codigo_pedido = x.CODIGO_PEDIDO,
                                FechaRecibido = x.FECHA_RECIBIDO,
                                FechaEnvio = Convert.ToDateTime(x.FECHA_ENVIO),
                                Usuario = u.NOMBRES + " " + u.APELLIDOS,
                                Direccion = x.DIRECCION,
                                Telefono = x.TELEFONO,
                                TotalCompra = Convert.ToDouble(x.MONTO_COMPRA),
                                estado_pedido = x.ESTADO_PEDIDO,
                                estado_pago = x.ESTADO_PAGO,
                                detalle = db.DETALLE_PEDIDO.Where(d => d.ID_PEDIDO == x.ID_PEDIDO).ToList()
                            });

                            ViewBag.d = pedido;
                        });
                    });

                    if (ViewBag.d != null)
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
            else {
                return RedirectToAction("Index", "Login");
            }          
        }

        
        public ActionResult Buscar (string fecha)
        {
            ViewBag.Title = "Pedidos";

            if (Session["NombreUsuario"] != null)
            {
                using (MEDICFARMAEntities db = new MEDICFARMAEntities())
                {
                    DateTime date = Convert.ToDateTime(fecha);
                    List<OrdersModel> pedido = new List<OrdersModel>();
                    int id = Convert.ToInt32(Session["idSucursal"].ToString());

                    db.PEDIDO.OrderBy(x => x.ID_PEDIDO).Where(x => x.ID_SUCURSAL == id && x.FECHA_ENVIO == date).ToList().ForEach(x =>
                    {
                        db.USUARIO.Where(u => u.ID_USUARIO == x.ID_USUARIO).ToList().ForEach(u =>
                        {
                            pedido.Add(new OrdersModel()
                            {
                                idPedido = x.ID_PEDIDO,
                                codigo_pedido = x.CODIGO_PEDIDO,
                                FechaRecibido = x.FECHA_RECIBIDO,
                                FechaEnvio = Convert.ToDateTime(x.FECHA_ENVIO),
                                Usuario = u.NOMBRES + " " + u.APELLIDOS,
                                Direccion = x.DIRECCION,
                                Telefono = x.TELEFONO,
                                TotalCompra = Convert.ToDouble(x.MONTO_COMPRA),
                                estado_pedido = x.ESTADO_PEDIDO,
                                estado_pago = x.ESTADO_PAGO,
                                detalle = db.DETALLE_PEDIDO.Where(d => d.ID_PEDIDO == x.ID_PEDIDO).ToList()
                            });

                            ViewBag.d = pedido;
                        });
                    });

                    if (ViewBag.d != null)
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
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}