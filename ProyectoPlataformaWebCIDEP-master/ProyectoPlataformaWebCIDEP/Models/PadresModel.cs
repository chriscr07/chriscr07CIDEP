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
    public class PadresModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<PadreEntity> Padres { get; set; }
        public PadreEntity padre { get; set; }

        public List<PadreEntity> ListarPadres()
        {
            Padres = new List<PadreEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerPadres";
                var resp = client.GetAsync(url).Result;
                Padres = resp.Content.ReadFromJsonAsync<List<PadreEntity>>().Result;
                return Padres;
            }
        }

        public PadreEntity ListarPadre(int ID_Padre)
        {
            padre = new PadreEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerPadrePorId?ID_Padre={ID_Padre}";
                var resp = client.GetAsync(url).Result;
                padre = resp.Content.ReadFromJsonAsync<PadreEntity>().Result;
                return padre;
            }
        }
        public string RegistrarPadre(PadreEntity padreNuevo)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}RegistroPadre";
                JsonContent contenido = JsonContent.Create(padreNuevo);
                var resp = client.PostAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Padre registrado exitosamente.";
                }
                else
                {
                    return $"Error al registrar padre.";
                }
            }
        }
        public string EditarPadre(PadreEntity padreEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarPadre";
                JsonContent contenido = JsonContent.Create(padreEditado);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Padre editado exitosamente.";
                }
                else
                {
                    return $"Error al editar padre.";
                }
            }
        }

        public string EliminarPadre(PadreEntity padreEliminar)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EliminarPadre";
                JsonContent contenido = JsonContent.Create(padreEliminar);
                var resp = client.PostAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Padre eliminado exitosamente.";
                }
                else
                {
                    return $"Error al eliminar padre.";
                }
            }
        }


    }
}