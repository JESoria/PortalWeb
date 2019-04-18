using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalPedidos.Models
{
    public class OrdersModel
    {
        public DateTime FechaRecibido { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Usuario { get; set; }
        public string Direccion { get; set; }
        public double TotalCompra { get; set; }
        public int idPedido { get; set; }
        public string Telefono { get; set; }
        public List<DETALLE_PEDIDO> detalle { get; set; }
        public string sucursal { get; set; }
        public string idsucursal { get; set; }
        public string estado_pedido { get; set; }
        public string estado_pago  { get; set; }
        public string forma_pago { get; set; }
        public string codigo_pedido { get; set; }
    }
}