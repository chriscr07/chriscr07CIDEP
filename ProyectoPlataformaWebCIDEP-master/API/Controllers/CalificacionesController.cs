using API.Entity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class CalificacionesController : ApiController
    {
        [HttpPost]
        [Route("RegistroCalificacion")]
        public IHttpActionResult RegistroCalificacion(CalificacionEntity calificacion)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    context.CrearCalificacion(calificacion.ID_Estudiante, calificacion.ID_Clase,
                        calificacion.Calificacion, calificacion.ID_TipoEvaluacion, calificacion.ID_Usuario, calificacion.PorcentajeTotal, 
                        calificacion.Retroalimentacion);
                    return Ok("Calificacion registrada");
                }
            }
            catch (Exception)
            {
                return BadRequest("Error al registrar");
            }
        } //registra una calificación nueva

        [HttpGet]
        [Route("VerCalificacionPorId")]
        public IHttpActionResult VerCalificacionesPorId(int id) //ver calificaciones por ID estudiante
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var calificaciones = context.VerCalificacionesPorID(id).
                        Select(c => new CalificacionEntity
                        {
                            Estudiante = c.Estudiante,
                            NombreGrado = c.NombreGrado,
                            Calificacion = c.Calificacion,
                            FechaCalificacion = c.FechaCalificacion,
                            NombreCurso = c.NombreCurso,
                            TipoEvaluacion = c.TipoEvaluacion,
                            Retroalimentacion = c.Retroalimentacion,
                            PorcentajeTotal = c.PorcentajeTotal
                        }).ToList();
                    return Ok(calificaciones);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("VerCalificacionPorIdCalificacion")]
        public IHttpActionResult VerCalificacionPorIdCalificacion(int id) //ver calificaciones por ID calificacion
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var calificacion = context.Calificaciones
                        .Where(c => c.ID_Calificacion == id)
                        .Select(c => new
                        {
                            c.ID_Calificacion,
                            c.ID_Estudiante,
                            c.ID_Clase,
                            c.Calificacion,
                            c.ID_TipoEvaluacion,
                            c.PorcentajeTotal,
                            c.Retroalimentacion
                        })
                        .FirstOrDefault();

                    if (calificacion != null)
                    {
                        return Ok(calificacion);
                    }
                    else
                    {
                        return NotFound(); 
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("VerCalificaciones")]
        public IHttpActionResult VerCalificaciones()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var calificaciones = context.VerCalificaciones().ToList();
                    return Ok(calificaciones);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todas las calificaciones NO eliminadas obtenidas de una vista


        [HttpPut]
        [Route("EditarCalificacion")]
        public IHttpActionResult EditarCalificacion(CalificacionEntity calificacion)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    context.EditarCalificacion(
                        calificacion.ID_Calificacion,
                        calificacion.ID_Estudiante,
                        calificacion.ID_Clase,
                        calificacion.Calificacion,
                        calificacion.ID_TipoEvaluacion,
                        calificacion.ID_Usuario,
                        calificacion.PorcentajeTotal,
                        calificacion.Retroalimentacion
                        );
                }
                return Ok("Calificacion actualizada");
            }
            catch (Exception e)
            {
                return BadRequest("Error al actualizar" + e);
            }
        } //modifica una calificación ya registrada

        [HttpDelete]
        [Route("EliminarCalificacion")]
        public IHttpActionResult EliminarCalificacion(CalificacionEntity calificacion)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    context.BorrarCalificacion(
                        calificacion.ID_Calificacion,
                        calificacion.ID_Usuario
                        );
                }
                return Ok("Calificacion eliminada");
            }
            catch (Exception)
            {
                return BadRequest("Error al eliminar calificacion");
            }

        } //soft delete de la calificación del estudiante

        [HttpGet]
        [Route("ObtenerEstudiantesConCalificaciones")]
        public IHttpActionResult ObtenerEstudiantesConCalificaciones()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiantesCalificaciones = context.ObtenerEstudiantesConCalificaciones().ToList();
                    return Ok(estudiantesCalificaciones);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todos los estudiantes que aparecen en la tabla de calificaciones

    }
}
