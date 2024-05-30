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
    public class PadresController : Controller
    {
        public PadresModel padresModel = new PadresModel();

        [HttpGet]
        public ActionResult Padres()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;

                    padresModel.Padres = padresModel.ListarPadres();
                    return View(padresModel);
                }

                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult RegistrarPadre()
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
        public ActionResult RegistrarPadre(PadreEntity padreNuevo)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                padreNuevo.RolUsuario = (int)Session["ID_Rol"];
                padreNuevo.ID_UsuarioQueInserta = (int)Session["ID_Usuario"];
                var resultado = padresModel.RegistrarPadre(padreNuevo);

                TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                return RedirectToAction("Padres", "Padres");
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }

        }

        [HttpPost]
        public ActionResult EliminarPadre(PadreEntity padreEliminado)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                padreEliminado.RolUsuario = (int)Session["ID_Rol"];
                padreEliminado.ID_Usuario_Accion = (int)Session["ID_Usuario"];
                var resultado = padresModel.EliminarPadre(padreEliminado);

                TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

                return RedirectToAction("Padres", "Padres");
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpGet]
        public ActionResult EditarPadre(int ID_Padre)
        {
            if (ID_Padre == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var padre = padresModel.ListarPadre(ID_Padre);
                    if (padre == null)
                    {
                        return RedirectToAction("Padres", "Padres");
                    }

                    return View(padre); 
                }
                return RedirectToAction("Padres", "Padres");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditarPadre(PadreEntity padreEditado)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                padreEditado.RolUsuario = (int)Session["ID_Rol"];
                padreEditado.ID_Usuario_Accion = (int)Session["ID_Usuario"];
                var resultado = padresModel.EditarPadre(padreEditado).ToString();


                TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api


                return RedirectToAction("Padres", "Padres");


            }
            else
            {
                return RedirectToAction("Index", "Home");

            }

        }
    }
}