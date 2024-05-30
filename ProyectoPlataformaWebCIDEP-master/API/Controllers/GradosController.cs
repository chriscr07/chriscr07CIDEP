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
    public class GradosController : ApiController
    {
        [HttpGet]
        [Route("VerGrados")]
        public IHttpActionResult VerGrados()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var cursos = context.Grados.Select(g => new
                    {
                        g.ID_Grado,
                        g.NombreGrado,
                        g.Activo
                    }).ToList();
                    return Ok(cursos);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todos los grados

        [HttpGet]
        [Route("VerGradoPorId")]
        public IHttpActionResult VerGradoPorId(int ID_Grado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var grado = context.Grados
                                       .Where(c => c.ID_Grado == ID_Grado)
                                       .Select(c => new
                                       {
                                           c.ID_Grado,
                                           c.NombreGrado,
                                           c.Activo
                                       })
                                       .FirstOrDefault();
                    if (grado != null)
                    {
                        return Ok(grado);
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
        //lista grado por ID

        [HttpPost]
        [Route("RegistroGrado")]
        public IHttpActionResult RegistroGrado(GradoEntity grado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.CrearGrado(grado.NombreGrado, grado.RolUsuario);
                    if (respuestaBD == 1)
                    {
                        return Ok("Grado registrado");
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
        } //registra un grado nuevo

        [HttpPut]
        [Route("DesactivarGrado")]
        public IHttpActionResult DesactivarGrado(GradoEntity grado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var gradoDesactivado = context.Grados.FirstOrDefault(g => g.ID_Grado == grado.ID_Grado);

                    if (gradoDesactivado != null)
                    {
                        gradoDesactivado.Activo = false;
                        context.SaveChanges();
                        return Ok("Grado desactivado");
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
        [Route("EditarGrado")]
        public IHttpActionResult EditarCurso(GradoEntity gradoEditado)
        {
            try
            {
                if (gradoEditado.RolUsuario == 1)
                {
                    using (var context = new CIDEPEntities())
                    {
                        var grado = context.Grados.FirstOrDefault(g => g.ID_Grado == gradoEditado.ID_Grado);

                        if (grado != null)
                        {
                            if (!string.IsNullOrEmpty(gradoEditado.NombreGrado))
                            {
                                grado.NombreGrado = gradoEditado.NombreGrado;
                            }
                            grado.Activo = gradoEditado.Activo;
                            context.SaveChanges();
                            return Ok("Grado actualizado");
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
        } //editar grado

    }
}
