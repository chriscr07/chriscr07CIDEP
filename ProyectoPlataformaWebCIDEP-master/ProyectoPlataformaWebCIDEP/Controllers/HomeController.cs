using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoPlataformaWebCIDEP.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Session["ID_Usuario"] != null && Request.Cookies[FormsAuthentication.FormsCookieName] == null)
                {
                    Session.Clear();
                    Session.Abandon();
                }
                else if (Session["ID_Usuario"] == null && Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    FormsAuthentication.SignOut();
                    Session.Clear();
                    Session.Abandon();
                }
            }

            ViewBag.resultadoLogin = TempData["resultadoLogin"] as string;

            return View();
        }

    }
}