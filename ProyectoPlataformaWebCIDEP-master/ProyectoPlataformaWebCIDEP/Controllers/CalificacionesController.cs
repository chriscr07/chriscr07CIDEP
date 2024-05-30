using ProyectoPlataformaWebCIDEP.Entity;
using ProyectoPlataformaWebCIDEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoPlataformaWebCIDEP.Controllers
{
    [Authorize]
    public class CalificacionesController : Controller
    {
        public CalificacionesModel calificacionesModel = new CalificacionesModel();
        public CalificacionEntity calificacion {  get; set; }
        public EstudiantesModel estudiantesModel = new EstudiantesModel();
        public ClasesModel clasesModel = new ClasesModel();
        public EvaluacionesModel evaluacionesModel = new EvaluacionesModel();
        public DocentesClasesModel docentesClasesModel = new DocentesClasesModel();


        [HttpGet]
        public ActionResult Calificaciones()
        {
            int? idClase = null;

            var idClaseStr = Request.QueryString["idClase"];  


            if (!string.IsNullOrEmpty(idClaseStr) && int.TryParse(idClaseStr, out int result))
            {
                idClase = result;
            }
           
            if (Session["ID_Usuario"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var evaluaciones = evaluacionesModel.ListarEvaluaciones();
                var listaTiposEvaluaciones = evaluaciones.Select(r => new {
                    Value = r.ID_TipoEvaluacion,
                    Text = $"{r.Descripcion}"
                });

                ViewBag.ListaTiposEvaluaciones = new SelectList(listaTiposEvaluaciones, "Value", "Text");

                if ((int)Session["ID_Rol"] == 3)
                {
                    if (idClase.HasValue && idClase != 0) 
                    {
                        var claseElegida = clasesModel.ListarClase(idClase.Value);

                        if (claseElegida != null)
                        {
                            string combinacionClase = $"{claseElegida.NombreCurso} {claseElegida.NombreGrado}";

                            var calificacionesEstudiante = calificacionesModel.ListarCalificacionesPorIdEstudiante((int)Session["IDstudentTeacher"]);

                            var calificacionesFiltradas = calificacionesEstudiante.Where(c =>
                                c.NombreCurso == claseElegida.NombreCurso &&
                                c.NombreGrado == claseElegida.NombreGrado
                            ).ToList();

                            calificacionesModel.Calificaciones = calificacionesFiltradas;
                            return View(calificacionesModel);
                        }
                        else
                        {
                            return RedirectToAction("Perfil", "Perfil");
                        }
                    }
                    return RedirectToAction("Perfil", "Perfil");

                }
                else if ((int)Session["ID_Rol"] == 2)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;

                    if (idClase.HasValue && idClase != 0)
                    {
                        var claseElegida = clasesModel.ListarClase(idClase.Value);

                        if (claseElegida != null)
                        {
                            string combinacionClase = $"{claseElegida.NombreCurso} {claseElegida.NombreGrado}";

                            var calificacionesClase = calificacionesModel.ListarCalificaciones();

                            var calificacionesFiltradas = calificacionesClase.Where(c =>
                                c.NombreCurso == claseElegida.NombreCurso &&
                                c.NombreGrado == claseElegida.NombreGrado
                            ).ToList();

                            calificacionesModel.Calificaciones = calificacionesFiltradas;
                            return View(calificacionesModel);
                        }
                        else
                        {
                            return RedirectToAction("Perfil", "Perfil");
                        }
                    }
                    return RedirectToAction("Perfil", "Perfil");

                }
                else if ((int)Session["ID_Rol"] == 1)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;

                    if (idClase.HasValue && idClase != 0)
                    {
                        var claseElegida = clasesModel.ListarClase(idClase.Value);

                        if (claseElegida != null)
                        {
                            string combinacionClase = $"{claseElegida.NombreCurso} {claseElegida.NombreGrado}";

                            var calificacionesClase = calificacionesModel.ListarCalificaciones();

                            var calificacionesFiltradas = calificacionesClase.Where(c =>
                                c.NombreCurso == claseElegida.NombreCurso &&
                                c.NombreGrado == claseElegida.NombreGrado
                            ).ToList();

                            calificacionesModel.Calificaciones = calificacionesFiltradas;
                            return View(calificacionesModel);
                        }
                        else
                        {
                            return RedirectToAction("ElegirClase", "Calificaciones");
                        }
                    }
                    return RedirectToAction("ElegirClase", "Calificaciones");
                }
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult ElegirClase()
        {
            if (Session["ID_Usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if ((int)Session["ID_Usuario"] != 0)
                {
                    
                    if ((int)Session["ID_Rol"] == 1)
                    {
                        ViewBag.respuesta = TempData["respuesta"] as string;

                        clasesModel.Clases = clasesModel.ListarClases();
                        return View(clasesModel);
                    }
                    else if ((int)Session["ID_Rol"] == 2)
                    {
                        ViewBag.respuesta = TempData["respuesta"] as string;

                        int idStudentTeacher = (int)Session["IDstudentTeacher"];

                        var docentesClases = docentesClasesModel.ListarDocenteClases(idStudentTeacher);

                        var todasLasClases = clasesModel.ListarClases();

                        var clasesFiltradas = todasLasClases.Where(clase => docentesClases.Any(dc => dc.ID_Clase == clase.ID_Clase));

                        clasesModel.Clases = clasesFiltradas.ToList();

                        return View(clasesModel);
                    }
                    else if ((int)Session["ID_Rol"] == 3)
                    {
                        int idStudentTeacher = (int)Session["IDstudentTeacher"];

                        var estudiante = estudiantesModel.ListarEstudiante(idStudentTeacher);
                        string nombreCompleto = $"{estudiante.Nombre} {estudiante.PrimerApellido} {estudiante.SegundoApellido}";

                        var estudiantesGrados = estudiantesModel.ListarEstudiantesGrados();
                        var gradosAlumno = estudiantesGrados.FirstOrDefault(g => g.ID_Estudiante == idStudentTeacher)?.NombreGrado;

                        if (gradosAlumno != null)
                        {
                            var calificacionesEstudiante = calificacionesModel.ListarCalificaciones()
                                .Where(c => c.Estudiante == nombreCompleto && c.NombreGrado == gradosAlumno);

                            var combinacionesUnicas = calificacionesEstudiante.Select(c => $"{c.NombreCurso} {c.NombreGrado}").Distinct();

                            var todasLasClases = clasesModel.ListarClases();

                            var clasesFiltradas = todasLasClases.Where(clase =>
                                combinacionesUnicas.Contains($"{clase.NombreCurso} {clase.NombreGrado}")
                            );

                            clasesModel.Clases = clasesFiltradas.ToList();

                            return View(clasesModel);
                        }
                        else
                        {
                            return RedirectToAction("Perfil", "Perfil");
                        }
                    }




                }
                return RedirectToAction("Perfil", "Perfil");
            }            
        }

        [HttpGet]
        public ActionResult ElegirTipoEvaluacion()
        {

            if (Session["ID_Usuario"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if ((int)Session["ID_Usuario"] != 0)
                {

                    if ((int)Session["ID_Rol"] == 1 || (int)Session["ID_Rol"] == 2)
                    {
                        evaluacionesModel.Evaluaciones = evaluacionesModel.ListarEvaluaciones();
                        return View(evaluacionesModel);
                    }
                    return RedirectToAction("Perfil", "Perfil");
                }
                return RedirectToAction("Perfil", "Perfil");
            }
        }

        [HttpGet]
        public ActionResult CalificarEstudiantes()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] != 3)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;

                    int? idClase = null; 
                    int? idEvaluacion = null;

                    var idClaseStr = Request.QueryString["idClase"];
                    var idEvaluacionStr = Request.QueryString["idEvaluacion"];


                    if (!string.IsNullOrEmpty(idClaseStr) && int.TryParse(idClaseStr, out int result))
                    {
                        idClase = result;
                    }

                    if (!string.IsNullOrEmpty(idEvaluacionStr) && int.TryParse(idEvaluacionStr, out int resultado))
                    {
                        idEvaluacion = resultado; 
                    }

                    if (idClase.HasValue && idClase != 0 && idEvaluacion.HasValue && idEvaluacion != 0)
                    {
                        var claseElegida = clasesModel.ListarClase(idClase.Value);

                        var estudiantesGrados = estudiantesModel.ListarEstudiantesGrados();

                        var estudiantesFiltrados = estudiantesGrados.Where(e => e.ID_Grado == claseElegida.ID_Grado);

                        estudiantesModel.Estudiantes = estudiantesFiltrados.ToList();

                        return View(estudiantesModel);
                    }

                    return RedirectToAction("Perfil", "Perfil");

                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult EliminarCalificacion(CalificacionEntity calificacion) //revisar notificaciones!!!
        {

            calificacion.ID_Usuario = (int)Session["ID_Usuario"];

            string resultadoEliminacion = calificacionesModel.EliminarCalificacion(calificacion).ToString();

            TempData["respuesta"] = resultadoEliminacion.ToString(); //guardar respuesta del api

            return RedirectToAction("Calificaciones", "Calificaciones");               

        }

        [HttpGet]
        public ActionResult EditarCalificacion(int ID_calificacion)
        {
            if (ID_calificacion == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Rol"] != null)
            {
                if ((int)Session["ID_Rol"] == 3)
                {
                    return RedirectToAction("Perfil", "Perfil");
                }

                var calificacion = calificacionesModel.VerCalificacionPorIdCalificacion(ID_calificacion);
                if (calificacion == null)
                {
                    return RedirectToAction("Calificaciones", "Calificaciones");
                }

                var estudiante = estudiantesModel.ListarEstudiantesGrados();
                var listaEstudiantesGrados = estudiante.Select(r => new {
                    Value = r.ID_Estudiante,
                    Text = $"{r.Nombre} {r.PrimerApellido} {r.SegundoApellido}"
                });

                ViewBag.ListaEstudiantesGrados = new SelectList(listaEstudiantesGrados, "Value", "Text");

                var clase = clasesModel.ListarClases();
                var listaClases = clase.Select(r => new {
                    Value = r.ID_Clase,
                    Text = $"{r.NombreCurso} de {r.NombreGrado}"
                });

                ViewBag.ListaClases = new SelectList(listaClases, "Value", "Text");

                var evaluacion = evaluacionesModel.ListarEvaluaciones();
                var listaEvaluaciones = evaluacion.Select(r => new {
                    Value = r.ID_TipoEvaluacion,
                    Text = $"{r.Descripcion}"
                });

                ViewBag.ListaEvaluaciones = new SelectList(listaEvaluaciones, "Value", "Text");

                return View(calificacion);
            }

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult EditarCalificacion(CalificacionEntity calificacionEditada)
        {
            calificacionEditada.ID_Usuario = (int)Session["ID_Usuario"];
            var resultadoEdicion = calificacionesModel.EditarCalificacion(calificacionEditada);

            TempData["respuesta"] = resultadoEdicion.ToString(); //guardar respuesta del api

            return RedirectToAction("Calificaciones", "Calificaciones");
        }

        [HttpGet]
        public ActionResult AgregarCalificacion()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 3)
                {
                    return RedirectToAction("Perfil", "Perfil");
                }

                else if ((int)Session["ID_Rol"] == 2) //CASO PARA DOCENTES 
                {
                    int idDocente = (int)Session["IDstudentTeacher"];

                    var docentesClases = docentesClasesModel.ListarDocentesClases();

                    docentesClases = docentesClases.Where(dc => dc.ID_Docente == idDocente).ToList();

                    if (docentesClases.Count == 0)
                    {
                        TempData["respuesta"] = "Usted no puede registrar calificaciones";
                        return RedirectToAction("Calificaciones", "Calificaciones");
                    }

                    var gradosDocente = docentesClases.Select(dc => dc.NombreGrado).Distinct();

                    var estudiantes = estudiantesModel.ListarEstudiantesGrados();
                    var listaEstudiantes = estudiantes
                        .Where(e => gradosDocente.Contains(e.NombreGrado))
                        .Select(r => new {
                            Value = r.ID_Estudiante,
                            Text = $"{r.Nombre} {r.PrimerApellido} {r.SegundoApellido}"
                        });

                    ViewBag.ListaEstudiantes = new SelectList(listaEstudiantes, "Value", "Text"); //lista de estudiantes asociados a ese grado

                    var clases = clasesModel.ListarClases()
                        .Where(c => gradosDocente.Contains(c.NombreGrado));

                    var listaClases = clases.Select(r => new {
                        Value = r.ID_Clase,
                        Text = $"{r.NombreCurso} de {r.NombreGrado}"
                    });

                    ViewBag.ListaClases = new SelectList(listaClases, "Value", "Text"); //lista de clases asociadas a ese grado 

                    var evaluacion = evaluacionesModel.ListarEvaluaciones();
                    var listaEvaluaciones = evaluacion.Select(r => new {
                        Value = r.ID_TipoEvaluacion,
                        Text = $"{r.Descripcion}"
                    });

                    ViewBag.ListaEvaluaciones = new SelectList(listaEvaluaciones, "Value", "Text");

                    return View();
                }


                else if ((int)Session["ID_Rol"] == 1) //ADMINISTRADOR PUEDE VER TODO
                {
                    var estudiante = estudiantesModel.ListarEstudiantesGrados(); //lista estudiantes con grados asociados

                    var listaEstudiantes = estudiante.Select(r => new { Value = r.ID_Estudiante, Text = $"{r.Nombre} {r.PrimerApellido} {r.SegundoApellido} " });

                    ViewBag.ListaEstudiantes = new SelectList(listaEstudiantes, "Value", "Text");

                    var clase = clasesModel.ListarClases();
                    var listaClases = clase.Select(r => new {
                        Value = r.ID_Clase,
                        Text = $"{r.NombreCurso} de {r.NombreGrado}"
                    });

                    ViewBag.ListaClases = new SelectList(listaClases, "Value", "Text");

                    var evaluacion = evaluacionesModel.ListarEvaluaciones();
                    var listaEvaluaciones = evaluacion.Select(r => new {
                        Value = r.ID_TipoEvaluacion,
                        Text = $"{r.Descripcion}"
                    });

                    ViewBag.ListaEvaluaciones = new SelectList(listaEvaluaciones, "Value", "Text");

                    return View();
                }
                else
                {

                    return RedirectToAction("Perfil", "Perfil");
                }

            }
            else
            {

                return RedirectToAction("Index", "Home");
            }        
        }

        [HttpPost]
        public ActionResult AgregarCalificacion(CalificacionEntity calificacionNueva)
        {
            calificacionNueva.ID_Usuario = (int)Session["ID_Usuario"];

            var resultado = calificacionesModel.AgregarCalificacion(calificacionNueva);

            TempData["respuesta"] = resultado.ToString(); // Guardar respuesta del API

            int? id_Clase = calificacionNueva.ID_Clase;
            int? id_Evaluacion = calificacionNueva.ID_TipoEvaluacion;

            if (id_Clase != 0 && id_Evaluacion != 0)
            {
                return RedirectToAction("CalificarEstudiantes", "Calificaciones", new
                {
                    idClase = id_Clase,
                    idEvaluacion = id_Evaluacion

                });
            }
            return RedirectToAction("ElegirClase", "Calificaciones");
        }

    }
}