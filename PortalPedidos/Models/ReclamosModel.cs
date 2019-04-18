using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalPedidos.Models
{
    public class ReclamosModel
    {
        public int idIncidencia { get; set; }
        public int idPedido  { get; set; }
        public DateTime FechaIncidencia { get; set; }
        public string estado { get; set; }
        public string cliente { get; set; }
        public string telefono { get; set; }
        public string incidencia { get; set; }
    }
}