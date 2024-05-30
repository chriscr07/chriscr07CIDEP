using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class UsuarioEntity
    {
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contrasenna { get; set; }
        public int ID_Rol { get; set; }
        public int ID_RolUsuarioNuevo { get; set; }
        public bool Activo { get; set; }
        public List<UsuarioEntity> usuarioListaGenerica { get; set; }
        public string NombreRol { get; set; }
        public string Email { get; set; }
        public int RolUsuario { get; set; }
        public int ID_UsuarioEditaUsuario { get; set; }

        public int ID_Usuario_Accion { get; set; }


        //Aquí se devuelve la informacion del docente/estudiante
        public String Nombre { get; set; }
        public String Cedula { get; set; }
        public String PrimerApellido { get; set; }
        public String SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? IDstudentteacher { get; set; }

        //Actualiza contraseña
        public string ContrasennaActual { get; set; }
        public string NuevaContrasenna { get; set; }

    }
}