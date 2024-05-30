using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class EstudiantePadreEntity
    {
        public int ID_EstudiantePadre { get; set; }
        public int ID_Estudiante {  get; set; }
        public int ID_Padre { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreP {  get; set; }
        public string PrimerApellidoP { get; set; }
        public string SegundoApellidoP { get; set;}
        public string Numero {  get; set; }
        public string Email { get; set; }


    }
}