//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TecnicoWeb3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Seguridad
    {
        public string Detalles { get; set; }
        public System.DateTime Tiempo { get; set; }
        public string Tecnico_DNI { get; set; }
    
        public virtual Tecnico Tecnico { get; set; }
    }
}
