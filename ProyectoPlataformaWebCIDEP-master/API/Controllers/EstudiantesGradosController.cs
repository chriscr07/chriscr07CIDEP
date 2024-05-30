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
    public class EstudiantesGradosController : ApiController
    {
        [HttpPost]
        [Route("InsertarEstudianteGrado")]
        public IHttpActionResult InsertarEstudianteGrado(EstudianteGradoEntity estudianteGrado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudianteGradoExistente = context.EstudiantesGrados.FirstOrDefault(eg => eg.ID_Estudiante == estudianteGrado.ID_Estudiante);

                    if (estudianteGradoExistente != null)
                    {
                        var grado = context.Grados.FirstOrDefault(g => g.ID_Grado == estudianteGrado.ID_Grado);
                        if (grado == null)
                        {
                            return Content(HttpStatusCode.NotFound, "El grado no está registrado.");
                        }

                        estudianteGradoExistente.ID_Grado = estudianteGrado.ID_Grado;
                        context.SaveChanges();

                        return Ok("El grado del estudiante ha sido actualizado correctamente.");
                    }

                    else
                    {
                        var estudiante = context.Estudiantes.FirstOrDefault(e => e.ID_Estudiante == estudianteGrado.ID_Estudiante);
                        if (estudiante == null)
                        {
                            return Content(HttpStatusCode.NotFound, "El estudiante no está registrado.");
                        }
                
                        var grado = context.Grados.FirstOrDefault(g => g.ID_Grado == estudianteGrado.ID_Grado);
                        if (grado == null)
                        {
                            return Content(HttpStatusCode.NotFound, "El grado no está registrado.");
                        }

                        var nuevoEstudianteGrado = new EstudiantesGrados
                        {
                            ID_Estudiante = estudianteGrado.ID_Estudiante,
                            ID_Grado = estudianteGrado.ID_Grado
                        };

                        context.EstudiantesGrados.Add(nuevoEstudianteGrado);
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
        [Route("EliminarEstudianteGrado")]
        public IHttpActionResult EliminarEstudianteGrado(int ID_EstudianteGrado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudianteGrado = context.EstudiantesGrados.FirstOrDefault(dp => dp.ID_EstudianteGrado == ID_EstudianteGrado);
                    if (estudianteGrado != null)
                    {
                        context.EstudiantesGrados.Remove(estudianteGrado);
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

