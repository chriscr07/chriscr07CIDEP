using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class DocenteEntity
    {
        public int ID_Docente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? ID_Usuario { get; set; }
        public int RolUsuario { get; set; }
        public int ID_UsuarioQueInserta { get; set; }
        public int ID_UsuarioQueElimina { get; set; }
        public bool Activo { get; set; }
        public int ID_Usuario_Accion { get; set; }
        public string Nombre_Usuario { get; set; }

    }
}