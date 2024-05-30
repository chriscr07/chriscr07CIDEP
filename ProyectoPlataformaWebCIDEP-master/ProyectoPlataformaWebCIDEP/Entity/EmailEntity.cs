using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class EmailEntity
    {
        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public string Token { get; set; }
        public string NombreDestinatario { get; set; }
        public string NombreHijo { get; set; }
    }
}