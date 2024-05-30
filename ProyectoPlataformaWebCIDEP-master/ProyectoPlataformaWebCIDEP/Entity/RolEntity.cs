using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class RolEntity
    {
        public int ID_Rol { get; set; }
        public string NombreRol { get; set; }
        public List<RolEntity> rolListaGenerica { get; set; }

    }
}