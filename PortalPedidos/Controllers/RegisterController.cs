using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalPedidos.Models;

namespace PortalPedidos.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            if (Session["NombreUsuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        

        [HttpPost]
        public ActionResult Index(RegisterModel model) {
            
                if (model.CONTRASEÑA == model.CONFIRMAR_CONTRASEÑA)
                {
                    model.CONTRASEÑA = Helper.Encrypt(model.CONTRASEÑA);
                    using (MEDICFARMAEntities db = new MEDICFARMAEntities())
                    {
                        var exists = db.EMPLEADO.FirstOrDefault(x => x.USUARIO == model.USUARIO);
                        int codigoSucursal = Convert.ToInt32(model.ID_SUCURSAL);
                        var existsSucursal = db.SUCURSAL.FirstOrDefault(y => y.ID_SUCURSAL == codigoSucursal);
                        if (exists == null && existsSucursal != null)
                        {

                            EMPLEADO emp = new EMPLEADO();
                            emp.NOMBRES = model.NOMBRES;
                            emp.APELLIDOS = model.APELLIDOS;
                            emp.USUARIO = model.USUARIO;
                            emp.PASSWORD = model.CONTRASEÑA;
                            emp.ID_SUCURSAL = model.ID_SUCURSAL;
                            emp.CODIGO_EMPLEADO = model.CODIGO_EMPLEADO;
                            emp.DUI = model.DUI;
                            emp.NIT = model.NIT;
                            emp.TELEFONO = model.TELEFONO;
                            emp.DIRECCION = model.DIRECCION;
                            db.EMPLEADO.Add(emp);
                            db.SaveChanges();
                        

                            return RedirectToAction("Index", "AdminEmp");
                        }
                        else {
                            ViewBag.puff = "El Usuario ya existe o el código de confirmacion es incorrecto";
                        }                       
                    }
                }
                else
                {
                    ViewBag.puff = "Las contraseñas no coinciden";
                }
            return View();
        }



        public ActionResult registroAdmin()
        {
            if (Session["NombreUsuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpPost]
        public ActionResult registroAdmin(RegisterAdminModel model)
        {
            if (model.PASSWORD == model.CONFIRMAR_PASSWORD)
            {
                model.PASSWORD = Helper.Encrypt(model.PASSWORD);
                using (MEDICFARMAEntities db = new MEDICFARMAEntities())
                {
                    var existsAdmin = db.ADMINISTRADOR_FARMACIA.FirstOrDefault(x => x.USUARIO == model.USUARIO);
                    var existsFarmacia = db.FARMACIA.FirstOrDefault(x => x.ID_FARMACIA == model.ID_FARMACIA);

                    if (existsAdmin == null && existsFarmacia != null)
                    {
                        ADMINISTRADOR_FARMACIA ad = new ADMINISTRADOR_FARMACIA();
                        ad.CODIGO_ADMINISTRADOR = model.CODIGO_ADMINISTRADOR;
                        ad.ID_FARMACIA = model.ID_FARMACIA;
                        ad.NOMBRES = model.NOMBRES;
                        ad.APELLIDOS = model.APELLIDOS;
                        ad.USUARIO = model.USUARIO;
                        ad.PASSWORD = model.PASSWORD;
                        ad.DUI = model.DUI;
                        ad.NIT = model.NIT;
                        ad.TELEFONO = model.TELEFONO;
                        ad.DIRECCION = model.DIRECCION;
                        db.ADMINISTRADOR_FARMACIA.Add(ad);
                        db.SaveChanges();
                        return RedirectToAction("Master", "AdminEmp");
                    }
                    else
                    {
                        ViewBag.error = "El usuario ya existe o el id farmacia no existe";
                    }
                }
            }
            else
            {
                ViewBag.error = "Las contraseñas no coinciden";

            }

           return View();
        }
    }
}