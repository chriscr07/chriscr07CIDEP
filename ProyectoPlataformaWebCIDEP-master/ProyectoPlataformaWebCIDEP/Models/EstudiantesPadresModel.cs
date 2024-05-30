using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ProyectoPlataformaWebCIDEP.Entity;

namespace ProyectoPlataformaWebCIDEP.Models
{
    public class EstudiantesPadresModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<EstudiantePadreEntity> EstudiantesPadres { get; set; }

        public string RegistrarEstudiantePadre(EstudiantePadreEntity estudiantePadre)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}InsertarEstudiantePadre";
                JsonContent contenido = JsonContent.Create(estudiantePadre);
                var resp = client.PostAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Registrado exitosamente.";
                }
                else
                {
                    dynamic errorResponse = JObject.Parse(resp.Content.ReadAsStringAsync().Result);
                    return errorResponse.Message;
                }
            }
        } //registra una nueva relación de estudiante y padre

        public List<EstudiantePadreEntity> ListarEstudiantesPadres()
        {
            EstudiantesPadres = new List<EstudiantePadreEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEstudiantesPadres";
                var resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                {
                    EstudiantesPadres = resp.Content.ReadFromJsonAsync<List<EstudiantePadreEntity>>().Result;

                }

                return EstudiantesPadres;
            }
        }

        public async Task<string> EliminarEstudiantePadre(int ID_EstudiantePadre)
        {
            string respuesta = "";

            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{urlApi}EliminarEstudiantePadre?ID_EstudiantePadre={ID_EstudiantePadre}";
                    var resp = await client.DeleteAsync(url);

                    if (resp.IsSuccessStatusCode)
                    {
                        respuesta = "Registro eliminado exitosamente.";
                    }
                    else
                    {
                        respuesta = $"Error en la solicitud.";
                    }
                }
            }
            catch (Exception)
            {
                respuesta = $"Error al procesar la solicitud.";
            }

            return respuesta;
        }
    }
}