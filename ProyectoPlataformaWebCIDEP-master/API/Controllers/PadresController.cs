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
    public class PadresController : ApiController
    {
        [HttpGet]
        [Route("VerPadres")]
        public IHttpActionResult VerPadres()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var padres = context.VerPadres().ToList();
                    return Ok(padres);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todos los padres

        [HttpGet]
        [Route("VerPadrePorId")]
        public IHttpActionResult VerPadrePorId(int ID_Padre)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var padre = context.Padres
                                       .Where(e => e.ID_Padre == ID_Padre)
                                       .Select(e => new
                                       {
                                           e.ID_Padre,
                                           e.Nombre,
                                           e.PrimerApellido,
                                           e.SegundoApellido,
                                           e.Numero,
                                           e.Email
                                       })
                                       .FirstOrDefault();
                    if (padre != null)
                    {
                        return Ok(padre);
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
        //lista padre por ID

        [HttpPost]
        [Route("RegistroPadre")]
        public IHttpActionResult RegistroPadre(PadreEntity padre)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.CrearPadre(padre.Nombre, padre.PrimerApellido, padre.SegundoApellido, padre.Email,
                        padre.Numero, padre.RolUsuario, padre.ID_UsuarioQueInserta);

                    return Ok("Padre registrado");

                }
            }
            catch (Exception)
            {
                return BadRequest("Error al registrar");
            }
        } //registra un padre nuevo

        [HttpPut]
        [Route("EditarPadre")]
        public IHttpActionResult EditarPadre(PadreEntity padreEditado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.EditarPadre(padreEditado.ID_Padre, padreEditado.Nombre, padreEditado.PrimerApellido, padreEditado.SegundoApellido,
                        padreEditado.RolUsuario, padreEditado.Email, padreEditado.Numero, padreEditado.ID_Usuario_Accion);

                    return Ok("Padre actualizado");
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        } //editar padre

        [HttpPost]
        [Route("EliminarPadre")]
        public IHttpActionResult EliminarPadre(PadreEntity padreEditado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.EliminarPadre(padreEditado.ID_Padre, padreEditado.RolUsuario, padreEditado.ID_Usuario_Accion);

                    return Ok("Padre eliminado");
                }
            }
            catch (Exception )
            {
                return InternalServerError();
            }
        } //eliminar padre
    }
}
