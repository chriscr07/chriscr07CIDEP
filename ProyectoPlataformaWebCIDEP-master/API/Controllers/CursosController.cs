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
    public class CursosController : ApiController
    {
        [HttpGet]
        [Route("VerCursos")]
        public IHttpActionResult VerCursos()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var cursos = context.Cursos.Select(c => new
                    {
                        c.ID_Curso,
                        c.NombreCurso,
                        c.Activo
                    }).ToList();
                    return Ok(cursos);                  
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todos los cursos

        [HttpGet]
        [Route("VerCursoPorId")]
        public IHttpActionResult VerCursoPorId(int ID_Curso)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var curso = context.Cursos
                                       .Where(c => c.ID_Curso == ID_Curso)
                                       .Select(c => new
                                       {
                                           c.ID_Curso,
                                           c.NombreCurso,
                                           c.Activo
                                       })
                                       .FirstOrDefault();
                    if (curso != null)
                    {
                        return Ok(curso);
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
        //lista curso por ID

        [HttpPost]
        [Route("RegistroCurso")]
        public IHttpActionResult RegistroCurso(CursoEntity curso)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.CrearCurso(curso.NombreCurso, curso.RolUsuario, curso.ID_Usuario);
                  
                    return Ok("Curso registrado");
                

                }
            }
            catch (Exception)
            {
                return BadRequest("Error al registrar");
            }
        } //registra un curso nuevo

        [HttpPut]
        [Route("DesactivarCurso")]
        public IHttpActionResult DesactivarCurso(CursoEntity curso)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var cursoDesactivado = context.Cursos.FirstOrDefault(c => c.ID_Curso == curso.ID_Curso);

                    if (cursoDesactivado != null)
                    {
                        cursoDesactivado.Activo = false;
                        context.SaveChanges();
                        return Ok("Curso desactivado");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        } //desactivar curso

        [HttpPut]
        [Route("EditarCurso")]
        public IHttpActionResult EditarCurso(CursoEntity cursoEditado)
        {
            try
            {
                if (cursoEditado.RolUsuario == 1)
                {
                    using (var context = new CIDEPEntities())
                    {
                        var curso = context.Cursos.FirstOrDefault(c => c.ID_Curso == cursoEditado.ID_Curso);

                        if (curso != null)
                        {
                            if (!string.IsNullOrEmpty(cursoEditado.NombreCurso))
                            {
                                curso.NombreCurso = cursoEditado.NombreCurso;
                            }
                            curso.Activo = cursoEditado.Activo;
                            context.SaveChanges();
                            return Ok("Curso actualizado");
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        } //editar curso








    }
}
