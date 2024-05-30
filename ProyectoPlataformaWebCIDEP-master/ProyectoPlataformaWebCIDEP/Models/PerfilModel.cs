
using ProyectoPlataformaWebCIDEP.Entity;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace ProyectoPlataformaWebCIDEP.Models
{
    public class PerfilModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public PerfilEntity perfil { get; set; }

        public PerfilEntity ListarPerfilDocente(int ID_Usuario)
        {
            perfil = new PerfilEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerPerfilDeDocente?ID_Usuario={ID_Usuario}";
                var resp = client.GetAsync(url).Result;
                perfil = resp.Content.ReadFromJsonAsync<PerfilEntity>().Result;
                return perfil;
            }
        }
        public PerfilEntity ListarPerfilEstudiante(int ID_Usuario)
        {
            perfil = new PerfilEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerPerfilDeEstudiante?ID_Usuario={ID_Usuario}";
                var resp = client.GetAsync(url).Result;
                perfil = resp.Content.ReadFromJsonAsync<PerfilEntity>().Result;
                return perfil;
            }
        }
        public PerfilEntity ListarPerfilAdministrador(int ID_Usuario)
        {
            perfil = new PerfilEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerPerfilDeAdministrador?ID_Usuario={ID_Usuario}";
                var resp = client.GetAsync(url).Result;
                perfil = resp.Content.ReadFromJsonAsync<PerfilEntity>().Result;
                return perfil;
            }
        }
    }
}