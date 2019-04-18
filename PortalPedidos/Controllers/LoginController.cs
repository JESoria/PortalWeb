using PortalPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalPedidos.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                using (MEDICFARMAEntities db = new MEDICFARMAEntities())
                {
                    model.clave = Helper.Encrypt(model.clave);

                    if (db.EMPLEADO.Any(x => x.USUARIO == model.usuario && x.PASSWORD == model.clave))
                    {
                        db.EMPLEADO.Where(x => x.USUARIO == model.usuario && x.PASSWORD == model.clave).ToList().ForEach(e =>
                        {
                            db.EMPLEADO.Where(x => x.ID_EMPLEADO == e.ID_EMPLEADO).ToList().ForEach(x =>
                            {
                                db.SUCURSAL.Where(y => y.ID_SUCURSAL == x.ID_SUCURSAL).ToList().ForEach(y =>
                                {
                                    model.sucursal = y.SUCURSAL1;
                                    model.idsucursal = y.ID_SUCURSAL;
                                    model.empleado = e.NOMBRES + " " + e.APELLIDOS;
                                });
                            });
                        });

                        Session["NombreUsuario"] = model.empleado;
                        Session["Sucursal"] = model.sucursal;
                        Session["idSucursal"] = model.idsucursal;

                        return RedirectToAction("Index", "Home");
                    }
                    else if (db.ADMINISTRADOR_FARMACIA.Any(x => x.USUARIO == model.usuario && x.PASSWORD == model.clave))
                    {
                        db.ADMINISTRADOR_FARMACIA.Where(x => x.USUARIO == model.usuario && x.PASSWORD == model.clave).ToList().ForEach(x =>
                        {
                            db.FARMACIA.Where(f => f.ID_FARMACIA == x.ID_FARMACIA).ToList().ForEach(f =>
                            {
                                Session["NombreUsuario"] = x.NOMBRES + " " + x.APELLIDOS;
                                Session["Farmacia"] = f.FARMACIA1;
                                Session["idFarmacia"] = x.ID_FARMACIA;
                            });
                        });

                        return RedirectToAction("Index", "AdminEmp");
                    }
                    else if (db.USUARIO_MASTER_MEDICFARMA.Any(x => x.USUARIO == model.usuario && x.PASSWORD == model.clave))
                    {
                        db.USUARIO_MASTER_MEDICFARMA.Where(x => x.USUARIO == model.usuario && x.PASSWORD == model.clave).ToList().ForEach(x =>
                        {
                            Session["NombreUsuario"] = x.NOMBRES + " " + x.APELLIDOS; 
                        });

                        return RedirectToAction("Master", "AdminEmp");
                    }
                    else {
                        ViewBag.puff = "Usuario y/o contraseña incorrecta";
                    }
                }

            }
            return View(model);
        }


        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}