using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entity
{
    public class TokenEntity
    {
        public int ID_Token { get; set; }
        public string Token { get;  set; }
        public int ID_Usuario { get;  set; }
        public DateTime FechaCreacion { get;  set; }
        public string Email { get; set; }

        public string NuevaContrasenna { get; set; }
    }
}