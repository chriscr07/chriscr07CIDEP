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
    public class ClasesController : ApiController
    {
        [HttpGet]
        [Route("VerClases")]
        public IHttpActionResult VerClases()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var clases = context.VerClases().ToList();
                    return Ok(clases);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista las clases

        [HttpGet]
        [Route("VerClasePorId")]
        public IHttpActionResult VerClasePorId(int ID_Clase)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var clases = context.VerClasePorID(ID_Clase).FirstOrDefault();
                    return Ok(clases);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //lista clase por ID

        [HttpPost]
        [Route("RegistroClase")]
        public IHttpActionResult RegistroClase(ClaseEntity clase)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.CrearClase(clase.ID_Curso, clase.ID_Grado, clase.ID_Usuario, clase.RolUsuario);
                  
                    return Ok("Clase registrado");
                

                }
            }
            catch (Exception)
            {
                //return BadRequest("Error al registrar");
                return InternalServerError();
            }
        } //registra una clase nueva

        [HttpPut]
        [Route("DesactivarClase")]
        public IHttpActionResult DesactivarClase(ClaseEntity clase)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.BorrarClase(clase.ID_Clase, clase.RolUsuario, clase.ID_Usuario);
            
                    return Ok("Clase desactivada");
                    

                }
            }
            catch (Exception)
            {
                return BadRequest("Error al desactivar");
            }
        } //desactivar clase

        [HttpPut]
        [Route("EditarClase")]
        public IHttpActionResult EditarClase(ClaseEntity claseEditada)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.EditarClase(claseEditada.ID_Clase, claseEditada.ID_Curso, claseEditada.ID_Grado, 
                        claseEditada.RolUsuario, claseEditada.ID_Usuario, claseEditada.Activo);

                    return Ok("Clase editada");


                }
            }
            catch (Exception)
            {
                //return BadRequest("Error al editar");
                return InternalServerError();
            }
        } //editar clase

    }
}
