using ProyectoPlataformaWebCIDEP.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace ProyectoPlataformaWebCIDEP.Models
{
    public class RolesModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<RolEntity> Roles { get; set; }

        public List<RolEntity> ListarRoles(int RolUsuario)
        {
            Roles = new List<RolEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerRoles?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Roles = resp.Content.ReadFromJsonAsync<List<RolEntity>>().Result;
                return Roles;
            }
        }
    }
}