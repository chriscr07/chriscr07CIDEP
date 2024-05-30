using Newtonsoft.Json.Linq;
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
    public class AutenticacionModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public UsuarioEntity UsuarioBD { get; set; }
        public UsuarioEntity IniciarSesion(UsuarioEntity usuario)
        {
            UsuarioBD = new UsuarioEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}InicioSesion";
                JsonContent contenido = JsonContent.Create(usuario);
                var resp = client.PostAsync(url, contenido).Result;
                var UsuarioBD = resp.Content.ReadFromJsonAsync<UsuarioEntity>().Result;
                return UsuarioBD;
            }
        }
        public UsuarioEntity BuscarInformacionUsuario(int id_usuario)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}BuscarInformacionUsuario?id_usuario={id_usuario}";
                var resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    var UsuarioBD = resp.Content.ReadFromJsonAsync<UsuarioEntity>().Result;
                    return UsuarioBD;
                }
                else
                {
                    return null;
                }
            }
        }

        /*public string CambiarContrasenna(UsuarioEntity usuario)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}CambiarContrasenna";
                JsonContent contenido = JsonContent.Create(usuario);
                var resp = client.PutAsync(url, contenido).Result;
                var respuesta = resp.Content.ReadAsStringAsync().Result;
                return respuesta;
            }
        }*/

        public string CambiarContrasenna(UsuarioEntity usuario)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}CambiarContrasenna";
                JsonContent contenido = JsonContent.Create(usuario);
                var resp = client.PutAsync(url, contenido).Result;
                //var respuesta = resp.Content.ReadAsStringAsync().Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Contraseña actualizada exitosamente.";
                }
                else
                {
                    dynamic errorResponse = JObject.Parse(resp.Content.ReadAsStringAsync().Result);
                    return errorResponse.Message;
                }
            }
        }



    }
}