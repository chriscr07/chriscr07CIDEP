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
    public class UsuariosController : Controller
    {
        public UsuariosModel usuariosModel = new UsuariosModel();
        public RolesModel rolesModel = new RolesModel();

        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {

                    int RolUsuario = (int)Session["ID_Rol"];
                    var role = rolesModel.ListarRoles(RolUsuario);
                    var listaRoles = role.Select(r => new { Value = r.ID_Rol, Text = $"{r.NombreRol}" });

                    ViewBag.ListaRoles = new SelectList(listaRoles, "Value", "Text");

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
        public ActionResult RegistrarUsuario(UsuarioEntity usuarioNuevo)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                usuarioNuevo.ID_Rol = (int)Session["ID_Rol"];
                usuarioNuevo.ID_Usuario = (int)Session["ID_Usuario"];
                var resultado = usuariosModel.RegistrarUsuario(usuarioNuevo);

                TempData["respuesta"] = resultado.ToString();

                return RedirectToAction("Usuarios", "Usuarios");
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }


        }

        [HttpGet]
        public ActionResult Usuarios()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;

                usuariosModel.Usuarios = usuariosModel.ListarUsuarios();
                return View(usuariosModel);
            }
            return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public ActionResult EditarUsuario(int ID_Usuario)
        {
            if (ID_Usuario == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 1)
                {
                    var usuario = usuariosModel.ListarUsuario(ID_Usuario);
                    if (usuario == null)
                    {
                        return RedirectToAction("Usuarios", "Usuarios");
                    }
                    int RolUsuario = (int)Session["ID_Rol"];
                    var role = rolesModel.ListarRoles(RolUsuario);
                    var listaRoles = role.Select(r => new { Value = r.ID_Rol, Text = $"{r.NombreRol}" });

                    ViewBag.ListaRoles = new SelectList(listaRoles, "Value", "Text");

                    return View(usuario); 
                }
                return RedirectToAction("Perfil", "Perfil");

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public ActionResult EditarUsuario(UsuarioEntity usuarioEditado)
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                usuarioEditado.RolUsuario = (int)Session["ID_Rol"];
                usuarioEditado.ID_Usuario_Accion = (int)Session["ID_Usuario"];

                var resultado = usuariosModel.EditarUsuario(usuarioEditado).ToString();

                TempData["respuesta"] = resultado.ToString();

                return RedirectToAction("Usuarios", "Usuarios");
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpPost]
        public ActionResult DesactivarUsuario(UsuarioEntity usuarioEditado)
        {

            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"] == 1)
            {
                usuarioEditado.RolUsuario = (int)Session["ID_Rol"];
                usuarioEditado.ID_UsuarioEditaUsuario = (int)Session["ID_Usuario"];
                var resultado = usuariosModel.DesactivarUsuario(usuarioEditado);

                TempData["respuesta"] = resultado.ToString();

                return RedirectToAction("Usuarios", "Usuarios");
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }



    }
}