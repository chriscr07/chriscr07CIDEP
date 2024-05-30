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
    public class DocentesClasesController : ApiController
    {

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("VerDocentesClases")]
        public IHttpActionResult VerDocentesClases()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var docentesClases = context.VerDocentesClases().ToList();
                    return Ok(docentesClases);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todas los docentes con clase asignada

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("VerDocenteClases")]
        public IHttpActionResult VerDocenteClases(int ID_Docente)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var docentesClases = context.VerDocentesClases()
                                            .Where(dc => dc.ID_Docente == ID_Docente)
                                            .ToList();
                    return Ok(docentesClases);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("InsertarDocenteClase")]
        public IHttpActionResult InsertarDocenteClase(DocenteClaseEntity docenteClase)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var docenteClaseExistente = context.DocentesClases.FirstOrDefault(eg => eg.ID_Docente == docenteClase.ID_Docente && eg.ID_Clase == docenteClase.ID_Clase);

                    if (docenteClaseExistente != null)
                    {
                      
                        return BadRequest("El registro ya existe.");
                    }

                    else
                    {
                        var docente = context.Docentes.FirstOrDefault(e => e.ID_Docente == docenteClase.ID_Docente);
                        if (docente == null)
                        {
                            return Content(HttpStatusCode.NotFound, "El docente no está registrado.");
                        }

                        var clase = context.Clases.FirstOrDefault(g => g.ID_Clase == docenteClase.ID_Clase);
                        if (clase == null)
                        {
                            return Content(HttpStatusCode.NotFound, "La clase no está registrada.");
                        }

                        var nuevoDocenteClase = new DocentesClases
                        {
                            ID_Docente = docenteClase.ID_Docente,
                            ID_Clase = docenteClase.ID_Clase
                        };

                        context.DocentesClases.Add(nuevoDocenteClase);
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
        [Route("EliminarDocenteClase")]
        public IHttpActionResult EliminarDocenteClase(int ID_DocenteClase)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var docenteClase = context.DocentesClases.FirstOrDefault(dc => dc.ID_DocenteClase == ID_DocenteClase);
                    if (docenteClase != null)
                    {
                        context.DocentesClases.Remove(docenteClase);
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
                return BadRequest("Error al intentar eliminar el registro.");
            }
        }
    }
}
