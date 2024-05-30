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
    public class ClasesModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<ClaseEntity> Clases { get; set; }
        public ClaseEntity clase { get; set; }

        public List<ClaseEntity> ListarClases()
        {
            Clases = new List<ClaseEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerClases";
                var resp = client.GetAsync(url).Result;
                Clases = resp.Content.ReadFromJsonAsync<List<ClaseEntity>>().Result;
                return Clases;
            }
        } //lista todas las clases 
        public ClaseEntity ListarClase(int ID_Clase)
        {
            clase = new ClaseEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerClasePorId?ID_Clase={ID_Clase}";
                var resp = client.GetAsync(url).Result;
                clase = resp.Content.ReadFromJsonAsync<ClaseEntity>().Result;
                return clase;
            }
        } //lista un curso por id de curso

        public string RegistrarClase(ClaseEntity clase)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}RegistroClase";
                JsonContent contenido = JsonContent.Create(clase);
                var resp = client.PostAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Clase registrada exitosamente.";
                }
                else
                {
                    return $"Error al registrar clase.";
                }
            }
        } //registra una clase nueva

        public string EditarClase(ClaseEntity claseEditada)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarClase";
                JsonContent contenido = JsonContent.Create(claseEditada);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Clase editada exitosamente.";
                }
                else
                {
                    return $"Error al editar clase.";
                }
            }
        } //edita una clase

        public string DesactivarClase(ClaseEntity claseDesactivada)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}DesactivarClase";
                JsonContent contenido = JsonContent.Create(claseDesactivada);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Clase eliminada exitosamente.";
                }
                else
                {
                    return $"Error al eliminar clase.";
                }
            } //desactiva una clase
        }

    }
}