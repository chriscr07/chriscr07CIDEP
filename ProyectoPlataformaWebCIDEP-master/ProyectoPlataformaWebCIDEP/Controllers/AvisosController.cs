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
    public class AvisosController : Controller
    {
        public AvisosModel avisosModel = new AvisosModel();
        public AvisoGeneralEntity avisogeneral { get; set; }

        [HttpGet]
        public ActionResult Avisos()
        {
            if (Session["ID_Usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
       
            if ((int)Session["ID_Rol"] == 1)
            {
                ViewBag.respuesta = TempData["respuesta"] as string;
            }

            avisosModel.AvisoGeneral = avisosModel.ListarAvisosGenerales();
            return View(avisosModel);
        }

        [HttpGet]
        public ActionResult CrearAvisoGeneral()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    return View();
                }

                return RedirectToAction("Perfil", "Perfil");

            }

            return RedirectToAction("Index", "Home");


        }

        [HttpPost]
        public ActionResult CrearAvisoGeneral(AvisoGeneralEntity avisogeneralNuevo)
        {
            avisogeneralNuevo.ID_Usuario = (int)Session["ID_Usuario"];

            var resultado = avisosModel.CrearAvisoGeneral(avisogeneralNuevo);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api
    
            return RedirectToAction("Avisos", "Avisos");
       
        }

        [HttpPost]
        public ActionResult BorrarAvisoGeneral(AvisoGeneralEntity avisoEliminado) 
        {
            avisoEliminado.RolUsuario = (int)Session["ID_Rol"];
            avisoEliminado.ID_Usuario = (int)Session["ID_Usuario"];

            string resultadoEliminacion = avisosModel.BorrarAvisoGeneral(avisoEliminado).ToString();

            TempData["respuesta"] = resultadoEliminacion.ToString(); //guardar respuesta del api

            return RedirectToAction("Avisos", "Avisos");

        }

        [HttpGet]
        public ActionResult EditarAvisoGeneral(int ID_AvisoGeneral)
        {
            if (ID_AvisoGeneral == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var aviso = avisosModel.ListarAvisoGeneral(ID_AvisoGeneral);
                    if (aviso == null)
                    {
                        return RedirectToAction("Avisos", "Avisos");
                    }
                    return View(aviso);

                }
                return RedirectToAction("Perfil", "Perfil");
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult EditarAvisoGeneral(AvisoGeneralEntity avisoGeneralEditado)
        {
            avisoGeneralEditado.ID_Usuario = (int)Session["ID_Usuario"];

            var resultado = avisosModel.EditarAvisoGeneral(avisoGeneralEditado);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            return RedirectToAction("Avisos", "Avisos");
        }

    }
}