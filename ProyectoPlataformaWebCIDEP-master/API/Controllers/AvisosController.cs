using API.Entity;
using API.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    public class AvisosController : ApiController
    {
        [HttpPost]
        [Route("CrearAvisoGeneral")]
        public IHttpActionResult CrearAvisoGeneral(AvisoGeneralEntity avisogeneral)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    context.CrearAvisoGeneral(avisogeneral.Mensaje, avisogeneral.ID_Usuario);
                    return Ok("Aviso General registrado");
                }
            }
            catch (Exception)
            {
                return BadRequest("Error al registrar");
            }
        }

        [HttpGet]
        [Route("VerAvisosGenerales")]
        public IHttpActionResult VerAvisosGenerales()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var avisosGenerales = context.VerAvisosGenerales().ToList();
                    return Ok(avisosGenerales);
                }
            }
            catch (Exception)
            {
                return BadRequest("Error al obtener los avisos generales");
            }
        }

        [HttpGet]
        [Route("VerAvisoGeneral")]
        public IHttpActionResult VerAvisoGeneral(int ID_AvisoGeneral)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var avisosGenerales = context.VerAvisoGeneral(ID_AvisoGeneral).FirstOrDefault();
                    return Ok(avisosGenerales);
                }
            }
            catch (Exception)
            {
                return BadRequest("Error al obtener aviso");
            }
        }


        [HttpPut]
        [Route("EditarAvisoGeneral")]
        public IHttpActionResult EditarAvisoGeneral(AvisoGeneralEntity avisogeneral)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    context.EditarAvisoGeneral(
                        avisogeneral.ID_AvisoGeneral,
                        avisogeneral.Mensaje,
                        avisogeneral.ID_Usuario
                        );
                }
                return Ok("Aviso General actualizado.");
            }
            catch (Exception e)
            {
                return BadRequest("Error al actualizar" + e);
            }
        }

        [HttpDelete]
        [Route("BorrarAvisoGeneral")]
        public IHttpActionResult BorrarAvisoGeneral(AvisoGeneralEntity avisogeneral)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    context.BorrarAvisoGeneral(
                        avisogeneral.ID_AvisoGeneral,
                        avisogeneral.RolUsuario,
                        avisogeneral.ID_Usuario
                        );
                }
                return Ok("Aviso general eliminado.");
            }
            catch (Exception)
            {
                return BadRequest("Error al eliminar aviso general.");
            }

        }
    }
}