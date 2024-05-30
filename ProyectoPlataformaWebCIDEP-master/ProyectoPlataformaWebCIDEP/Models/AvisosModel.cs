using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Web;
using ProyectoPlataformaWebCIDEP.Entity;

namespace ProyectoPlataformaWebCIDEP.Models
{
    public class AvisosModel
    {

        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<AvisoGeneralEntity> AvisoGeneral { get; set; }

        public AvisoGeneralEntity avisogeneral { get; set; }

        public List<AvisoGeneralEntity> ListarAvisosGenerales()
        {
            AvisoGeneral = new List<AvisoGeneralEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAvisosGenerales";
                var resp = client.GetAsync(url).Result;
                AvisoGeneral = resp.Content.ReadFromJsonAsync<List<AvisoGeneralEntity>>().Result;
                return AvisoGeneral;
            }
        }
        public AvisoGeneralEntity ListarAvisoGeneral(int ID_AvisoGeneral)
        {
            avisogeneral = new AvisoGeneralEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerAvisoGeneral?ID_AvisoGeneral={ID_AvisoGeneral}";
                var resp = client.GetAsync(url).Result;
                avisogeneral = resp.Content.ReadFromJsonAsync<AvisoGeneralEntity>().Result;
                return avisogeneral;
            }
        }

        public string BorrarAvisoGeneral(AvisoGeneralEntity avisogeneral)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}BorrarAvisoGeneral";
                string jsonContent = JsonConvert.SerializeObject(avisogeneral);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Delete, url)
                {
                    Content = content
                };
                var resp = client.SendAsync(request).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadAsStringAsync().Result;
                }
                else if (resp.StatusCode == HttpStatusCode.BadRequest)
                {
                    return resp.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return $"Error al borrar aviso general.";
                }
            }
        }


        public string EditarAvisoGeneral(AvisoGeneralEntity avisogeneral)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarAvisoGeneral";
                JsonContent contenido = JsonContent.Create(avisogeneral);
                var resp = client.PutAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return "Aviso editado exitosamente.";
                }               
                else
                {
                    return $"Error al editar aviso general.";
                }
            }
        }

        public string CrearAvisoGeneral(AvisoGeneralEntity avisogeneral)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}CrearAvisoGeneral";
                JsonContent contenido = JsonContent.Create(avisogeneral);
                var resp = client.PostAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Aviso creado exitosamente.";
                }
                else
                {
                    return $"Error al registrar aviso general.";
                }
            }
        }
    }
}