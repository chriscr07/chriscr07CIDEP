using API.Entity;
using System;
using System.Linq;
using System.Web.Http;
using API.Models;
using System.Web.Http.Cors;

namespace API.Controllers
{
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("RegistroUsuario")]
        public IHttpActionResult RegistroUsuario(UsuarioEntity usuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = context.CrearUsuario(usuario.Nombre_Usuario, usuario.ID_RolUsuarioNuevo, usuario.Email, usuario.ID_Rol, usuario.ID_Usuario);
                    return Ok("Usuario registrado");
                   
                }
            }
            catch (Exception)
            {
                return BadRequest("Error al registrar");
            }
        } //registra un usuario nuevo

        [HttpGet]
        [Route("BuscarInformacionUsuario")]
        public IHttpActionResult BuscarInformacionUsuario(int id_usuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var usuarioBD = context.BuscarInformacionUsuario(id_usuario).
                        Select(u => new UsuarioEntity
                        {
                            IDstudentteacher = u.ID,
                            Nombre = u.Nombre,
                            PrimerApellido = u.PrimerApellido,
                            SegundoApellido = u.SegundoApellido,
                            Cedula = u.Cedula
                        }).FirstOrDefault();
                    return Ok(usuarioBD);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //buscará la información del perfil del usuario si es docente o estudiante

        [HttpGet]
        [Route("VerUsuarios")]
        public IHttpActionResult VerUsuarios()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var usuarios = context.VerUsuarios().ToList();
                    return Ok(usuarios);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista todos los usuarios del sistema

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("VerUsuarioPorId")]
        public IHttpActionResult VerUsuarioPorId(int ID_Usuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var usuarios = context.VerUsuarioPorId(ID_Usuario).FirstOrDefault();
                    return Ok(usuarios);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista el usuario buscado

        [HttpPut]
        [Route("EditarUsuario")]
        public IHttpActionResult EditarUsuario(UsuarioEntity usuarioEditado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = context.EditarUsuario(usuarioEditado.ID_Usuario, usuarioEditado.Nombre_Usuario, usuarioEditado.ID_Rol,
                         usuarioEditado.Email, usuarioEditado.RolUsuario, usuarioEditado.Activo, usuarioEditado.ID_Usuario_Accion);

                   
                    return Ok("Usuario actualizado");
                       
                    
                }
            }
            catch (Exception )
            {
                return InternalServerError();
            }
        } //editar usuario

        [HttpPut]
        [Route("DesactivarUsuario")]
        public IHttpActionResult DesactivarUsuario(UsuarioEntity usuarioDesactivado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.BorrarUsuario(usuarioDesactivado.ID_Usuario, usuarioDesactivado.RolUsuario, usuarioDesactivado.ID_UsuarioEditaUsuario);

                    
                    return Ok("Usuario desactivado");
                   
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        } //desactivar usuario

        [HttpGet]
        [Route("VerUsuariosDocentesDisponibles")]
        public IHttpActionResult VerUsuariosDocentesDisponibles(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var usuarios = context.ObtenerUsuariosNoAsignados(RolUsuario)
                                        .Where(u => u.ID_Rol == 2)
                                        .ToList();

                    return Ok(usuarios);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("VerUsuariosEstudiantesDisponibles")]
        public IHttpActionResult VerUsuarioEstudiantesDisponibles(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var usuarios = context.ObtenerUsuariosNoAsignados(RolUsuario)
                                        .Where(u => u.ID_Rol == 3)
                                        .ToList();

                    return Ok(usuarios);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }     
    }
}
