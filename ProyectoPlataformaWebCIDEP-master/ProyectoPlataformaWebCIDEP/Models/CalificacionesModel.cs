using Newtonsoft.Json;
using ProyectoPlataformaWebCIDEP.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoPlataformaWebCIDEP.Models
{
    public class CalificacionesModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<CalificacionEntity> Calificaciones { get; set; } 

        public CalificacionEntity Calificacion { get; set; }

        public List<CalificacionEntity> ListarCalificaciones()
        {
            Calificaciones = new List<CalificacionEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerCalificaciones";
                var resp = client.GetAsync(url).Result;
                Calificaciones = resp.Content.ReadFromJsonAsync<List<CalificacionEntity>>().Result;
                return Calificaciones;
            }
        }

        public List<CalificacionEntity> ListarCalificacionesPorIdEstudiante(int id)
        {
            Calificaciones = new List<CalificacionEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerCalificacionPorId?id={id}";
                var resp = client.GetAsync(url).Result;
                Calificaciones = resp.Content.ReadFromJsonAsync<List<CalificacionEntity>>().Result;
                return Calificaciones;
            }
        }

        public string EliminarCalificacion(CalificacionEntity calificacion)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EliminarCalificacion";
                string jsonContent = JsonConvert.SerializeObject(calificacion);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Delete, url)
                {
                    Content = content
                };
                var resp = client.SendAsync(request).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Calificación eliminada exitosamente.";
                }
                else
                {
                    return $"Error al eliminar calificación.";
                }
            }
        }

        public CalificacionEntity VerCalificacionPorIdCalificacion(int ID_calificacion)
        {
            Calificacion = new CalificacionEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerCalificacionPorIdCalificacion?id={ID_calificacion}";
                var resp = client.GetAsync(url).Result;
                Calificacion = resp.Content.ReadFromJsonAsync<CalificacionEntity>().Result;
                return Calificacion;
            }
        }

        public string EditarCalificacion(CalificacionEntity calificacion)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarCalificacion";
                JsonContent contenido = JsonContent.Create(calificacion);
                var resp = client.PutAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Calificación editada exitosamente.";
                }
                else
                {
                    return $"Error al editar calificación.";
                }
            }
        }

        public string AgregarCalificacion(CalificacionEntity calificacion)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}RegistroCalificacion";
                JsonContent contenido = JsonContent.Create(calificacion);
                var resp = client.PostAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Calificación registrada exitosamente.";
                }
                else
                {
                    return $"Error al registrar calificación.";
                }
            }
        }

        public List<CalificacionEntity> ListarEstudiantesConRegistroCalificaciones()
        {
            Calificaciones = new List<CalificacionEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ObtenerEstudiantesConCalificaciones";
                var resp = client.GetAsync(url).Result;
                Calificaciones = resp.Content.ReadFromJsonAsync<List<CalificacionEntity>>().Result;
                return Calificaciones;
            }
        }




    }
}