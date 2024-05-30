
using API.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    public class InformesController : ApiController
    {

        //Informes de asistencia

        [HttpGet]
        [Route("ObtenerAsistenciaEstudiantePorFechas")]
        public IHttpActionResult ObtenerAsistenciaEstudiantePorFechas(int rolUsuario, int idEstudiante, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var asistencia = context.ObtenerAsistenciaEstudiantePorFechas(rolUsuario, idEstudiante, fechaInicio, fechaFin).ToList();
                    return Ok(asistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista la asistencia para estudiante entre dos fechas

        [HttpGet]
        [Route("ObtenerAsistenciaClasePorFechas")]
        public IHttpActionResult ObtenerAsistenciaClasePorFechas(int rolUsuario, int idClase, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var asistencia = context.ObtenerAsistenciaClasePorFechas(rolUsuario, idClase, fechaInicio, fechaFin).ToList();
                    return Ok(asistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista la asistencia para una clase entre dos fechas


        [HttpGet]
        [Route("ObtenerAsistenciaGradoPorFechas")]
        public IHttpActionResult ObtenerAsistenciaGradoPorFechas(int rolUsuario, int idGrado, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var asistencia = context.ObtenerAsistenciaGradoPorFechas(rolUsuario, idGrado, fechaInicio, fechaFin).ToList();
                    return Ok(asistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista la asistencia para un grado entre dos fechas

        //Informes de calificaciones

        [HttpGet]
        [Route("ObtenerCalificacionesEstudiantePorFechas")]
        public IHttpActionResult ObtenerCalificacionesEstudiantePorFechas(int rolUsuario, int idEstudiante, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var calificaciones = context.ObtenerCalificacionesEstudiantePorFechas(rolUsuario, idEstudiante, fechaInicio, fechaFin).ToList();
                    return Ok(calificaciones);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista las calificaciones para un estudiante para determinado periodo


    }
}
