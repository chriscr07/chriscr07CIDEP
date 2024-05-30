using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class PerfilEntity
    {
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public int ID_Rol { get; set; }
        public string NombreRol { get; set; }
        public bool ActivoUsuario { get; set; }
        public string Email { get; set; }
        public int ID_Estudiante { get; set; }
        public int ID_Docente { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Activo { get; set; }
        public string Cedula { get; set; }
    }
}