using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entity
{
    public class AsistenciaEntity
    {
        public int ID_Asistencia { get; set; }
        public int ID_Estudiante { get; set; }
        public DateTime Fecha_Asistencia { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public int ID_Estado { get; set; }
        public int ID_Clase { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int ID_Usuario { get; set; }
        public int RolUsuario { get; set; }
        public string NombreCurso { get; set; }
        public string NombreGrado { get; set; }
        public bool Activo { get; set; }
        public string NombreEstado { get; set; }

    }
}