using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using ProyectoPlataformaWebCIDEP.Entity;
using System.Threading.Tasks;

namespace ProyectoPlataformaWebCIDEP.Models
{
    public class DocentesClasesModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<DocenteClaseEntity> DocentesClases { get; set; }

        public string RegistrarDocenteClase(DocenteClaseEntity docenteGrado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}InsertarDocenteClase";
                JsonContent contenido = JsonContent.Create(docenteGrado);
                var resp = client.PostAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Registrado exitosamente.";
                }
                else
                {
                    dynamic errorResponse = JObject.Parse(resp.Content.ReadAsStringAsync().Result);
                    return errorResponse.Message;
                }
            }
        } //registra una nueva relación de docente y clase

        public List<DocenteClaseEntity> ListarDocentesClases()
        {
            DocentesClases = new List<DocenteClaseEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerDocentesClases";
                var resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                {
                    DocentesClases = resp.Content.ReadFromJsonAsync<List<DocenteClaseEntity>>().Result;

                }

                return DocentesClases;
            }
        }

        public List<DocenteClaseEntity> ListarDocenteClases(int ID_Docente) //lista las clases asignadas a un docente
        {
            DocentesClases = new List<DocenteClaseEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerDocentesClases";
                var resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                {
                    DocentesClases = resp.Content.ReadFromJsonAsync<List<DocenteClaseEntity>>().Result;
                    DocentesClases = DocentesClases.Where(docente => docente.ID_Docente == ID_Docente).ToList();
                }           
                return DocentesClases;
            }
        }

        public async Task<string> EliminarDocenteClase(int ID_DocenteClase)
        {
            string respuesta = "";

            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{urlApi}EliminarDocenteClase?ID_DocenteClase={ID_DocenteClase}";
                    var resp = await client.DeleteAsync(url);

                    if (resp.IsSuccessStatusCode)
                    {
                        respuesta = await resp.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        respuesta = $"Error en la solicitud.";
                    }
                }
            }
            catch (Exception)
            {
                respuesta = $"Error al procesar la solicitud.";
            }

            return respuesta;
        }

    }
}