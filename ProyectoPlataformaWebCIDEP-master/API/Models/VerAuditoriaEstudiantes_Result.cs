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
    
    public partial class VerAuditoriaEstudiantes_Result
    {
        public int ID_AuditoriaEstudiante { get; set; }
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string NombreEstudiante { get; set; }
        public string Accion { get; set; }
        public string Detalles { get; set; }
        public System.DateTime Fecha_Accion { get; set; }
    }
}
