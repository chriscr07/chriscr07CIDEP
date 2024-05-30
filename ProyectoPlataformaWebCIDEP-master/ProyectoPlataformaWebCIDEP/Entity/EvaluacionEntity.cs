using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Entity
{
    public class EvaluacionEntity
    {
        public int ID_TipoEvaluacion { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int RolUsuario { get; set; }
    }
}