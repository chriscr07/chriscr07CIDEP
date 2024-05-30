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
    public class EstudiantesController : ApiController
    {
        [HttpGet]
        [Route("VerEstudiantes")]
        public IHttpActionResult VerEstudiantes()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiantes = context.VerEstudiantes().ToList();
                    return Ok(estudiantes);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todas los estudiantes

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("VerEstudiantesGrados")]
        public IHttpActionResult VerEstudiantesGrados()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiantes = context.VerEstudiantesGrados().ToList();
                    return Ok(estudiantes);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todas los estudiantes con grado asignado

        [HttpGet]
        [Route("VerEstudiantePorId")]
        public IHttpActionResult VerEstudiantePorId(int ID_Estudiante)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiante = context.Estudiantes
                                       .Where(e => e.ID_Estudiante == ID_Estudiante)
                                       .Select(e => new
                                       {
                                           e.ID_Estudiante,
                                           e.Cedula,
                                           e.Nombre,
                                           e.PrimerApellido,
                                           e.SegundoApellido,
                                           e.FechaNacimiento,
                                           e.ID_Usuario,
                                           e.Activo
                                       })
                                       .FirstOrDefault();
                    if (estudiante != null)
                    {
                        return Ok(estudiante);
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
        //lista docente por ID

        [HttpPost]
        [Route("RegistroEstudiante")]
        public IHttpActionResult RegistroEstudiante(EstudianteEntity estudiante)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.CrearEstudiante(estudiante.Cedula, estudiante.Nombre, estudiante.PrimerApellido, estudiante.SegundoApellido, 
                        estudiante.FechaNacimiento, estudiante.ID_Usuario, estudiante.RolUsuario, estudiante.ID_UsuarioQueInserta);

                    return Ok("Estudiante registrado");

                }
            }
            catch (Exception)
            {
                return BadRequest("Error al registrar");
            }
        } //registra un estudiante nuevo

        [HttpPut]
        [Route("DesactivarEstudiante")]
        public IHttpActionResult DesactivarEstudiante(EstudianteEntity estudianteDesactivado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.BorrarEstudiante(estudianteDesactivado.ID_Estudiante, estudianteDesactivado.RolUsuario, estudianteDesactivado.ID_UsuarioQueElimina);

                    return Ok("Estudiante desactivado");
                }
            }
            catch (Exception)
            {
                //return InternalServerError(ex);
                return BadRequest("No se pudo desactivar el estudiante");

            }
        } //desactivar usuario

        [HttpPut]
        [Route("EditarEstudiante")]
        public IHttpActionResult EditarEstudiante(EstudianteEntity estudianteEditado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.EditarEstudiante(estudianteEditado.ID_Estudiante, estudianteEditado.Cedula, estudianteEditado.Nombre, 
                        estudianteEditado.PrimerApellido, estudianteEditado.SegundoApellido, estudianteEditado.FechaNacimiento, estudianteEditado.RolUsuario,
                        estudianteEditado.Activo, estudianteEditado.ID_Usuario, estudianteEditado.ID_Usuario_Accion);

                    return Ok("Estudiante actualizado");
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        } //editar estudiante

        [HttpPut]
        [Route("DesenlazarUsuarioEstudiante")]
        public IHttpActionResult DesenlazarUsuarioEstudiante(EstudianteEntity estudianteEditado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudianteAEditar = context.Estudiantes.Where(e => e.ID_Estudiante == estudianteEditado.ID_Estudiante).FirstOrDefault();
                    estudianteAEditar.ID_Usuario = null;
                    context.SaveChanges();

                    return Ok("Usuario desenlazado del estudiante");
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        } 
    }
}
