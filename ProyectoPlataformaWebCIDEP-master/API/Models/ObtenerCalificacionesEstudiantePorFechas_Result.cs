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
    
    public partial class ObtenerCalificacionesEstudiantePorFechas_Result
    {
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreCurso { get; set; }
        public string NombreGrado { get; set; }
        public System.DateTime FechaCalificacion { get; set; }
        public string Descripcion { get; set; }
        public decimal Calificacion { get; set; }
        public decimal PorcentajeTotal { get; set; }
        public string Retroalimentacion { get; set; }
        public Nullable<decimal> PorcentajeObtenido { get; set; }
    }
}