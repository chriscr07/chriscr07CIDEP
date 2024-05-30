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
    public class GradosModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<GradoEntity> Grados { get; set; }
        public GradoEntity grado { get; set; }

        public List<GradoEntity> ListarGrados()
        {
            Grados = new List<GradoEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerGrados";
                var resp = client.GetAsync(url).Result;
                Grados = resp.Content.ReadFromJsonAsync<List<GradoEntity>>().Result;
                return Grados;
            }
        } //lista todos los grados

        public GradoEntity ListarGrado(int ID_Grado)
        {
            grado = new GradoEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerGradoPorId?ID_Grado={ID_Grado}";
                var resp = client.GetAsync(url).Result;
                grado = resp.Content.ReadFromJsonAsync<GradoEntity>().Result;
                return grado;
            }
        } //lista un grado por id de grado

        public string RegistrarGrado(GradoEntity grado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}RegistroGrado";
                JsonContent contenido = JsonContent.Create(grado);
                var resp = client.PostAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Grado registrado exitosamente.";
                }
                else
                {
                    return $"Error al registrar grado.";
                }
            }
        } //registra un nuevo grado

        public string EditarGrado(GradoEntity gradoEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarGrado";
                JsonContent contenido = JsonContent.Create(gradoEditado);
                var resp = client.PutAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Grado editado exitosamente.";
                }
                else
                {
                    return $"Error al editar grado.";
                }
            }
        } //edita un grado

        public string DesactivarGrado(GradoEntity gradoDesactivado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}DesactivarGrado";
                JsonContent contenido = JsonContent.Create(gradoDesactivado);
                var resp = client.PutAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Grado desactivado exitosamente.";
                }
                else
                {
                    return $"Error al desactivar grado.";
                }
            } //desactiva un grado (soft delete)
        }

    }
}