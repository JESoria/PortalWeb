using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalPedidos.Models
{
    public class RegisterAdminModel
    {
        [Required(ErrorMessage = "El campo codigo es requerido")]
        public string CODIGO_ADMINISTRADOR { get; set; }

        [Required(ErrorMessage = "El campo farmacia es requerido")]
        public int ID_FARMACIA { get; set; }

        [Required(ErrorMessage = "El campo nombres es requerido")]
        public string NOMBRES { get; set; }

        [Required(ErrorMessage = "El campo apellidos es requerido")]
        public string APELLIDOS { get; set; }

        [Required(ErrorMessage = "El campo usuario es requerido")]
        public string USUARIO { get; set; }

        [Required(ErrorMessage = "El campo password es requerido")]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }

        [Required(ErrorMessage = "El campo confirmar password es requerido")]
        [DataType(DataType.Password)]
        public string CONFIRMAR_PASSWORD  { get; set; }

        [Required(ErrorMessage = "El campo dui es requerido")]
        public string DUI { get; set; }

        [Required(ErrorMessage = "El campo nit es requerido")]
        public string NIT { get; set; }

        [Required(ErrorMessage = "El campo telefono es requerido")]
        public string TELEFONO { get; set; }

        [Required(ErrorMessage = "El campo direccion es requerido")]
        public string DIRECCION { get; set; }

    }
}