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
    public class CursosController : Controller
    {
        public CursosModel cursosModel = new CursosModel();

        [HttpGet]
        public ActionResult Cursos()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;
                    cursosModel.Cursos = cursosModel.ListarCursos();
                    return View(cursosModel);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult RegistrarCurso()
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
        public ActionResult RegistrarCurso(CursoEntity cursoNuevo)
        {
            cursoNuevo.RolUsuario = (int)Session["ID_Rol"];
            cursoNuevo.ID_Usuario = (int)Session["ID_Usuario"];
            var resultado = cursosModel.RegistrarCurso(cursoNuevo);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Cursos", "Cursos");
            
        }

        [HttpGet]
        public ActionResult EditarCurso(int ID_Curso)
        {
            if (ID_Curso == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var curso = cursosModel.ListarCurso(ID_Curso);

                    if (curso == null)
                    {
                        return RedirectToAction("Cursos", "Cursos");
                    }

                    return View(curso);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }

        [HttpPost]
        public ActionResult EditarCurso(CursoEntity cursoEditado)
        {
            cursoEditado.RolUsuario = (int)Session["ID_Rol"];
            var resultado = cursosModel.EditarCurso(cursoEditado);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Cursos", "Cursos");
        }

        [HttpPost]
        public ActionResult DesactivarCurso(CursoEntity cursoDesactivado)
        {
            cursoDesactivado.RolUsuario = (int)Session["ID_Rol"];
            var resultado = cursosModel.DesactivarCurso(cursoDesactivado);
            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Cursos", "Cursos");
        }
    }
}