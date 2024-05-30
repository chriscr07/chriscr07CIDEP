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
    public class EvaluacionesController : Controller
    {
        public EvaluacionesModel evaluacionesModel = new EvaluacionesModel();

        [HttpGet]
        public ActionResult Evaluaciones()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;

                    evaluacionesModel.Evaluaciones = evaluacionesModel.ListarEvaluaciones();
                    return View(evaluacionesModel);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult RegistrarEvaluacion()
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
        public ActionResult RegistrarEvaluacion(EvaluacionEntity evaluacionNueva)
        {
            evaluacionNueva.RolUsuario = (int)Session["ID_Rol"];
            var resultado = evaluacionesModel.RegistrarEvaluacion(evaluacionNueva);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Evaluaciones", "Evaluaciones");
            
        }


        [HttpGet]
        public ActionResult EditarEvaluacion(int ID_TipoEvaluacion)
        {
            if (ID_TipoEvaluacion == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var evaluacion = evaluacionesModel.ListarEvaluacion(ID_TipoEvaluacion);

                    if (evaluacion == null)
                    {
                        return RedirectToAction("Evaluaciones", "Evaluaciones");
                    }
                    return View(evaluacion);
                }

                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditarEvaluacion(EvaluacionEntity evaluacionEditada)
        {
            evaluacionEditada.RolUsuario = (int)Session["ID_Rol"];
            var resultado = evaluacionesModel.EditarEvaluacion(evaluacionEditada);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Evaluaciones", "Evaluaciones");
            
        }

        [HttpPost]
        public ActionResult DesactivarEvaluacion(EvaluacionEntity evaluacionDesactivada)
        {
            evaluacionDesactivada.RolUsuario = (int)Session["ID_Rol"];
            var resultado = evaluacionesModel.DesactivarEvaluacion(evaluacionDesactivada);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Evaluaciones", "Evaluaciones");
           
        }
    }
}