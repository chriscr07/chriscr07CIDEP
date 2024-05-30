using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class RolesController : ApiController
    {
        [HttpGet]
        [Route("VerRoles")]
        public IHttpActionResult VerRoles(int RolUsuario)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = context.VerRoles(RolUsuario).ToList();                 
                    return Ok(respuestaBD);                  
                }
            }
            catch (Exception)
            {
                return BadRequest("Error al registrar");
            }
        } //listar los roles de usuarios
    }
}
