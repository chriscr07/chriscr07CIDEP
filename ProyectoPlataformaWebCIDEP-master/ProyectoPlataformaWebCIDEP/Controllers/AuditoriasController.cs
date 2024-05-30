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
    public class AuditoriasController : Controller
    {
        public AuditoriasModel auditoriasModel = new AuditoriasModel();
        [HttpGet]
        public ActionResult Auditorias()
        {
            if ((int)Session["ID_Rol"] != 0)
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

        [HttpGet]
        public ActionResult AuditoriaAdministracion()
        {
            if ((int)Session["ID_Rol"] == 1)
            {
                int RolUsuario = (int)Session["ID_Rol"];
                auditoriasModel.Auditorias = auditoriasModel.ListarAuditoriaAdministracion(RolUsuario);
                return View(auditoriasModel);
            }
            else if ((int)Session["ID_Rol"] != 1 && (int)Session["ID_Rol"] != 0)
            {
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        [HttpGet]
        public ActionResult AuditoriaAsistencia()
        {
            if ((int)Session["ID_Rol"] == 1)
            {
                int RolUsuario = (int)Session["ID_Rol"];
                auditoriasModel.Auditorias = auditoriasModel.ListarAuditoriaAsistencia(RolUsuario);
                return View(auditoriasModel);
            }
            else if ((int)Session["ID_Rol"] != 1 && (int)Session["ID_Rol"] != 0)
            {
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AuditoriaAvisos()
        {
            if ((int)Session["ID_Rol"] == 1)
            {
                int RolUsuario = (int)Session["ID_Rol"];
                auditoriasModel.Auditorias = auditoriasModel.ListarAuditoriaAvisos(RolUsuario);
                return View(auditoriasModel);
            }
            else if ((int)Session["ID_Rol"] != 1 && (int)Session["ID_Rol"] != 0)
            {
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AuditoriaCalificaciones()
        {
            if ((int)Session["ID_Rol"] == 1)
            {
                int RolUsuario = (int)Session["ID_Rol"];
                auditoriasModel.Auditorias = auditoriasModel.ListarAuditoriaCalificaciones(RolUsuario);
                return View(auditoriasModel);
            }
            else if ((int)Session["ID_Rol"] != 1 && (int)Session["ID_Rol"] != 0)
            {
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AuditoriaClases()
        {
            if ((int)Session["ID_Rol"] == 1)
            {
                int RolUsuario = (int)Session["ID_Rol"];
                auditoriasModel.Auditorias = auditoriasModel.ListarAuditoriaClases(RolUsuario);
                return View(auditoriasModel);
            }
            else if ((int)Session["ID_Rol"] != 1 && (int)Session["ID_Rol"] != 0)
            {
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AuditoriaDocentes()
        {
            if ((int)Session["ID_Rol"] == 1)
            {
                int RolUsuario = (int)Session["ID_Rol"];
                auditoriasModel.Auditorias = auditoriasModel.ListarAuditoriaDocentes(RolUsuario);
                return View(auditoriasModel);
            }
            else if ((int)Session["ID_Rol"] != 1 && (int)Session["ID_Rol"] != 0)
            {
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AuditoriaEstudiantes()
        {
            if ((int)Session["ID_Rol"] == 1)
            {
                int RolUsuario = (int)Session["ID_Rol"];
                auditoriasModel.Auditorias = auditoriasModel.ListarAuditoriaEstudiantes(RolUsuario);
                return View(auditoriasModel);
            }
            else if ((int)Session["ID_Rol"] != 1 && (int)Session["ID_Rol"] != 0)
            {
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AuditoriaLogins()
        {
            if ((int)Session["ID_Rol"] == 1)
            {
                int RolUsuario = (int)Session["ID_Rol"];
                auditoriasModel.Auditorias = auditoriasModel.ListarAuditoriaLogins(RolUsuario);
                return View(auditoriasModel);
            }
            else if ((int)Session["ID_Rol"] != 1 && (int)Session["ID_Rol"] != 0)
            {
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}