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
    public class GradosController : Controller
    {
        public GradosModel gradosModel = new GradosModel();

        [HttpGet]
        public ActionResult Grados()
        {          
            if (Session["ID_Usuario"] != null) 
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;

                    gradosModel.Grados = gradosModel.ListarGrados();
                    return View(gradosModel);
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult RegistrarGrado()
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
        public ActionResult RegistrarGrado(GradoEntity gradoNuevo)
        {
            gradoNuevo.RolUsuario = (int)Session["ID_Rol"];
            var resultado = gradosModel.RegistrarGrado(gradoNuevo);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("RegistrarGrado", "Grados");
            
        }

        [HttpGet]
        public ActionResult EditarGrado(int ID_Grado)
        {
            if (ID_Grado == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var grado = gradosModel.ListarGrado(ID_Grado);

                    if (grado == null)
                    {
                        return RedirectToAction("Grados", "Grados");
                    }
                    return View(grado);
                }
                return RedirectToAction("Perfil", "Perfil");

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditarGrado(GradoEntity gradoEditado)
        {
            gradoEditado.RolUsuario = (int)Session["ID_Rol"];
            var resultado = gradosModel.EditarGrado(gradoEditado);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Grados", "Grados");
            
        }

        [HttpPost]
        public ActionResult DesactivarGrado(GradoEntity gradoDesactivado)
        {
            gradoDesactivado.RolUsuario = (int)Session["ID_Rol"];
            var resultado = gradosModel.DesactivarGrado(gradoDesactivado);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Grados", "Grados");
            
        }
    }
}