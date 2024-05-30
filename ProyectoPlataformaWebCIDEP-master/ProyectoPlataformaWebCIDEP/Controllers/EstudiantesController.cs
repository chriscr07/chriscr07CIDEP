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
    public class EstudiantesController : Controller
    {
        public EstudiantesModel estudiantesModel = new EstudiantesModel();
        public UsuariosModel usuariosModel = new UsuariosModel();


        [HttpGet]
        public ActionResult Estudiantes()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;
                    estudiantesModel.Estudiantes = estudiantesModel.ListarEstudiantesConInactivos();
                    return View(estudiantesModel); 
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult VerEstudiantesUsuarios()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;
                    estudiantesModel.Estudiantes = estudiantesModel.ListarEstudiantesUsuarios().Where(e => e.ID_Usuario.HasValue).ToList();
                    return View(estudiantesModel);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult RegistrarEstudiante()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var usuarioEstudiante = usuariosModel.ListarUsuariosDisponiblesEstudiantes((int)Session["ID_Rol"]);
                    var listaUsuarios = usuarioEstudiante.Select(r => new { Value = r.ID_Usuario, Text = $"{r.Nombre_Usuario}" });

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
        public ActionResult RegistrarEstudiante(EstudianteEntity estudianteNuevo)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                estudianteNuevo.RolUsuario = (int)Session["ID_Rol"];
                estudianteNuevo.ID_UsuarioQueInserta = (int)Session["ID_Usuario"];
                var resultado = estudiantesModel.RegistrarEstudiante(estudianteNuevo);

                TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                return RedirectToAction("Estudiantes", "Estudiantes");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [HttpPost]
        public ActionResult DesactivarEstudiante(EstudianteEntity estudianteEditado)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                estudianteEditado.RolUsuario = (int)Session["ID_Rol"];
                estudianteEditado.ID_UsuarioQueElimina = (int)Session["ID_Usuario"];
                var resultado = estudiantesModel.DesactivarEstudiante(estudianteEditado);

                TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                return RedirectToAction("Estudiantes", "Estudiantes");
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpGet]
        public ActionResult EditarEstudiante(int ID_Estudiante)
        {
            if (ID_Estudiante == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                var estudiante = estudiantesModel.ListarEstudiante(ID_Estudiante);
                if (estudiante == null)
                {
                    return RedirectToAction("Estudiantes", "Estudiantes");
                }

                var usuarioEstudiante = usuariosModel.ListarUsuariosDisponiblesEstudiantes((int)Session["ID_Rol"]);
                var listaUsuarios = usuarioEstudiante.Select(r => new { Value = r.ID_Usuario, Text = $"{r.Nombre_Usuario}" });

                ViewBag.listaUsuarios = new SelectList(listaUsuarios, "Value", "Text");

                return View(estudiante);
            }
            else if ((int)Session["ID_Rol"] != 1 && Session["ID_Usuario"] != null)
            {
                return RedirectToAction("Perfil", "Perfil");
            }         
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditarEstudiante(EstudianteEntity estudianteEditado)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                estudianteEditado.RolUsuario = (int)Session["ID_Rol"];
                estudianteEditado.ID_Usuario_Accion = (int)Session["ID_Usuario"];

                var resultado = estudiantesModel.EditarEstudiante(estudianteEditado).ToString();

                TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                return RedirectToAction("Estudiantes", "Estudiantes");
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpPost]
        public ActionResult DesenlazarUsuarioEstudiante(EstudianteEntity estudianteEditado)
        {
            var resultado = estudiantesModel.DesenlazarUsuarioEstudiante(estudianteEditado).ToString();

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("VerEstudiantesUsuarios", "Estudiantes");
        }
    }
    
}