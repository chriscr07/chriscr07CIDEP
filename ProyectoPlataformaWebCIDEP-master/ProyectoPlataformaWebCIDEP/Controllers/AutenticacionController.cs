using Microsoft.Ajax.Utilities;
using ProyectoPlataformaWebCIDEP.Entity;
using ProyectoPlataformaWebCIDEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoPlataformaWebCIDEP.Controllers
{
    public class AutenticacionController : Controller
    {
        public AutenticacionModel autenticacionModel = new AutenticacionModel();

        [HttpPost]
        public ActionResult IniciarSesion(UsuarioEntity usuarioLogin)
        {
            var resultado = autenticacionModel.IniciarSesion(usuarioLogin);

            if (resultado.Nombre_Usuario != null)
            {
                FormsAuthentication.SetAuthCookie(usuarioLogin.Nombre_Usuario, false);
                Session["Nombre_Usuario"] = resultado.Nombre_Usuario;
                Session["Activo"] = resultado.Activo;
                Session["ID_Rol"] = resultado.ID_Rol;
                Session["ID_Usuario"] = resultado.ID_Usuario;
                Session["NombreRol"] = resultado.NombreRol;


                var datosUsuario = autenticacionModel.BuscarInformacionUsuario(resultado.ID_Usuario);
                if (datosUsuario != null)
                {
                    Session["Nombre"] = datosUsuario.Nombre;
                    Session["PrimerApellido"] = datosUsuario.PrimerApellido;
                    Session["SegundoApellido"] = datosUsuario.SegundoApellido;
                    Session["IDstudentTeacher"] = datosUsuario.IDstudentteacher;
                    return RedirectToAction("Perfil", "Perfil");
                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                TempData["resultadoLogin"] = "Credenciales incorrectos"; //guardar respuesta del api

                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult RestablecerContrasenna()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RestableceContrasenna(string key)
        {
            if (key.IsNullOrWhiteSpace())
            {
                return RedirectToAction("RestablecerContrasenna", "Autenticacion");
            }

            return View();
        }

        [HttpGet]
        public ActionResult CambiarContrasenna()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CambiarContrasenna(UsuarioEntity usuario)
        {
            usuario.ID_Usuario = (int)Session["ID_Usuario"];
            var respuesta = autenticacionModel.CambiarContrasenna(usuario);

            TempData["respuesta"] = respuesta.ToString();

            return RedirectToAction("Perfil", "Perfil");
        }

    }
}