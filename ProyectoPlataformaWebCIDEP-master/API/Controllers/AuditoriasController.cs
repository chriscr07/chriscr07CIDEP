using API.Entity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class AuditoriasController : ApiController
    {
        [HttpGet]
        [Route("VerAuditoriaAdministracion")]
        public IHttpActionResult VerAuditoriaAdministracion(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var auditorias = context.VerAuditoriaAdministracion(RolUsuario).ToList();
                    return Ok(auditorias);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista auditoria admin

        [HttpGet]
        [Route("VerAuditoriaAsistencia")]
        public IHttpActionResult VerAuditoriaAsistencia(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var auditorias = context.VerAuditoriaAsistencia(RolUsuario).ToList();
                    return Ok(auditorias);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista auditoria asistencia

        [HttpGet]
        [Route("VerAuditoriaAvisos")]
        public IHttpActionResult VerAuditoriaAvisos(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var auditorias = context.VerAuditoriaAvisosGenerales(RolUsuario).ToList();
                    return Ok(auditorias);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista auditoria avisos generales

        [HttpGet]
        [Route("VerAuditoriaCalificaciones")]
        public IHttpActionResult VerAuditoriaCalificaciones(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var auditorias = context.VerAuditoriaCalificaciones(RolUsuario).ToList();
                    return Ok(auditorias);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista auditoria calificaciones

        [HttpGet]
        [Route("VerAuditoriaClases")]
        public IHttpActionResult VerAuditoriaClases(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var auditorias = context.VerAuditoriaClases(RolUsuario).ToList();
                    return Ok(auditorias);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista auditoria clases

        [HttpGet]
        [Route("VerAuditoriaDocentes")]
        public IHttpActionResult VerAuditoriaDocentes(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var auditorias = context.VerAuditoriaDocentes(RolUsuario).ToList();
                    return Ok(auditorias);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista auditoria docentes

        [HttpGet]
        [Route("VerAuditoriaEstudiantes")]
        public IHttpActionResult VerAuditoriaEstudiantes(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var auditorias = context.VerAuditoriaEstudiantes(RolUsuario).ToList();
                    return Ok(auditorias);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista auditoria estudiantes

        [HttpGet]
        [Route("VerAuditoriaLogins")]
        public IHttpActionResult VerAuditoriaLogins(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var auditorias = context.VerAuditoriaIniciosSesion(RolUsuario).ToList();
                    return Ok(auditorias);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista auditoria inicios de sesión
    }
}