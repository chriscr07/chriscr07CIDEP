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
    public class EvaluacionesModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<EvaluacionEntity> Evaluaciones { get; set; }
        public EvaluacionEntity evaluacion { get; set; }

        public List<EvaluacionEntity> ListarEvaluaciones()
        {
            Evaluaciones = new List<EvaluacionEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEvaluaciones";
                var resp = client.GetAsync(url).Result;
                Evaluaciones = resp.Content.ReadFromJsonAsync<List<EvaluacionEntity>>().Result;
                return Evaluaciones;
            }
        }

        public EvaluacionEntity ListarEvaluacion(int ID_TipoEValuacion)
        {
            evaluacion = new EvaluacionEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEvaluacionPorId?ID_TipoEvaluacion={ID_TipoEValuacion}";
                var resp = client.GetAsync(url).Result;
                evaluacion = resp.Content.ReadFromJsonAsync<EvaluacionEntity>().Result;
                return evaluacion;
            }
        } //lista un evaluacion por id de evaluacion

        public string RegistrarEvaluacion(EvaluacionEntity evaluacion)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}RegistroTipoEvaluacion";
                JsonContent contenido = JsonContent.Create(evaluacion);
                var resp = client.PostAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Evaluación registrada exitosamente.";
                }
                else
                {
                    return $"Error al registrar evaluación.";
                }
            }
        } //registrar un nuevo tipo de evaluación

        public string EditarEvaluacion(EvaluacionEntity evaluacionEditada)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarTipoEvaluacion";
                JsonContent contenido = JsonContent.Create(evaluacionEditada);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Evaluación editada exitosamente.";
                }
                else
                {
                    return $"Error al editar evaluación.";
                }
            }
        } //edita un tipo de evaluación

        public string DesactivarEvaluacion(EvaluacionEntity evaluacionDesactivada)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}DesactivarTipoEvaluacion";
                JsonContent contenido = JsonContent.Create(evaluacionDesactivada);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Evaluación desactivada exitosamente.";
                }
                else
                {
                    return $"Error al desactivar evaluación.";
                }
            } //desactiva un tipo de evaluación (soft delete)
        }
    }
}