
using ProyectoPlataformaWebCIDEP.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace ProyectoPlataformaWebCIDEP.Models
{
    public class InformesModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<CalificacionEntity> Calificaciones { get; set; }
        public CalificacionEntity Calificacion { get; set; }

        public List<AsistenciaEntity> Asistencia { get; set; }
        public AsistenciaEntity asistencia { get; set; }


        public List<CalificacionEntity> ObtenerCalificacionesEstudiantePorFechas(int rolUsuario, int idEstudiante, DateTime fechaInicio, DateTime fechaFin)
        {
            Calificaciones = new List<CalificacionEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ObtenerCalificacionesEstudiantePorFechas?rolUsuario=" +
                    $"{rolUsuario}&idEstudiante={idEstudiante}&fechaInicio={fechaInicio}&fechaFin={fechaFin}";
                var resp = client.GetAsync(url).Result;
                Calificaciones = resp.Content.ReadFromJsonAsync<List<CalificacionEntity>>().Result;
                return Calificaciones;
            }
        }

        public List<AsistenciaEntity> ObtenerAsistenciaClasePorFechas(int rolUsuario, int idClase, DateTime fechaInicio, DateTime fechaFin)
        {
            Asistencia = new List<AsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ObtenerAsistenciaClasePorFechas?rolUsuario=" +
                    $"{rolUsuario}&idClase={idClase}&fechaInicio={fechaInicio}&fechaFin={fechaFin}";
                var resp = client.GetAsync(url).Result;
                Asistencia = resp.Content.ReadFromJsonAsync<List<AsistenciaEntity>>().Result;
                return Asistencia;
            }
        }

        public List<AsistenciaEntity> ObtenerAsistenciaEstudiantePorFechas(int rolUsuario, int idEstudiante, DateTime fechaInicio, DateTime fechaFin)
        {
            Asistencia = new List<AsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ObtenerAsistenciaEstudiantePorFechas?rolUsuario=" +
                    $"{rolUsuario}&idEstudiante={idEstudiante}&fechaInicio={fechaInicio}&fechaFin={fechaFin}";
                var resp = client.GetAsync(url).Result;
                Asistencia = resp.Content.ReadFromJsonAsync<List<AsistenciaEntity>>().Result;
                return Asistencia;
            }
        }

        public List<AsistenciaEntity> ObtenerAsistenciaGradoPorFechas(int rolUsuario, int idGrado, DateTime fechaInicio, DateTime fechaFin)
        {
            Asistencia = new List<AsistenciaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}ObtenerAsistenciaGradoPorFechas?rolUsuario=" +
                    $"{rolUsuario}&idGrado={idGrado}&fechaInicio={fechaInicio}&fechaFin={fechaFin}";
                var resp = client.GetAsync(url).Result;
                Asistencia = resp.Content.ReadFromJsonAsync<List<AsistenciaEntity>>().Result;
                return Asistencia;
            }
        }

    }
}