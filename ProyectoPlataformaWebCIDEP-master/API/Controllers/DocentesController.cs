using API.Entity;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DocentesController : ApiController
    {
        [HttpGet]
        [Route("VerDocentes")]
        public IHttpActionResult VerDocentes()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var docentes = context.VerDocentes().ToList();
                    return Ok(docentes);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todos los docentes

        [HttpGet]
        [Route("VerDocentePorId")]
        public IHttpActionResult VerDocentePorId(int ID_Docente)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiante = context.Docentes
                                       .Where(e => e.ID_Docente == ID_Docente)
                                       .Select(e => new
                                       {
                                           e.ID_Docente,
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
        [Route("RegistroDocente")]
        public IHttpActionResult RegistroDocente(DocenteEntity docente)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.CrearDocente(docente.Cedula, docente.Nombre, docente.PrimerApellido, docente.SegundoApellido,
                        docente.FechaNacimiento, docente.ID_Usuario, docente.RolUsuario, docente.ID_UsuarioQueInserta);

                    return Ok("Docente registrado");
                         

                }
            }
            catch (Exception)
            {
                return BadRequest("Error al registrar");
            }
        } //registra un docente nuevo

        [HttpPut]
        [Route("DesactivarDocente")]
        public IHttpActionResult DesactivarDocente(DocenteEntity docenteDesactivado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.BorrarDocente(docenteDesactivado.ID_Docente, docenteDesactivado.RolUsuario, docenteDesactivado.ID_UsuarioQueElimina);

                    return Ok("Docente desactivado");
                }
            }
            catch (Exception)
            {
                return BadRequest("No se pudo desactivar el docente");
            }
        } //desactivar docente

        [HttpPut]
        [Route("EditarDocente")]
        public IHttpActionResult EditarDocente(DocenteEntity docenteEditado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.EditarDocente(docenteEditado.ID_Docente, docenteEditado.Cedula, docenteEditado.Nombre,
                        docenteEditado.PrimerApellido, docenteEditado.SegundoApellido, docenteEditado.FechaNacimiento, docenteEditado.RolUsuario,
                        docenteEditado.Activo, docenteEditado.ID_Usuario, docenteEditado.ID_Usuario_Accion);

                    return Ok("Docente actualizado");
                }
            }
            catch (Exception)
            {
                //return InternalServerError(ex);
                return BadRequest("No se pudo actualizar el docente");

            }
        } //editar docente

        [HttpPut]
        [Route("DesenlazarUsuarioDocente")]
        public IHttpActionResult DesenlazarUsuarioDocente(DocenteEntity docenteEditado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var docenteAEditar = context.Docentes.Where(e => e.ID_Docente == docenteEditado.ID_Docente).FirstOrDefault();
                    docenteAEditar.ID_Usuario = null;
                    context.SaveChanges();

                    return Ok("Usuario desenlazado del docente");
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
