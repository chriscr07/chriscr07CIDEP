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
    public class CursosModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<CursoEntity> Cursos { get; set; }
        public CursoEntity curso { get; set; }

        public List<CursoEntity> ListarCursos()
        {
            Cursos = new List<CursoEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerCursos";
                var resp = client.GetAsync(url).Result;
                Cursos = resp.Content.ReadFromJsonAsync<List<CursoEntity>>().Result;
                return Cursos;
            }
        } //lista todos los cursos 
        public CursoEntity ListarCurso(int ID_Curso)
        {
            curso = new CursoEntity();
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}VerCursoPorId?ID_Curso={ID_Curso}";
                var resp = client.GetAsync(url).Result;
                curso = resp.Content.ReadFromJsonAsync<CursoEntity>().Result;
                return curso;
            }
        } //lista un curso por id de curso

        public string RegistrarCurso(CursoEntity curso)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}RegistroCurso";
                JsonContent contenido = JsonContent.Create(curso);
                var resp = client.PostAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Curso registrado exitosamente.";
                }
                else
                {
                    return $"Error al registrar curso.";
                }
            }
        } //registra un curso nuevo 

        public string EditarCurso(CursoEntity cursoEditado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}EditarCurso";
                JsonContent contenido = JsonContent.Create(cursoEditado);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Curso editado exitosamente.";
                }
                else
                {
                    return $"Error al editar curso.";
                }
            }
        } //edita un curso

        public string DesactivarCurso(CursoEntity cursoDesactivado)
        {
            using (var client = new HttpClient())
            {
                string url = $"{urlApi}DesactivarCurso";
                JsonContent contenido = JsonContent.Create(cursoDesactivado);
                var resp = client.PutAsync(url, contenido).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return "Curso eliminado exitosamente.";
                }
                else
                {
                    return $"Error al eliminar curso.";
                }
            } //desactiva un curso (soft delete)
        }

    }
}