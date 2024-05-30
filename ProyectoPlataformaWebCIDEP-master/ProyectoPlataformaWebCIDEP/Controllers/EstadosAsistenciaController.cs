using ProyectoPlataformaWebCIDEP.Entity;
using ProyectoPlataformaWebCIDEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPlataformaWebCIDEP.Controllers
{
    [Authorize]
    public class EstadosAsistenciaController : Controller
    {     
        public EstadosAsistenciaModel estadosAsistenciaModel = new EstadosAsistenciaModel();


        [HttpGet]
        public ActionResult EstadosAsistencia()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int) Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;
                    estadosAsistenciaModel.EstadosAsistencia = estadosAsistenciaModel.ListarEstadosAsistencia();
                    return View(estadosAsistenciaModel);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult RegistrarEstadoAsistencia()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    return View();
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult RegistrarEstadoAsistencia(EstadoAsistenciaEntity estadoAsistenciaNuevo)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                estadoAsistenciaNuevo.RolUsuario = (int)Session["ID_Rol"];
                estadoAsistenciaNuevo.ID_Usuario = (int)Session["ID_Usuario"];
                var resultado = estadosAsistenciaModel.RegistrarEstadoAsistencia(estadoAsistenciaNuevo);

                TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                return RedirectToAction("EstadosAsistencia", "EstadosAsistencia");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [HttpGet]
        public ActionResult EditarEstadoAsistencia(int ID_Estado)
        {
            if (ID_Estado == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {

                    var estadoAsistencia = estadosAsistenciaModel.ListarEstadoAsistencia(ID_Estado);
                    if (estadoAsistencia == null)
                    {
                        return RedirectToAction("EstadosAsistencia", "EstadosAsistencia");
                    }

                    return View(estadoAsistencia);
                }
            return RedirectToAction("Perfil", "Perfil");

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditarEstadoAsistencia(EstadoAsistenciaEntity estadoAsistenciaEditado)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                estadoAsistenciaEditado.RolUsuario = (int)Session["ID_Rol"];
                estadoAsistenciaEditado.ID_Usuario = (int)Session["ID_Usuario"];
                var resultado = estadosAsistenciaModel.EditarEstadoAsistencia(estadoAsistenciaEditado);

                TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                return RedirectToAction("EstadosAsistencia", "EstadosAsistencia");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult DesactivarEstadoAsistencia(EstadoAsistenciaEntity estadoAsistenciaDesactivado)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                estadoAsistenciaDesactivado.RolUsuario = (int)Session["ID_Rol"];
                estadoAsistenciaDesactivado.ID_Usuario = (int)Session["ID_Usuario"];
                var resultado = estadosAsistenciaModel.DesactivarEstadoAsistencia(estadoAsistenciaDesactivado);

                TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                return RedirectToAction("EstadosAsistencia", "EstadosAsistencia");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}