using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using ProyectoPlataformaWebCIDEP.Entity;

namespace ProyectoPlataformaWebCIDEP.Models
{
    public class EstadosAsistenciaModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<EstadoAsistenciaEntity> EstadosAsistencia { get; set; }
        public EstadoAsistenciaEntity estadoAsistencia { get; set; }

        public List<EstadoAsistenciaEntity> ListarEstadosAsistencia()
        {
            EstadosAsistencia = new List<EstadoAsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEstadosAsistencia";
                var resp = client.GetAsync(url).Result;
                EstadosAsistencia = resp.Content.ReadFromJsonAsync<List<EstadoAsistenciaEntity>>().Result;
                return EstadosAsistencia;
            }
        } //lista todos los estados de asistencia
        public EstadoAsistenciaEntity ListarEstadoAsistencia(int ID_Estado)
        {
            estadoAsistencia = new EstadoAsistenciaEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEstadoAsistenciaPorId?ID_Estado={ID_Estado}";
                var resp = client.GetAsync(url).Result;
                estadoAsistencia = resp.Content.ReadFromJsonAsync<EstadoAsistenciaEntity>().Result;
                return estadoAsistencia;
            }
        } //lista un estado de asistencia

        public string RegistrarEstadoAsistencia(EstadoAsistenciaEntity estadoAsistencia)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}RegistroEstadoAsistencia";
                JsonContent contenido = JsonContent.Create(estadoAsistencia);
                var resp = client.PostAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Estado de asistencia registrado exitosamente.";
                }
                else
                {
                    return $"Error al registrar estado de asistencia.";
                }
            }
        } //registra un nuevo estado de asistencia

        public string EditarEstadoAsistencia(EstadoAsistenciaEntity estadoAsistenciaEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarEstadoAsistencia";
                JsonContent contenido = JsonContent.Create(estadoAsistenciaEditado);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Estado de asistencia editado exitosamente.";
                }
                else
                {
                    return $"Error al editar estado de asistencia.";
                }
            }
        } //edita un estado de asistencia

        public string DesactivarEstadoAsistencia(EstadoAsistenciaEntity estadoAsistenciaDesactivado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}DesactivarEstadoAsistencia";
                JsonContent contenido = JsonContent.Create(estadoAsistenciaDesactivado);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Estado de asistencia desactivado exitosamente.";
                }
                else
                {
                    return $"Error al desactivar estado de asistencia.";
                }
            } //desactiva un estado de asistencia
        }
    }
}