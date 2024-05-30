using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entity
{
    public class EstudianteGradoEntity
    {
        public int ID_Estudiante { get; set; }
        public int ID_Grado { get; set; }
        public string NombreGrado { get; set; }
        public string Nombre { get; set;}
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
    }
}