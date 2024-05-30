using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class DocenteClaseEntity
    {
        public int ID_DocenteClase { get; set; }
        public int ID_Docente { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreGrado { get; set; }
        public int ID_Grado { get; set; }
        public int ID_Clase { get; set; }
        public string NombreCurso { get; set; }
    }
}