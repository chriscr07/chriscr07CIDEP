//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    
    public partial class VerAuditoriaIniciosSesion_Result
    {
        public int ID_InicioSesion { get; set; }
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public bool Exito { get; set; }
        public string Detalles { get; set; }
        public System.DateTime Fecha { get; set; }
    }
}