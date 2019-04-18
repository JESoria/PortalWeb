using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalPedidos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El campo usuario es requerido")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "El campo clave es requerido")]
        public string clave { get; set; }
        public string sucursal { get; set; }
        public int idsucursal { get; set; }
        public string empleado { get; set; }
    }
}