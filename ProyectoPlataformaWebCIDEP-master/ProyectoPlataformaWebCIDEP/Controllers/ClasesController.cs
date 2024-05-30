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
    public class ClasesController : Controller
    {
        public ClasesModel clasesModel = new ClasesModel();
        public CursosModel cursosModel = new CursosModel();
        public GradosModel gradosModel = new GradosModel();


        [HttpGet]
        public ActionResult Clases()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;

                    clasesModel.Clases = clasesModel.ListarClases();
                    return View(clasesModel);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult RegistrarClase()
        {
            if (Session["ID_Usuario"] != null) {
                if ((int)Session["ID_Rol"] == 1)
                {
                    
                    var curso = cursosModel.ListarCursos();
                    var listaCursos = curso.Select(r => new { Value = r.ID_Curso, Text = $"{r.NombreCurso}" });
                    ViewBag.ListaCursos = new SelectList(listaCursos, "Value", "Text");

                    var grado = gradosModel.ListarGrados();
                    var listaGrados = grado.Select(r => new { Value = r.ID_Grado, Text = $"{r.NombreGrado}" });
                    ViewBag.ListaGrados = new SelectList(listaGrados, "Value", "Text");

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
        public ActionResult RegistrarClase(ClaseEntity claseNueva)
        {
            claseNueva.RolUsuario = (int)Session["ID_Rol"];
            claseNueva.ID_Usuario = (int)Session["ID_Usuario"];
            var resultado = clasesModel.RegistrarClase(claseNueva);


            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Clases", "Clases");
            
        }

        [HttpGet]
        public ActionResult EditarClase(int ID_Clase)
        {
            if (ID_Clase == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            

            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var clase = clasesModel.ListarClase(ID_Clase);
                    if (clase == null)
                    {
                        return RedirectToAction("Clases", "Clases");
                    }

                    var curso = cursosModel.ListarCursos();
                    var listaCursos = curso.Select(r => new { Value = r.ID_Curso, Text = $"{r.NombreCurso}" });
                    ViewBag.ListaCursos = new SelectList(listaCursos, "Value", "Text");

                    var grado = gradosModel.ListarGrados();
                    var listaGrados = grado.Select(r => new { Value = r.ID_Grado, Text = $"{r.NombreGrado}" });
                    ViewBag.ListaGrados = new SelectList(listaGrados, "Value", "Text");

                    return View(clase);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public ActionResult EditarClase(ClaseEntity claseEditada)
        {
            claseEditada.RolUsuario = (int)Session["ID_Rol"];
            claseEditada.ID_Usuario = (int)Session["ID_Usuario"];
            var resultado = clasesModel.EditarClase(claseEditada);


            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Clases", "Clases");
        }

        [HttpPost]
        public ActionResult DesactivarClase(ClaseEntity claseDesactivada)
        {
            claseDesactivada.RolUsuario = (int)Session["ID_Rol"];
            claseDesactivada.ID_Usuario = (int)Session["ID_Usuario"];
            var resultado = clasesModel.DesactivarClase(claseDesactivada);


            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Clases", "Clases");
        }
    }
}