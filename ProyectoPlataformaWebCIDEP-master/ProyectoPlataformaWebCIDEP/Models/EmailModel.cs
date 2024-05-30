using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using ProyectoPlataformaWebCIDEP.Entity;
using System.Configuration;

namespace ProyectoPlataformaWebCIDEP.Models
{
    public class EmailModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public string EnviarEmailEstudianteAusente(EmailEntity email)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EnviarCorreoAusencia";
                JsonContent contenido = JsonContent.Create(email);
                var resp = client.PostAsync(url, contenido).Result;
                var result = resp.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
    }
}