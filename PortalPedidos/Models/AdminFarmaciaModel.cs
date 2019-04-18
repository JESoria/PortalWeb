using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalPedidos.Models
{
    public class AdminFarmaciaModel
    {
        public int ID_ADMINISTRADOR { get; set; }
        public string CODIGO_ADMINISTRADOR { get; set; }
        public string FARMACIA { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string USUARIO { get; set; }
        public string PASSWORD { get; set; }
        [Required(ErrorMessage = "El campo DUI es requerido")]
        public string DUI { get; set; }
        public string NIT { get; set; }
        public string TELEFONO { get; set; }
        public string DIRECCION { get; set; }
    }
}