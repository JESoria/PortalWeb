using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalPedidos.Models
{
    public class EmpleadosModel
    {
        public int ID_EMPLEADO { get; set; }
        public string CODIGO_EMPLEADO { get; set; }
        public string FARMACIA { get; set; }
        public string SUCURSAL { get; set; }
        public string NOMBRES { get; set; }
        public string USUARIO { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public string TELEFONO { get; set; }
        public string DIRECCION { get; set; }
    }
}