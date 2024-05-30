using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entity
{
    public class EstadoAsistenciaEntity
    {
        public int ID_Estado {  get; set; }
        public string NombreEstado { get; set; }
        public bool Activo {  get; set; }
        public int ID_Usuario { get; set; }
        public int RolUsuario { get; set; }

    }
}