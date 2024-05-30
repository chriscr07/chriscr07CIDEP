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
    public class EstadosAsistenciaController : ApiController
    {
        [HttpGet]
        [Route("VerEstadosAsistencia")]
        public IHttpActionResult VerEstadosAsistencia()
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estadosAsistencia = context.VerEstadosAsistencia().ToList();
                    return Ok(estadosAsistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } //lista los estados

        [HttpGet]
        [Route("VerEstadoAsistenciaPorId")]
        public IHttpActionResult VerEstadoAsistenciaPorId(int ID_Estado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var estadosAsistencia = context.VerEstadoAsistenciaPorID(ID_Estado).FirstOrDefault();
                    return Ok(estadosAsistencia);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //lista estado por ID

        [HttpPost]
        [Route("RegistroEstadoAsistencia")]
        public IHttpActionResult RegistroEstadoAsistencia(EstadoAsistenciaEntity estadoAsistencia)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.CrearEstadoAsistencia(estadoAsistencia.NombreEstado, estadoAsistencia.ID_Usuario, estadoAsistencia.RolUsuario);

                    return Ok("Estado de asistencia registrado");


                }
            }
            catch (Exception)
            {
                //return BadRequest("Error al registrar");
                return InternalServerError();
            }
        } //registra un nuevo estado

        [HttpPut]
        [Route("DesactivarEstadoAsistencia")]
        public IHttpActionResult DesactivarEstadoAsistencia(EstadoAsistenciaEntity estadoAsistencia)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.BorrarEstadoAsistencia(estadoAsistencia.ID_Estado, estadoAsistencia.RolUsuario, estadoAsistencia.ID_Usuario);

                    return Ok("Estado de asistencia desactivado");


                }
            }
            catch (Exception)
            {
                return BadRequest("Error al desactivar");
            }
        } //desactivar estado de asistencia

        [HttpPut]
        [Route("EditarEstadoAsistencia")]
        public IHttpActionResult EditarEstadoAsistencia(EstadoAsistenciaEntity estadoAsistenciaEditado)
        {
            try
            {
                using (var context = new CIDEPEntities())
                {
                    var respuestaBD = (int)context.EditarEstadoAsistencia(estadoAsistenciaEditado.ID_Estado, estadoAsistenciaEditado.NombreEstado,
                    estadoAsistenciaEditado.RolUsuario, estadoAsistenciaEditado.ID_Usuario, estadoAsistenciaEditado.Activo);

                    return Ok("Estado de asistencia editado");


                }
            }
            catch (Exception)
            {
                //return BadRequest("Error al editar");
                return InternalServerError();
            }
        } //editar estado de asistencia

    }
}