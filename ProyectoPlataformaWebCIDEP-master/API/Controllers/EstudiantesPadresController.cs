using API.Entity;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    public class EstudiantesPadresController : ApiController
    {
        [HttpGet]
        [Route("VerEstudiantesPadres")]
        public IHttpActionResult VerDocentesClases()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiantesPadres = context.VerEstudiantesPadres().ToList();
                    return Ok(estudiantesPadres);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        } //lista todas los padres con estudiantes asignados

        [HttpPost]
        [Route("InsertarEstudiantePadre")]
        public IHttpActionResult InsertarEstudiantePadre(EstudiantePadreEntity estudiantePadre)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiantePadreExistente = context.EstudiantesPadres.FirstOrDefault(eg => eg.ID_Estudiante == estudiantePadre.ID_Estudiante &&
                    eg.ID_Padre == estudiantePadre.ID_Padre);

                    if (estudiantePadreExistente != null)
                    {
                        return Content(HttpStatusCode.BadRequest, "Relación ya registrada.");
                    }

                    else
                    {
                        var estudiante = context.Estudiantes.FirstOrDefault(e => e.ID_Estudiante == estudiantePadre.ID_Estudiante);
                        if (estudiante == null)
                        {
                            return Content(HttpStatusCode.NotFound, "El estudiante no está registrado.");
                        }

                        var padre = context.Padres.FirstOrDefault(g => g.ID_Padre == estudiantePadre.ID_Padre);
                        if (padre == null)
                        {
                            return Content(HttpStatusCode.NotFound, "El padre no está registrado.");
                        }

                        var nuevoEstudiantePadre = new EstudiantesPadres
                        {
                            ID_Estudiante = estudiantePadre.ID_Estudiante,
                            ID_Padre = estudiantePadre.ID_Padre
                        };

                        context.EstudiantesPadres.Add(nuevoEstudiantePadre);
                        context.SaveChanges();

                        return Ok("El registro se ha insertado correctamente.");
                    }
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpDelete]
        [Route("EliminarEstudiantePadre")]
        public IHttpActionResult EliminarEstudiantePadre(int ID_EstudiantePadre)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiantePadre = context.EstudiantesPadres.FirstOrDefault(dp => dp.ID_EstudiantePadre == ID_EstudiantePadre);
                    if (estudiantePadre != null)
                    {
                        context.EstudiantesPadres.Remove(estudiantePadre);
                        context.SaveChanges();
                        return Ok("Registro eliminado correctamente.");
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, "La opción buscada no está registrada.");
                    }
                }
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Error al eliminar el registro");
            }
        }

    }
}
