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
    using System.Collections.Generic;
    
    public partial class Tokens
    {
        public int ID_Token { get; set; }
        public int ID_Usuario { get; set; }
        public string Token { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
