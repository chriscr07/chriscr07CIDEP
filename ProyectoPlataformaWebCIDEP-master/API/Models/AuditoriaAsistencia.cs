//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuditoriaAsistencia
    {
        public int ID_AuditoriaAsistencia { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Asistencia { get; set; }
        public string Accion { get; set; }
        public string Detalles { get; set; }
        public System.DateTime Fecha_Accion { get; set; }
    
        public virtual Asistencia Asistencia { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
