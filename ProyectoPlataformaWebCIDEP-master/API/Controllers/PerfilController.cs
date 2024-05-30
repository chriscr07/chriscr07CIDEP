using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PerfilController : ApiController
    {
        [HttpGet]
        [Route("VerPerfilDeDocente")]
        public IHttpActionResult VerPerfilDeDocente(int ID_Usuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var docente = context.VerPerfilDeDocente(ID_Usuario).FirstOrDefault();
                    return Ok(docente);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("VerPerfilDeEstudiante")]
        public IHttpActionResult VerPerfilDeEstudiante(int ID_Usuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estudiante = context.VerPerfilDeEstudiante(ID_Usuario).FirstOrDefault();
                    return Ok(estudiante);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("VerPerfilDeAdministrador")]
        public IHttpActionResult VerPerfilDeAdministrador(int ID_Usuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var administrador = context.VerPerfilDeAdministrador(ID_Usuario).FirstOrDefault();
                    return Ok(administrador);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
