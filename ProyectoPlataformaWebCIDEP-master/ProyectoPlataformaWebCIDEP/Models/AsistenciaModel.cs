using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Web;
using ProyectoPlataformaWebCIDEP.Entity;
using Newtonsoft.Json.Linq;

namespace ProyectoPlataformaWebCIDEP.Models
{
    public class AsistenciaModel
    {

        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<AsistenciaEntity> Asistencia { get; set; }

        public AsistenciaEntity asistencia { get; set; }

        public List<AsistenciaEntity> VerAsistencia()
        {
            Asistencia = new List<AsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAsistencia";
                var resp = client.GetAsync(url).Result;
                Asistencia = resp.Content.ReadFromJsonAsync<List<AsistenciaEntity>>().Result;
                return Asistencia;
            }
        }
        public List<AsistenciaEntity> VerAsistenciaPorPeriodo(DateTime FechaInicio, DateTime FechaFin)
        {
            Asistencia = new List<AsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAsistenciaPorPeriodo?FechaInicio={FechaInicio}&FechaFin={FechaFin}";
                var resp = client.GetAsync(url).Result;
                Asistencia = resp.Content.ReadFromJsonAsync<List<AsistenciaEntity>>().Result;
                return Asistencia;
            }
        }
        public List<AsistenciaEntity> VerAsistenciaPorIdEstudiante(int ID_Estudiante)
        {
            Asistencia = new List<AsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAsistenciaPorIdEstudiante?ID_Estudiante={ID_Estudiante}";
                var resp = client.GetAsync(url).Result;
                Asistencia = resp.Content.ReadFromJsonAsync<List<AsistenciaEntity>>().Result;
                return Asistencia;
            }
        }

        public List<AsistenciaEntity> VerAsistenciaPorIdGrado(int ID_Grado)
        {
            Asistencia = new List<AsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAsistenciaPorIdGrado?ID_Grado={ID_Grado}";
                var resp = client.GetAsync(url).Result;
                Asistencia = resp.Content.ReadFromJsonAsync<List<AsistenciaEntity>>().Result;
                return Asistencia;
            }
        }

        public List<AsistenciaEntity> ListarEstudiantesConRegistroAsistencia()
        {
            Asistencia = new List<AsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ListarEstudiantesConRegistroAsistencia";
                var resp = client.GetAsync(url).Result;
                Asistencia = resp.Content.ReadFromJsonAsync<List<AsistenciaEntity>>().Result;
                return Asistencia;
            }
        }

        public string BorrarAsistencia(AsistenciaEntity asistencia)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}BorrarAsistencia";
                string jsonContent = JsonConvert.SerializeObject(asistencia);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Delete, url)
                {
                    Content = content
                };
                var resp = client.SendAsync(request).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadAsStringAsync().Result;
                }
                else if (resp.StatusCode == HttpStatusCode.BadRequest)
                {
                    return resp.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return $"Error al borrar asistencia.";
                }
            }
        }

        public AsistenciaEntity VerAsistenciaPorIdAsistencia(int ID_asistencia)
        {
            asistencia = new AsistenciaEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAsistenciaPorIdAsistencia?id={ID_asistencia}";
                var resp = client.GetAsync(url).Result;
                asistencia = resp.Content.ReadFromJsonAsync<AsistenciaEntity>().Result;
                return asistencia;
            }
        }

        public string EditarAsistencia(AsistenciaEntity asistencia)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarAsistencia";
                JsonContent contenido = JsonContent.Create(asistencia);
                var resp = client.PutAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Asistencia editada exitosamente.";
                }
                else
                {
                    dynamic errorResponse = JObject.Parse(resp.Content.ReadAsStringAsync().Result);
                    return errorResponse.Message;
                }
            }
        }

        public string CrearAsistencia(AsistenciaEntity asistencia)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}CrearAsistencia";
                JsonContent contenido = JsonContent.Create(asistencia);
                var resp = client.PostAsync(url, contenido).Result;
                //var result = resp.Content.ReadAsStringAsync().Result;
                //return result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Asistencia registrada exitosamente.";
                }
                else
                {
                    dynamic errorResponse = JObject.Parse(resp.Content.ReadAsStringAsync().Result);
                    return errorResponse.Message;
                }
            }
        }

        public List<AsistenciaEntity> ObtenerClasesConAsistencia()
        {
            Asistencia = new List<AsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ObtenerClasesConAsistencia";
                var resp = client.GetAsync(url).Result;
                Asistencia = resp.Content.ReadFromJsonAsync<List<AsistenciaEntity>>().Result;
                return Asistencia;
            }
        }

        public List<AsistenciaEntity> ObtenerGradosConAsistencia()
        {
            Asistencia = new List<AsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ObtenerGradosConAsistencia";
                var resp = client.GetAsync(url).Result;
                Asistencia = resp.Content.ReadFromJsonAsync<List<AsistenciaEntity>>().Result;
                return Asistencia;
            }
        }


    }
}