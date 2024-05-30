using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPlataformaWebCIDEP.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }
    }
}