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
    public class EstudiantesModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<EstudianteEntity> Estudiantes { get; set; }
        public EstudianteEntity estudiante { get; set; }

        public UsuariosModel usuariosModel = new UsuariosModel();

        public List<EstudianteEntity> ListarEstudiantes()
        {
            Estudiantes = new List<EstudianteEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEstudiantes";
                var resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Estudiantes = resp.Content.ReadFromJsonAsync<List<EstudianteEntity>>().Result;
                    Estudiantes = Estudiantes.Where(estudiante => estudiante.Activo == true).ToList();
                }
            }
            return Estudiantes;
        }

        public List<EstudianteEntity> ListarEstudiantesUsuarios()
        {
            Estudiantes = new List<EstudianteEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEstudiantes";
                var resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Estudiantes = resp.Content.ReadFromJsonAsync<List<EstudianteEntity>>().Result;
                    Estudiantes = Estudiantes.Where(estudiante => estudiante.Activo == true && estudiante.ID_Usuario.HasValue).ToList();

                    // Realizar una segunda consulta al API para obtener el nombre de usuario
                    foreach (var estudiante in Estudiantes)
                    {
                        if (estudiante.ID_Usuario != null)
                        {               
                            if (estudiante.ID_Usuario.HasValue)
                            {
                                var usuario = usuariosModel.ListarUsuario(estudiante.ID_Usuario.Value);
                                estudiante.Nombre_Usuario = usuario.Nombre_Usuario;
                            }                            
                        }
                    }
                }
            }
            return Estudiantes;
        }



        public List<EstudianteEntity> ListarEstudiantesConInactivos()
        {
            Estudiantes = new List<EstudianteEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEstudiantes";
                var resp = client.GetAsync(url).Result;
                Estudiantes = resp.Content.ReadFromJsonAsync<List<EstudianteEntity>>().Result;
                return Estudiantes;
            }
        }

        public List<EstudianteEntity> ListarEstudiantesGrados()
        {
            Estudiantes = new List<EstudianteEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEstudiantesGrados";
                var resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Estudiantes = resp.Content.ReadFromJsonAsync<List<EstudianteEntity>>().Result;
                    //Estudiantes = Estudiantes.Where(estudiante => estudiante.Activo == true).ToList();
                }
       
                return Estudiantes;
            }
        }

        public EstudianteEntity ListarEstudiante(int ID_Estudiante)
        {
            estudiante = new EstudianteEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerEstudiantePorId?ID_Estudiante={ID_Estudiante}";
                var resp = client.GetAsync(url).Result;
                estudiante = resp.Content.ReadFromJsonAsync<EstudianteEntity>().Result;
                return estudiante;
            }
        }
        public string RegistrarEstudiante(EstudianteEntity estudianteNuevo)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}RegistroEstudiante";
                JsonContent contenido = JsonContent.Create(estudianteNuevo);
                var resp = client.PostAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Estudiante registrado exitosamente.";
                }
                else
                {
                    return $"Error al registrar estudiante.";
                }
            }
        }
        public string EditarEstudiante(EstudianteEntity estudianteEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarEstudiante";
                JsonContent contenido = JsonContent.Create(estudianteEditado);
                var resp = client.PutAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Estudiante editado exitosamente.";
                }
                else
                {
                    return $"Error al editar estudiante.";
                }
            }
        }

        public string DesactivarEstudiante(EstudianteEntity estudianteEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}DesactivarEstudiante";
                JsonContent contenido = JsonContent.Create(estudianteEditado);
                var resp = client.PutAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Estudiante desactivado exitosamente.";
                }
                else
                {
                    return $"Error al desactivar estudiante.";
                }
            }
        }

        public string DesenlazarUsuarioEstudiante(EstudianteEntity estudianteEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}DesenlazarUsuarioEstudiante";
                JsonContent contenido = JsonContent.Create(estudianteEditado);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Usuario de estudiante desenlazado exitosamente.";
                }
                else
                {
                    return $"Error al desenlazar el usuario del estudiante.";
                }
            }
        }

    }
}