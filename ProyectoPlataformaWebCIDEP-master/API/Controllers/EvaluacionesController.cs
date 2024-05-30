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
    public class EvaluacionesController : ApiController
    {
        [HttpGet]
        [Route("VerEvaluaciones")]
        public IHttpActionResult VerEvaluaciones()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var cursos = context.TiposEvaluaciones.Select(e => new
                    {
                        e.ID_TipoEvaluacion,
                        e.Descripcion,
                        e.Activo
                    }).ToList();
                    return Ok(cursos);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todos los tipos de evaluaciones


        [HttpGet]
        [Route("VerEvaluacionPorId")]
        public IHttpActionResult VerEvaluacionPorId(int ID_TipoEvaluacion)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var evaluacion = context.TiposEvaluaciones
                                       .Where(e => e.ID_TipoEvaluacion == ID_TipoEvaluacion)
                                       .Select(c => new
                                       {
                                           c.ID_TipoEvaluacion,
                                           c.Descripcion,
                                           c.Activo
                                       })
                                       .FirstOrDefault();
                    if (evaluacion != null)
                    {
                        return Ok(evaluacion);
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
        //lista tipo de evaluación por ID

        [HttpPost]
        [Route("RegistroTipoEvaluacion")]
        public IHttpActionResult RegistroTipoEvaluacion(EvaluacionEntity tipoEvaluacion)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.CrearTipoEvaluacion(tipoEvaluacion.Descripcion, tipoEvaluacion.RolUsuario);
                    if (respuestaBD == 1)
                    {
                        return Ok("Tipo de evaluacion registrado");
                    }
                    else
                    {
                        return BadRequest("No se pudo registrar");
                    }

                }
            }
            catch (Exception)
            {
                return BadRequest("Error al registrar");
            }
        } //registra un  tipo de evaluación

        [HttpPut]
        [Route("DesactivarTipoEvaluacion")]
        public IHttpActionResult DesactivarTipoEvaluacion(EvaluacionEntity tipoEvaluacion)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var evaluacionDesactivada = context.TiposEvaluaciones.FirstOrDefault(t => t.ID_TipoEvaluacion == tipoEvaluacion.ID_TipoEvaluacion);

                    if (evaluacionDesactivada != null)
                    {
                        evaluacionDesactivada.Activo = false;
                        context.SaveChanges();
                        return Ok("Tipo de evaluacion desactivada");
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
        } //desactivar grado

        [HttpPut]
        [Route("EditarTipoEvaluacion")]
        public IHttpActionResult EditarCurso(EvaluacionEntity evaluacionEditada)
        {
            try
            {
                if (evaluacionEditada.RolUsuario == 1)
                {
                    using (var context = new CIDEPEntities())
                    {
                        var grado = context.TiposEvaluaciones.FirstOrDefault(t => t.ID_TipoEvaluacion == evaluacionEditada.ID_TipoEvaluacion);

                        if (grado != null)
                        {
                            if (!string.IsNullOrEmpty(evaluacionEditada.Descripcion))
                            {
                                grado.Descripcion = evaluacionEditada.Descripcion;
                            }
                            grado.Activo = evaluacionEditada.Activo;
                            context.SaveChanges();
                            return Ok("Tipo de evaluacion actualizado");
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
        } //editar tipo de evaluación
    }
}
