
using ProyectoPlataformaWebCIDEP.Models;
using System.Web.Mvc;

namespace ProyectoPlataformaWebCIDEP.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        PerfilModel perfilModel = new PerfilModel();

        [HttpGet]
        public ActionResult Perfil()
        {
            int ID_Usuario = (int)Session["ID_Usuario"];
            int ID_Rol = (int)Session["ID_Rol"];

            if(ID_Rol == 1)
            {
                perfilModel.perfil = perfilModel.ListarPerfilAdministrador(ID_Usuario);
                ViewBag.respuesta = TempData["respuesta"] as string;
                return View(perfilModel);
            }
            else if(ID_Rol == 2)
            {
                perfilModel.perfil = perfilModel.ListarPerfilDocente(ID_Usuario);
                ViewBag.respuesta = TempData["respuesta"] as string;
                return View(perfilModel);
            }
            else if(ID_Rol == 3)
            {
                perfilModel.perfil = perfilModel.ListarPerfilEstudiante(ID_Usuario);
                ViewBag.respuesta = TempData["respuesta"] as string;
                return View(perfilModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }

    }
}