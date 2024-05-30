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
    public class DocentesController : Controller
    {
        public DocentesModel docentesModel = new DocentesModel();
        public UsuariosModel usuariosModel = new UsuariosModel();

        [HttpGet]
        public ActionResult Docentes()
        {         
            if (Session["ID_Usuario"] != null)
            {
                if ((int) Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;
                    docentesModel.Docentes = docentesModel.ListarDocentes();
                    return View(docentesModel);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult VerDocentesUsuarios()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;
                    docentesModel.Docentes = docentesModel.ListarDocentesUsuarios().Where(e => e.ID_Usuario.HasValue).ToList();
                    return View(docentesModel);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult RegistrarDocente()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var usuarioDocente = usuariosModel.ListarUsuariosDisponiblesDocentes((int)Session["ID_Rol"]);
                    var listaUsuarios = usuarioDocente.Select(r => new { Value = r.ID_Usuario, Text = $"{r.Nombre_Usuario}" });

                    ViewBag.listaUsuarios = new SelectList(listaUsuarios, "Value", "Text");
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
        public ActionResult RegistrarDocente(DocenteEntity docenteNuevo)
        {
            docenteNuevo.RolUsuario = (int)Session["ID_Rol"];
            docenteNuevo.ID_UsuarioQueInserta = (int)Session["ID_Usuario"];
            var resultado = docentesModel.RegistrarDocente(docenteNuevo);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Docentes", "Docentes");
            
        }

        [HttpPost]
        public ActionResult DesactivarDocente(DocenteEntity docenteEditado)
        {
            docenteEditado.RolUsuario = (int)Session["ID_Rol"];
            docenteEditado.ID_UsuarioQueElimina = (int)Session["ID_Usuario"];
            var resultado = docentesModel.DesactivarDocente(docenteEditado);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Docentes", "Docentes");
        }

        [HttpGet]
        public ActionResult EditarDocente(int ID_Docente)
        {
            if (ID_Docente == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var docente = docentesModel.ListarDocente(ID_Docente);
                    if (docente == null)
                    {
                        return RedirectToAction("Docentes", "Docentes");
                    }

                    var usuarioDocente = usuariosModel.ListarUsuariosDisponiblesDocentes((int)Session["ID_Rol"]);
                    var listaUsuarios = usuarioDocente.Select(r => new { Value = r.ID_Usuario, Text = $"{r.Nombre_Usuario}" });

                    ViewBag.listaUsuarios = new SelectList(listaUsuarios, "Value", "Text");

                    return View(docente);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditarDocente(DocenteEntity docenteEditado)
        {
            docenteEditado.RolUsuario = (int)Session["ID_Rol"];
            docenteEditado.ID_Usuario_Accion = (int)Session["ID_Usuario"];

            var resultado = docentesModel.EditarDocente(docenteEditado).ToString();

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Docentes", "Docentes");
        }

        [HttpPost]
        public ActionResult DesenlazarUsuarioDocente(DocenteEntity docenteEditado)
        {     
            var resultado = docentesModel.DesenlazarUsuarioDocente(docenteEditado).ToString();

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("VerDocentesUsuarios", "Docentes");
        }

    }
}