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
    
    public partial class VerAsistencia_Result
    {
        public int ID_Asistencia { get; set; }
        public int ID_Estudiante { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Nullable<System.DateTime> Fecha_Asistencia { get; set; }
        public int ID_Estado { get; set; }
        public string NombreEstado { get; set; }
        public int ID_Clase { get; set; }
        public string NombreCurso { get; set; }
        public string NombreGrado { get; set; }
        public bool Activo { get; set; }
    }
}
