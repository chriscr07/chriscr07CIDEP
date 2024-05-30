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
    public class DocentesClasesController : Controller
    {
        DocentesClasesModel docentesClasesModel = new DocentesClasesModel();
        ClasesModel clasesModel = new ClasesModel();
        DocentesModel docentesModel = new DocentesModel();

        [HttpGet]
        public ActionResult VerDocentesClases()
        {
            if (Session["ID_Usuario"] != null)
            { 
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;
                    docentesClasesModel.DocentesClases = docentesClasesModel.ListarDocentesClases();
                    return View(docentesClasesModel);
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
        public ActionResult RegistrarDocenteClase()
        {
            if (Session["ID_Rol"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var docente = docentesModel.ListarDocentes();
                    var listaDocentes = docente.Select(r => new { Value = r.ID_Docente, Text = $"{r.Nombre} {r.PrimerApellido} {r.SegundoApellido} " });
                    ViewBag.ListaDocentes = new SelectList(listaDocentes, "Value", "Text");

                    var clase = clasesModel.ListarClases().Where(c => c.Activo == true);
                    var listaClases = clase.Select(r => new { Value = r.ID_Clase, Text = $"{r.NombreCurso} de {r.NombreGrado}" });
                    ViewBag.ListaClases = new SelectList(listaClases, "Value", "Text");

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
        public ActionResult RegistrarDocenteClase(DocenteClaseEntity docenteClase)
        {
            if (Session["ID_Rol"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var resultado = docentesClasesModel.RegistrarDocenteClase(docenteClase);
                    TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api
                    return RedirectToAction("VerDocentesClases", "DocentesClases");
                }
                else
                {
                    return RedirectToAction("Perfil", "Perfil");

                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> EliminarDocenteClase(int ID_DocenteClase)
        {
            if (Session["ID_Rol"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var resultado = await docentesClasesModel.EliminarDocenteClase(ID_DocenteClase);
                    TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api
                    return RedirectToAction("VerDocentesClases", "DocentesClases");
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
