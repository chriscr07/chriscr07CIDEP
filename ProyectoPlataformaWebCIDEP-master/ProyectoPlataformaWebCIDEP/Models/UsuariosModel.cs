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
    public class UsuariosModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<UsuarioEntity> Usuarios { get; set; } //set?

        public UsuarioEntity usuario { get; set; }

        public string RegistrarUsuario(UsuarioEntity usuario)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}RegistroUsuario";
                JsonContent contenido = JsonContent.Create(usuario);
                var resp = client.PostAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Usuario registrado exitosamente.";
                }
                else
                {
                    return $"Error al registrar usuario.";
                }
            }
        }

        public List<UsuarioEntity> ListarUsuarios()
        {
            Usuarios = new List<UsuarioEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerUsuarios";
                var resp = client.GetAsync(url).Result;
                Usuarios = resp.Content.ReadFromJsonAsync<List<UsuarioEntity>>().Result;
                return Usuarios;
            }
        }
        public List<UsuarioEntity> ListarUsuariosDisponiblesDocentes(int RolUsuario)
        {
            Usuarios = new List<UsuarioEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerUsuariosDocentesDisponibles?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Usuarios = resp.Content.ReadFromJsonAsync<List<UsuarioEntity>>().Result;
                return Usuarios;
            }
        }
        public List<UsuarioEntity> ListarUsuariosDisponiblesEstudiantes(int RolUsuario)
        {
            Usuarios = new List<UsuarioEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerUsuariosEstudiantesDisponibles?RolUsuario={RolUsuario}";
                var resp = client.GetAsync(url).Result;
                Usuarios = resp.Content.ReadFromJsonAsync<List<UsuarioEntity>>().Result;
                return Usuarios;
            }
        }

        public UsuarioEntity ListarUsuario(int ID_Usuario)
        {
            usuario = new UsuarioEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerUsuarioPorId?ID_Usuario={ID_Usuario}";
                var resp = client.GetAsync(url).Result;
                usuario = resp.Content.ReadFromJsonAsync<UsuarioEntity>().Result;
                return usuario;
            }
        }

        public string EditarUsuario(UsuarioEntity usuarioEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarUsuario";
                JsonContent contenido = JsonContent.Create(usuarioEditado);
                var resp = client.PutAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Usuario editado exitosamente.";
                }
                else
                {
                    return $"Error al editar usuario.";
                }
            }
        }

        public string DesactivarUsuario(UsuarioEntity usuarioEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}DesactivarUsuario";
                JsonContent contenido = JsonContent.Create(usuarioEditado);
                var resp = client.PutAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Usuario desactivado exitosamente.";
                }
                else
                {
                    return $"Error al desactivar usuario.";
                }
            }
        }


    }
}