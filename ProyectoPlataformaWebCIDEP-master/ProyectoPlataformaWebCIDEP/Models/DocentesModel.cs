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
    public class DocentesModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<DocenteEntity> Docentes { get; set; }
        public DocenteEntity docente { get; set; }

        public UsuariosModel usuariosModel = new UsuariosModel();


        public List<DocenteEntity> ListarDocentes()
        {
            Docentes = new List<DocenteEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerDocentes";
                var resp = client.GetAsync(url).Result;
                Docentes = resp.Content.ReadFromJsonAsync<List<DocenteEntity>>().Result;
                return Docentes;
            }
        }

        public List<DocenteEntity> ListarDocentesUsuarios()
        {
            Docentes = new List<DocenteEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerDocentes";
                var resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Docentes = resp.Content.ReadFromJsonAsync<List<DocenteEntity>>().Result;
                    Docentes = Docentes.Where(docente => docente.Activo == true && docente.ID_Usuario.HasValue).ToList();

                    foreach (var docente in Docentes)
                    {
                        if (docente.ID_Usuario != null)
                        {
                            if (docente.ID_Usuario.HasValue)
                            {
                                var usuario = usuariosModel.ListarUsuario(docente.ID_Usuario.Value);
                                docente.Nombre_Usuario = usuario.Nombre_Usuario;
                            }
                        }
                    }
                }
            }
            return Docentes;
        }
        public DocenteEntity ListarDocente(int ID_Docente)
        {
            docente = new DocenteEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerDocentePorId?ID_Docente={ID_Docente}";
                var resp = client.GetAsync(url).Result;
                docente = resp.Content.ReadFromJsonAsync<DocenteEntity>().Result;
                return docente;
            }
        }
        public string RegistrarDocente(DocenteEntity docenteNuevo)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}RegistroDocente";
                JsonContent contenido = JsonContent.Create(docenteNuevo);
                var resp = client.PostAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Docente registrado exitosamente.";
                }
                else
                {
                    return $"Error al registrar docente.";
                }
            }
        }
        public string EditarDocente(DocenteEntity docenteEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarDocente";
                JsonContent contenido = JsonContent.Create(docenteEditado);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Docente editado exitosamente.";
                }
                else
                {
                    return $"Error al editar docente.";
                }
            }
        }

        public string DesactivarDocente(DocenteEntity docenteEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}DesactivarDocente";
                JsonContent contenido = JsonContent.Create(docenteEditado);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Docente desactivado exitosamente.";
                }
                else
                {
                    return $"Error al desactivar docente.";
                }
            }
        }

        public string DesenlazarUsuarioDocente(DocenteEntity docenteEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}DesenlazarUsuarioDocente";
                JsonContent contenido = JsonContent.Create(docenteEditado);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Usuario de docente desenlazado exitosamente.";
                }
                else
                {
                    return $"Error al desenlazar el usuario del docente.";
                }
            }
        }
    }
}