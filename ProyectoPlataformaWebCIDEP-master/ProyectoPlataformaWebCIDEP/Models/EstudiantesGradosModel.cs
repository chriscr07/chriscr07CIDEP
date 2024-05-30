using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using ProyectoPlataformaWebCIDEP.Entity;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ProyectoPlataformaWebCIDEP.Models
{
    public class EstudiantesGradosModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<EstudianteGradoEntity> EstudiantesGrados { get; set; }

        public string RegistrarEstudianteGrado(EstudianteGradoEntity estudianteGrado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}InsertarEstudianteGrado";
                JsonContent contenido = JsonContent.Create(estudianteGrado);
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
        } //registra una nueva relación de estudiante y grado

        public List<EstudianteGradoEntity> ListarEstudiantesPorGrado(int ID_Grado)
        {
            EstudiantesGrados = new List<EstudianteGradoEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEstudiantesGrados";
                var resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                {
                    EstudiantesGrados = resp.Content.ReadFromJsonAsync<List<EstudianteGradoEntity>>().Result;
                    EstudiantesGrados = EstudiantesGrados.Where(estudiante => estudiante.ID_Grado == ID_Grado).ToList();

                }

                return EstudiantesGrados;
            }
        }

        public List<EstudianteGradoEntity> ListarEstudiantesGrados()
        {
            EstudiantesGrados = new List<EstudianteGradoEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEstudiantesGrados";
                var resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                {
                    EstudiantesGrados = resp.Content.ReadFromJsonAsync<List<EstudianteGradoEntity>>().Result.ToList();
                   // EstudiantesGrados = EstudiantesGrados.Where(estudiante => estudiante.ID_Grado == ID_Grado).ToList();
                }
                return EstudiantesGrados;
            }
        }

        public async Task<string> EliminarEstudianteGrado(int ID_EstudianteGrado)
        {
            string respuesta = "";

            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{urlApi}EliminarEstudianteGrado?ID_EstudianteGrado={ID_EstudianteGrado}";
                    var resp = await client.DeleteAsync(url);

                    if (resp.IsSuccessStatusCode)
                    {
                        respuesta = "Registro eliminado exitosamente";
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