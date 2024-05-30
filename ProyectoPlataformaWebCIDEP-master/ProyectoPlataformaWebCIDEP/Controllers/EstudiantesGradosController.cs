using ProyectoPlataformaWebCIDEP.Entity;
using ProyectoPlataformaWebCIDEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPlataformaWebCIDEP.Controllers
{
    [Authorize]
    public class EstudiantesGradosController : Controller
    {
        EstudiantesGradosModel estudiantesGradosModel = new EstudiantesGradosModel();
        GradosModel gradosModel = new GradosModel();
        EstudiantesModel estudiantesModel = new EstudiantesModel();

        [HttpGet]
        public ActionResult VerEstudiantesGrados()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;

                    estudiantesGradosModel.EstudiantesGrados = estudiantesGradosModel.ListarEstudiantesGrados();
                    return View(estudiantesGradosModel);
                }
                else if (Session["ID_Rol"] != null && (int)Session["ID_Rol"] != 1)
                {
                    return RedirectToAction("Perfil", "Perfil");
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public ActionResult RegistrarEstudianteGrado()
        {
            if (Session["ID_Rol"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var estudiante = estudiantesModel.ListarEstudiantes(); 
                    var listaEstudiantes = estudiante.Select(r => new { Value = r.ID_Estudiante, Text = $"{r.Nombre} {r.PrimerApellido} {r.SegundoApellido} " });
                    ViewBag.ListaEstudiantes = new SelectList(listaEstudiantes, "Value", "Text");

                    var grado = gradosModel.ListarGrados().Where(grade => grade.Activo == true);
                    var listaGrados = grado.Select(r => new { Value = r.ID_Grado, Text = $"{r.NombreGrado} " });
                    ViewBag.ListaGrados = new SelectList(listaGrados, "Value", "Text");

                    return View();
                }
                else
                {
                    return RedirectToAction("Perfil", "Perfil");

                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult RegistrarEstudianteGrado(EstudianteGradoEntity estudianteGrado)
        {
            if (Session["ID_Rol"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var resultado = estudiantesGradosModel.RegistrarEstudianteGrado(estudianteGrado);

                    TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api


                    return RedirectToAction("VerEstudiantesGrados", "EstudiantesGrados");
                }
                else
                {
                    return RedirectToAction("Perfil", "Perfil");

                }                
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> EliminarEstudianteGrado(int ID_EstudianteGrado)
        {
            if (Session["ID_Rol"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var resultado = await estudiantesGradosModel.EliminarEstudianteGrado(ID_EstudianteGrado);
                    TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                    return RedirectToAction("VerEstudiantesGrados", "EstudiantesGrados");
                }
                else
                {
                    return RedirectToAction("Perfil", "Perfil");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}