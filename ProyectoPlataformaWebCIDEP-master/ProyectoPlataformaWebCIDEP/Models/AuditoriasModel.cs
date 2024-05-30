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
    public class AuditoriasModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<AuditoriaEntity> Auditorias { get; set; }

        public List<AuditoriaEntity> ListarAuditoriaAdministracion(int RolUsuario)
        {
            Auditorias = new List<AuditoriaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAuditoriaAdministracion?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Auditorias = resp.Content.ReadFromJsonAsync<List<AuditoriaEntity>>().Result;
                return Auditorias;
            }        
        }

        public List<AuditoriaEntity> ListarAuditoriaAsistencia(int RolUsuario)
        {
            Auditorias = new List<AuditoriaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAuditoriaAsistencia?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Auditorias = resp.Content.ReadFromJsonAsync<List<AuditoriaEntity>>().Result;
                return Auditorias;
            }
        }

        public List<AuditoriaEntity> ListarAuditoriaAvisos(int RolUsuario)
        {
            Auditorias = new List<AuditoriaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAuditoriaAvisos?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Auditorias = resp.Content.ReadFromJsonAsync<List<AuditoriaEntity>>().Result;
                return Auditorias;
            }
        }

        public List<AuditoriaEntity> ListarAuditoriaCalificaciones(int RolUsuario)
        {
            Auditorias = new List<AuditoriaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAuditoriaCalificaciones?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Auditorias = resp.Content.ReadFromJsonAsync<List<AuditoriaEntity>>().Result;
                return Auditorias;
            }
        }

        public List<AuditoriaEntity> ListarAuditoriaClases(int RolUsuario)
        {
            Auditorias = new List<AuditoriaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAuditoriaClases?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Auditorias = resp.Content.ReadFromJsonAsync<List<AuditoriaEntity>>().Result;
                return Auditorias;
            }
        }

        public List<AuditoriaEntity> ListarAuditoriaDocentes(int RolUsuario)
        {
            Auditorias = new List<AuditoriaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAuditoriaDocentes?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Auditorias = resp.Content.ReadFromJsonAsync<List<AuditoriaEntity>>().Result;
                return Auditorias;
            }
        }

        public List<AuditoriaEntity> ListarAuditoriaEstudiantes(int RolUsuario)
        {
            Auditorias = new List<AuditoriaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAuditoriaEstudiantes?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Auditorias = resp.Content.ReadFromJsonAsync<List<AuditoriaEntity>>().Result;
                return Auditorias;
            }
        }

        public List<AuditoriaEntity> ListarAuditoriaLogins(int RolUsuario)
        {
            Auditorias = new List<AuditoriaEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAuditoriaLogins?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Auditorias = resp.Content.ReadFromJsonAsync<List<AuditoriaEntity>>().Result;
                return Auditorias;
            }
        }
    }
}