using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class AuditoriaEntity
    {
        public int ID_AuditoriaAdministracion { get; set; }
        public int ID_AuditoriaAsistencia { get; set; }
        public int ID_Asistencia { get; set; }
        public int ID_AuditoriaAvisoGeneral { get; set; }
        public int ID_AvisoGeneral { get; set; }
        public int ID_AuditoriaCalificacion { get; set; }
        public int ID_Calificacion { get; set; }
        public int ID_AuditoriaClase { get; set; }
        public int ID_Clase { get; set; }
        public int ID_AuditoriaDocente { get; set; }
        public int ID_Docente { get; set; }
        public int ID_AuditoriaEstudiante { get; set; }
        public int ID_Estudiante { get; set; }
        public int ID_InicioSesion { get; set; }
        public string NombreDocente { get; set; }
        public string NombreEstudiante { get; set; }
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public bool Exito { get; set; }
        public string Detalles { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Fecha_Accion { get; set; }
        public int RolUsuario { get; set; }

        public List<AuditoriaEntity> auditoriaListGenerica { get; set; }


    }
}