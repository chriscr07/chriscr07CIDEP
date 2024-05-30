using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entity
{
    public class CalificacionEntity
    {
        public int ID_Calificacion {  get; set; }
        public int ID_Usuario {  get; set; }
        public int ID_Estudiante {  get; set; }
        public decimal Calificacion {  get; set; }
        public DateTime FechaCalificacion { get; set; }
        public int ID_Clase { get; set; }
        public int ID_TipoEvaluacion { get; set; }
        public decimal PorcentajeTotal { get; set; }
        public string TipoEvaluacion { get; set; }
        public string NombreCurso { get; set; }
        public string Retroalimentacion { get; set; }
        public string NombreGrado { get; set; }

        public string Grado { get; set; }
        public string Estudiante { get; set; }
    }
}