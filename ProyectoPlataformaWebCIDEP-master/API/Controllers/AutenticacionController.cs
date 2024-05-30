using API.Entity;
using System;
using System.Linq;
using System.Web.Http;
using API.Models;
using System.Web.Http.Cors;


namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class AutenticacionController : ApiController
    {

        [HttpPost]
        [Route("InicioSesion")]
        public IHttpActionResult InicioSesion(UsuarioEntity usuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var usuarioBD = context.IniciarSesion(usuario.Nombre_Usuario, usuario.Contrasenna)
                        .Select(u => new UsuarioEntity
                        {
                            ID_Usuario = u.ID_Usuario,
                            Nombre_Usuario = u.Nombre_Usuario,
                            ID_Rol = u.ID_Rol,
                            Activo = u.Activo,
                            NombreRol = u.NombreRol
                        }).FirstOrDefault();

                    if (usuarioBD.ID_Usuario != 0 && usuarioBD.Nombre_Usuario != null
                        && usuarioBD.ID_Rol != 0
                        && usuarioBD.Activo != false)
                    {
                        return Ok(usuarioBD);
                    }
                    else
                    {
                        return BadRequest("Error al iniciar sesión.");
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("Error al iniciar sesión.");
            }
        } //inicia sesión y devuelve la información del usuario autenticado

        [HttpPost]
        [Route("RecuperarContrasennaPaso1")]
        public IHttpActionResult RecuperarContrasennaPaso1(UsuarioEntity usuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var tokenEntity = context.RecuperarContrasennaPaso1(usuario.Email)
                        .Select(t => new TokenEntity
                        {
                            ID_Usuario = t.ID_Usuario,
                            Token = t.Token,
                            FechaCreacion = t.FechaCreacion
                        }).FirstOrDefault();

                    if (tokenEntity != null)
                    {
                        return Ok(tokenEntity);
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
        }//se verifica la existencia del correo electrónico del usuario que va a recuperar contraseña

        [HttpPut]
        [Route("RecuperarContrasennaPaso2")]
        public IHttpActionResult RecuperarContrasennaPaso2(TokenEntity token)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuesta = context.RecuperarContrasennaPaso2(token.Email, token.Token, token.NuevaContrasenna).FirstOrDefault();

                    if (respuesta != null)
                    {
                        return Ok("Contraseña recuperada");
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
        }//se realiza el paso dos de la recuperación de contraseña de un usuario

        [HttpPut]
        [Route("CambiarContrasenna")]
        public IHttpActionResult CambiarContrasenna(UsuarioEntity usuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuesta = context.CambiarContrasenna(usuario.ID_Usuario, usuario.ContrasennaActual, usuario.NuevaContrasenna).FirstOrDefault();

                    if (respuesta != "Contraseña incorrecta.")
                    {
                        return Ok(respuesta);
                    }
                    else
                    {
                        return BadRequest(respuesta);
                    }
                }

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }//se actualiza la contraseña
    }

}