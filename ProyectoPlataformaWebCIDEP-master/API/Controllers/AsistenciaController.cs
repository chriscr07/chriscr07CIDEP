using API.Entity;
using API.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    public class AsistenciaController : ApiController
    {
        [HttpGet]
        [Route("ListarEstudiantesConRegistroAsistencia")]
        public IHttpActionResult ListarEstudiantesConRegistroAsistencia()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiantesAsistencia = context.ListarEstudiantesEnTablaAsistencia().ToList();
                    return Ok(estudiantesAsistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todos los estudiantes que aparecen en la tabla de asistencia

        [HttpGet]
        [Route("VerAsistencia")]
        public IHttpActionResult VerAsistencia()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var asistencia = context.VerAsistencia().ToList();
                    return Ok(asistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista la asistencia 

        [HttpGet]
        [Route("VerAsistenciaPorIdGrado")]
        public IHttpActionResult VerAsistenciaPorIdGrado(int ID_Grado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var asistencia = context.VerAsistenciaPorGrado(ID_Grado).ToList();
                    return Ok(asistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista la asistencia por grado 

        [HttpGet]
        [Route("VerAsistenciaPorPeriodo")]
        public IHttpActionResult VerAsistenciaPorPeriodo(DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var asistencia = context.VerAsistenciaPorPerioddo(FechaInicio, FechaFin).ToList();
                    return Ok(asistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista la asistencia entre dos fechas


        [HttpGet]
        [Route("VerAsistenciaPorIdEstudiante")]
        public IHttpActionResult VerAsistenciaPorIdEstudiante(int id_estudiante)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var asistencia = context.VerAsistenciaPorIdEstudiante(id_estudiante).ToList();
                    return Ok(asistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista la asistencia por estudiante seleccionado


        [HttpPost]
        [Route("CrearAsistencia")]
        public IHttpActionResult CrearAsistencia(AsistenciaEntity asistencia)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    context.CrearAsistencia(asistencia.ID_Estudiante, asistencia.ID_Estado, asistencia.ID_Clase, asistencia.Fecha_Asistencia,
                        asistencia.ID_Usuario);
                    return Ok("Asistencia registrada");
                }
            }
            catch (Exception)
            {
                //return BadRequest("Error al registrar");
                return InternalServerError();
            }
        } //registra asistencia

       

        [HttpGet]
        [Route("VerAsistenciaPorIdAsistencia")]
        public IHttpActionResult VerAsistenciaPorIdAsistencia(int id)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var asistencia = context.Asistencia
                        .Where(c => c.ID_Asistencia == id)
                        .Select(c => new
                        {
                            c.ID_Clase,
                            c.ID_Estudiante,
                            c.ID_Estado
                        })
                        .FirstOrDefault();

                    if (asistencia != null)
                    {
                        return Ok(asistencia);
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

 
        [HttpPut]
        [Route("EditarAsistencia")]
        public IHttpActionResult EditarAsistencia(AsistenciaEntity asistencia)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    context.EditarAsistencia(
                        asistencia.ID_Asistencia,
                        asistencia.ID_Estudiante,
                        asistencia.ID_Estado,
                        asistencia.ID_Usuario
                        );
                }
                return Ok("Asistencia actualizada.");
            }
            catch (Exception e)
            {
                return BadRequest("Error al actualizar" + e);
            }
        }

        [HttpDelete]
        [Route("BorrarAsistencia")]
        public IHttpActionResult BorrarAsistencia(AsistenciaEntity asistencia)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    context.BorrarAsistencia(
                        asistencia.ID_Asistencia,
                        asistencia.RolUsuario,
                        asistencia.ID_Usuario
                        );
                }
                return Ok("Asistencia eliminada.");
            }
            catch (Exception)
            {
                return BadRequest("Error al eliminar asistencia.");
            }

        }

        [HttpGet]
        [Route("VerAsistenciaClase")]
        public IHttpActionResult VerAsistenciaClase(int ID_Clase)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var asistenciaList = context.Asistencia
                        .Where(c => c.ID_Clase == ID_Clase)
                        .Select(c => new
                        {
                            c.ID_Clase,
                            c.ID_Estudiante,
                            c.Fecha_Asistencia,
                            c.ID_Estado
                        })
                        .ToList();

                    if (asistenciaList.Count > 0)
                    {
                        return Ok(asistenciaList);
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
        } //lista la asistencia por clase

        [HttpGet]
        [Route("VerAsistenciaPeriodo")] // Ejemplo de url https://localhost:44320/VerAsistenciaPeriodo?fechaInicio=2023-01-01&fechaFin=2024-06-06
        public IHttpActionResult VerAsistenciaPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                DateTime fechaAntigua, fechaReciente;
                if (fechaInicio < fechaFin)
                {
                    fechaAntigua = fechaInicio;
                    fechaReciente = fechaFin;
                }
                else
                {
                    fechaAntigua = fechaFin;
                    fechaReciente = fechaInicio;
                }
                using (var context = new CIDEPEntities())
                {
                    var asistencia = context.Asistencia
                        .Where(c => c.Fecha_Asistencia >= fechaAntigua && c.Fecha_Asistencia <= fechaReciente)
                        .Select(c => new
                        {
                            c.ID_Clase,
                            c.ID_Estudiante,
                            c.Fecha_Asistencia,
                            c.ID_Estado
                        })
                        .ToList();

                    if (asistencia.Count > 0)
                    {
                        return Ok(asistencia);
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
        } //lista la asistencia por fecha

        [HttpGet]
        [Route("ObtenerClasesConAsistencia")]
        public IHttpActionResult ObtenerClasesConAsistencia()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiantesAsistencia = context.ObtenerClasesConAsistencia().ToList();
                    return Ok(estudiantesAsistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todos las clases que aparecen en la tabla de asistencia

        [HttpGet]
        [Route("ObtenerGradosConAsistencia")]
        public IHttpActionResult ObtenerGradosConAsistencia()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiantesAsistencia = context.ObtenerGradosConAsistencia().ToList();
                    return Ok(estudiantesAsistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todos los grados que aparecen en la tabla de asistencia

    }
}