using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class PadreEntity
    {
        public int ID_Padre { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public string Numero { get; set; }

        public int ID_UsuarioQueInserta { get; set; }
        public int ID_Usuario_Accion { get; set; }
        public int RolUsuario { get; set; }
    }
}