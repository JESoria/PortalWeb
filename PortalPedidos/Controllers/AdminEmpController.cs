using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalPedidos.Models;

namespace PortalPedidos.Controllers
{
    public class AdminEmpController : Controller
    {
        // GET: AdminEmp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Master()
        {
            return View();
        }

        
        public ActionResult ListAdmin ()
        {
                using (MEDICFARMAEntities db = new MEDICFARMAEntities())
                {
                    List<AdminFarmaciaModel> datos = new List<AdminFarmaciaModel>();

                    db.ADMINISTRADOR_FARMACIA.OrderBy(x => x.ID_ADMINISTRADOR).ToList().ForEach(x =>
                    {
                        db.FARMACIA.Where(f => f.ID_FARMACIA == x.ID_FARMACIA).ToList().ForEach(f =>
                        {
                            datos.Add(new AdminFarmaciaModel()
                            {
                                ID_ADMINISTRADOR = x.ID_ADMINISTRADOR,
                                CODIGO_ADMINISTRADOR = x.CODIGO_ADMINISTRADOR,
                                FARMACIA = f.FARMACIA1,
                                NOMBRES = x.NOMBRES,
                                APELLIDOS = x.APELLIDOS,
                                USUARIO = x.USUARIO,
                                DUI = x.DUI,
                                NIT = x.NIT,
                                DIRECCION = x.DIRECCION,
                                TELEFONO = x.TELEFONO
                            });

                        });
                    });
                    ViewBag.emp = datos;
                }
           
                return View();
        }

        public ActionResult ListEmp()
        {

            using (MEDICFARMAEntities db = new MEDICFARMAEntities())
            {
                List<EmpleadosModel> datos = new List<EmpleadosModel>();
                int idFarma = Convert.ToInt32(Session["idFarmacia"].ToString());

                db.EMPLEADO.OrderBy(x => x.ID_EMPLEADO).ToList().ForEach(x =>
                {
                    db.SUCURSAL.Where(y => y.ID_SUCURSAL == x.ID_SUCURSAL).ToList().ForEach(y =>
                    {
                        db.FARMACIA.Where(z => z.ID_FARMACIA == idFarma).ToList().ForEach(z =>
                        {
                            datos.Add(new EmpleadosModel()
                            {
                                ID_EMPLEADO = x.ID_EMPLEADO,
                                CODIGO_EMPLEADO = x.CODIGO_EMPLEADO,
                                FARMACIA = z.FARMACIA1,
                                SUCURSAL = y.SUCURSAL1,
                                NOMBRES = x.NOMBRES + " " + x.APELLIDOS,
                                USUARIO = x.USUARIO,
                                DUI = x.DUI,
                                NIT = x.NIT,
                                TELEFONO = x.TELEFONO,
                                DIRECCION = x.DIRECCION
                             });
                        });
                    });
                });
                
                ViewBag.empleados = datos;
            }

            return View();
        }


        public ActionResult Delete (string DUI)
        {
            using (MEDICFARMAEntities db = new MEDICFARMAEntities()) {
                var emp = db.ADMINISTRADOR_FARMACIA.FirstOrDefault(x => x.DUI == DUI);
                if (emp != null) {
                    db.ADMINISTRADOR_FARMACIA.Remove(emp);
                    db.SaveChanges();
                }
            }
                return RedirectToAction("ListAdmin", "AdminEmp");
        }

        public ActionResult DeleteEmp (string DUI)
        {
            using (MEDICFARMAEntities db = new MEDICFARMAEntities())
            {
                var emp = db.EMPLEADO.FirstOrDefault(x => x.DUI == DUI);
                if (emp != null)
                {
                    db.EMPLEADO.Remove(emp);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("ListEmp", "AdminEmp");
        }
    }
}