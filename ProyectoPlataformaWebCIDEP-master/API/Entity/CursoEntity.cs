using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entity
{
    public class CursoEntity
    {
        public int ID_Curso { get; set; }
        public string NombreCurso { get; set; }
        public bool Activo { get; set; }
        public int RolUsuario { get; set; }
        public int ID_Usuario { get; set; }
    }
}