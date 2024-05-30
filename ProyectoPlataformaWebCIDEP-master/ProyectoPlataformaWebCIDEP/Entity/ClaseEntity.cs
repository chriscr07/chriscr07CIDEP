using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class ClaseEntity
    {
        public int ID_Clase { get; set; }
        public int ID_Curso { get; set; }
        public int ID_Grado { get; set; }
        public int ID_Usuario { get; set; }
        public int RolUsuario { get; set; }
        public string NombreCurso { get; set; }
        public string NombreGrado { get; set; }
        public bool Activo { get; set; }
    }
}