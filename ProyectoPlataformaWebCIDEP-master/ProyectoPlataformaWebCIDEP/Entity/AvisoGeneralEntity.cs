using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class AvisoGeneralEntity
    {
        public int ID_AvisoGeneral { get; set; }
        public string Mensaje { get; set; }
        public byte[] Archivo { get; set; }
        public DateTime Fecha_Publicacion { get; set; }
        public bool Activo { get; set; }

        public int RolUsuario { get; set; }
        public int ID_Usuario { get; set; }
    }
}