using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entity
{
    public class GradoEntity
    {
        public int ID_Grado { get; set; }
        public string NombreGrado { get; set; }
        public bool Activo { get; set; }
        public int RolUsuario { get; set; }


    }
}