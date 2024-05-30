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
    public class EstudiantesPadresController : Controller
    {
        EstudiantesPadresModel estudiantesPadresModel = new EstudiantesPadresModel();
        PadresModel padresModel = new PadresModel();
        EstudiantesModel estudiantesModel = new EstudiantesModel();

        [HttpGet]
        public ActionResult VerEstudiantesPadres()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    estudiantesPadresModel.EstudiantesPadres = estudiantesPadresModel.ListarEstudiantesPadres();
                    ViewBag.respuesta = TempData["respuesta"] as string;

                    return View(estudiantesPadresModel);
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
        public ActionResult RegistrarEstudiantePadre()
        {
            if (Session["ID_Rol"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var estudiante = estudiantesModel.ListarEstudiantes();
                    var listaEstudiantes = estudiante.Select(r => new { Value = r.ID_Estudiante, Text = $"{r.Nombre} {r.PrimerApellido} {r.SegundoApellido} " });
                    ViewBag.ListaEstudiantes = new SelectList(listaEstudiantes, "Value", "Text");

                    var padre = padresModel.ListarPadres();
                    var listaPadres = padre.Select(r => new { Value = r.ID_Padre, Text = $"{r.Nombre} {r.PrimerApellido} {r.SegundoApellido} " });
                    ViewBag.ListaPadres = new SelectList(listaPadres, "Value", "Text");

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
        public ActionResult RegistrarEstudiantePadre(EstudiantePadreEntity estudiantePadre)
        {
            if (Session["ID_Rol"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var resultado = estudiantesPadresModel.RegistrarEstudiantePadre(estudiantePadre);

                    TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                    return RedirectToAction("VerEstudiantesPadres", "EstudiantesPadres");
                }
                else
                {
                    return RedirectToAction("Perfil", "Perfil");

                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> EliminarEstudiantePadre(int ID_EstudiantePadre)
        {
            if (Session["ID_Rol"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var resultado = await estudiantesPadresModel.EliminarEstudiantePadre(ID_EstudiantePadre);

                    TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                    return RedirectToAction("VerEstudiantesPadres", "EstudiantesPadres");
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