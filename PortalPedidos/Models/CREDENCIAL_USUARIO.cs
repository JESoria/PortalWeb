//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortalPedidos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CREDENCIAL_USUARIO
    {
        public int ID_CREDENCIAL_USUARIO { get; set; }
        public int ID_USUARIO { get; set; }
        public string USUARIO { get; set; }
        public string PASSWORD { get; set; }
        public string ESTADO { get; set; }
    
        public virtual USUARIO USUARIO1 { get; set; }
    }
}
