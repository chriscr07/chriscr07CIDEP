using Microsoft.Ajax.Utilities;
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
    public class AsistenciaController : Controller
    {
        public AsistenciaModel asistenciaModel = new AsistenciaModel();
        public AsistenciaEntity asistencia { get; set; }

        public EstudiantesModel estudiantesModel = new EstudiantesModel();

        public ClasesModel clasesModel = new ClasesModel();

        public EstadosAsistenciaModel estadosAsistenciaModel = new EstadosAsistenciaModel();
        public GradosModel gradosModel = new GradosModel();

        public DocentesClasesModel docentesClasesModel = new DocentesClasesModel();
        public EstudiantesGradosModel estudiantesGradosModel = new EstudiantesGradosModel();

        public EmailModel emailModel = new EmailModel();

        public EstudiantesPadresModel estudiantesPadresModel = new EstudiantesPadresModel();

        public PadresModel padresModel = new PadresModel();


        [HttpGet]
        public ActionResult ElegirFiltroAsistencia()
        {
            if (Session["ID_Usuario"] != null && (int)Session["ID_Rol"]!=0)
            {
                if((int)Session["ID_Rol"] == 3)
                {
                    return RedirectToAction("Perfil","Perfil");
                }

                var asistencia = asistenciaModel.ListarEstudiantesConRegistroAsistencia();
                var listaAsistencia = asistencia.Select(a => new { Value = a.ID_Estudiante, Text = $"{a.Nombre} {a.PrimerApellido} {a.SegundoApellido}" });

                ViewBag.ListaAsistencia = new SelectList(listaAsistencia, "Value", "Text");

                var grado = gradosModel.ListarGrados();
                var listaGrados = grado.Select(a => new { Value = a.ID_Grado, Text = $"{a.NombreGrado}" });

                ViewBag.ListaGrados = new SelectList(listaGrados, "Value", "Text");

                return View();
            }
            else
            {
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

                        var estudiantesGrados = estudiantesModel.ListarEstudiantesGrados();
                        var gradosAlumno = estudiantesGrados.FirstOrDefault(g => g.ID_Estudiante == idStudentTeacher)?.NombreGrado;

                        if (gradosAlumno != null)
                        {
                            var asistenciaEstudiante = asistenciaModel.VerAsistenciaPorIdEstudiante(idStudentTeacher)
                                                                    .Where(e => e.NombreGrado.Equals(gradosAlumno));

                            var todasLasClases = clasesModel.ListarClases();

                            var idsClasesAsistencia = asistenciaEstudiante.Select(a => a.ID_Clase).Distinct();

                            var clasesFiltradas = todasLasClases.Where(c => idsClasesAsistencia.Contains(c.ID_Clase));

                            var clasesUnicas = clasesFiltradas.DistinctBy(c => c.ID_Clase);

                            clasesModel.Clases = clasesUnicas.ToList();
                        }

                        return View(clasesModel);


                    }



                }
                return RedirectToAction("Perfil", "Perfil");
            }
        }

        [HttpGet]
        public ActionResult Asistencia()
        {
            if (Session["ID_Usuario"] != null)
            {
                int? idClase = null;
                var idClaseStr = Request.QueryString["idClase"];

                DateTime fechaInicio;
                var fechaInicioStr = Request.QueryString["fechaInicio"];

                DateTime fechaFin;
                var fechaFinStr = Request.QueryString["fechaFin"];


                if (!string.IsNullOrEmpty(idClaseStr) && int.TryParse(idClaseStr, out int result))
                {
                    idClase = result;

                    if (idClase.HasValue && idClase != 0)
                    {
                        if ((int)Session["ID_Rol"] == 3) //es un estudiante
                        {

                            if (!string.IsNullOrEmpty(fechaInicioStr) && DateTime.TryParse(fechaInicioStr, out DateTime resultaa) && !string.IsNullOrEmpty(fechaFinStr) && DateTime.TryParse(fechaFinStr, out DateTime resultadd))
                            {
                                int IDEstudiante = (int)Session["IDstudentTeacher"];

                                fechaInicio = resultaa;
                                fechaFin = resultadd;

                                var asistenciaPeriodo = asistenciaModel.VerAsistenciaPorPeriodo(fechaInicio, fechaFin);

                                var asistenciaFiltrada = asistenciaPeriodo.Where(a => a.ID_Estudiante == IDEstudiante && a.ID_Clase == idClase.Value && a.Activo == true).ToList();

                                asistenciaModel.Asistencia = asistenciaFiltrada;

                                return View(asistenciaModel);

                            }
                            else
                            {
                                int IDEstudiante = (int)Session["IDstudentTeacher"];

                                var asistenciaEstudianteClase = asistenciaModel.VerAsistenciaPorIdEstudiante(IDEstudiante).Where(a => a.ID_Clase == idClase.Value && a.Activo == true).ToList();

                                asistenciaModel.Asistencia = asistenciaEstudianteClase;
                                return View(asistenciaModel);
                            }
                        }
                        else //es docente o administrador
                        {
                            if (!string.IsNullOrEmpty(fechaInicioStr) && DateTime.TryParse(fechaInicioStr, out DateTime resultaa) && !string.IsNullOrEmpty(fechaFinStr) && DateTime.TryParse(fechaFinStr, out DateTime resultadd))
                            {
                                fechaInicio = resultaa;
                                fechaFin = resultadd;

                                var asistenciaPeriodo = asistenciaModel.VerAsistenciaPorPeriodo(fechaInicio, fechaFin);

                                var asistenciaFiltrada = asistenciaPeriodo.Where(a => a.ID_Clase == idClase.Value && a.Activo == true).ToList();

                                asistenciaModel.Asistencia = asistenciaFiltrada;

                                return View(asistenciaModel);

                            }
                            else
                            {
                                var asistenciaFiltrada = asistenciaModel.VerAsistencia().Where(a => a.ID_Clase == idClase.Value && a.Activo == true).ToList();

                                asistenciaModel.Asistencia = asistenciaFiltrada;
                                return View(asistenciaModel);
                            }                          
                        }
                    } //el idClase no es válido
                    else
                    {
                        return RedirectToAction("ElegirClase", "Asistencia");
                    }
                } //no hay un parámetro de idClase en el URL
                return RedirectToAction("ElegirClase", "Asistencia");
            } //no hay un usuario almacenado en la sesión
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult ReportarEstudiantes()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] != 3)
                {
                    ViewBag.respuesta = TempData["respuesta"] as string;

                    int? idClase = null;

                    var idClaseStr = Request.QueryString["idClase"];


                    if (!string.IsNullOrEmpty(idClaseStr) && int.TryParse(idClaseStr, out int result))
                    {
                        idClase = result;
                    }       

                    if (idClase.HasValue && idClase != 0)
                    {
                        var claseElegida = clasesModel.ListarClase(idClase.Value);

                        var estudiantesGrados = estudiantesModel.ListarEstudiantesGrados();

                        var estudiantesFiltrados = estudiantesGrados.Where(e => e.ID_Grado == claseElegida.ID_Grado);

                        estudiantesModel.Estudiantes = estudiantesFiltrados.ToList();

                        var estadoAsistencia = estadosAsistenciaModel.ListarEstadosAsistencia();
                        var listaEstadosAsistencia = estadoAsistencia.Select(r => new {
                            Value = r.ID_Estado,
                            Text = $"{r.NombreEstado}"
                        });

                        ViewBag.ListaEstadosAsistencia = new SelectList(listaEstadosAsistencia, "Value", "Text");

                        return View(estudiantesModel);
                    }

                    return RedirectToAction("ElegirClase", "Asistencia");

                }
                return RedirectToAction("Perfil", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult BorrarAsistencia(AsistenciaEntity asistencia)
        {
            asistencia.RolUsuario = (int)Session["ID_Rol"];
            asistencia.ID_Usuario = (int)Session["ID_Usuario"];

            string resultadoEliminacion = asistenciaModel.BorrarAsistencia(asistencia).ToString();

            TempData["respuesta"] = resultadoEliminacion.ToString(); //guardar respuesta del api

            return RedirectToAction("Asistencia", "Asistencia");

        }

        [HttpGet]
        public ActionResult EditarAsistencia(int ID_asistencia)
        {
            if (ID_asistencia == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 3)
                {
                    return RedirectToAction("Perfil", "Perfil");
                }

                var asistencia = asistenciaModel.VerAsistenciaPorIdAsistencia(ID_asistencia);
                if (asistencia == null)
                {
                    return RedirectToAction("Asistencia", "Asistencia");
                }

                var estudiante = estudiantesModel.ListarEstudiantesGrados();
                var listaEstudiantesGrados = estudiante.Select(r => new {
                    Value = r.ID_Estudiante,
                    Text = $"{r.Nombre} {r.PrimerApellido} {r.SegundoApellido} de " +
                    $"{r.NombreGrado}"
                });

                ViewBag.ListaEstudiantesGrados = new SelectList(listaEstudiantesGrados, "Value", "Text");

                var clase = clasesModel.ListarClases();
                var listaClases = clase.Select(r => new {
                    Value = r.ID_Clase,
                    Text = $"{r.NombreCurso} de {r.NombreGrado}"
                });

                ViewBag.ListaClases = new SelectList(listaClases, "Value", "Text");

                var estadoAsistencia = estadosAsistenciaModel.ListarEstadosAsistencia();
                var listaEstadosAsistencia = estadoAsistencia.Select(r => new {
                    Value = r.ID_Estado,
                    Text = $"{r.NombreEstado}"
                });

                ViewBag.ListaEstadosAsistencia = new SelectList(listaEstadosAsistencia, "Value", "Text");

                return View(asistencia);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }          
        }

        [HttpPost]
        public ActionResult EditarAsistencia(AsistenciaEntity asistenciaEditada)
        {
            asistenciaEditada.ID_Usuario = (int)Session["ID_Usuario"];

            var resultadoEdicion = asistenciaModel.EditarAsistencia(asistenciaEditada);

            TempData["respuesta"] = resultadoEdicion.ToString(); //guardar respuesta del api

            return RedirectToAction("Asistencia", "Asistencia");
            
        }

        [HttpGet]
        public ActionResult CrearAsistencia()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 3)
                {
                    return RedirectToAction("Perfil", "Perfil");
                }

                else if ((int)Session["ID_Rol"] == 2)
                {
                    int idDocente = (int)Session["IDstudentTeacher"];

                    var docentesClases = docentesClasesModel.ListarDocentesClases();

                    docentesClases = docentesClases.Where(dc => dc.ID_Docente == idDocente).ToList();

                    if (docentesClases.Count == 0)
                    {
                        TempData["respuesta"] = "Usted no puede registrar asistencia";
                        return RedirectToAction("Asistencia", "Asistencia");
                    }

                    var gradosDocente = docentesClases.Select(dc => dc.NombreGrado).Distinct();

                    var estudiantes = estudiantesModel.ListarEstudiantesGrados();
                    var listaEstudiantes = estudiantes
                        .Where(e => gradosDocente.Contains(e.NombreGrado))
                        .Select(r => new {
                            Value = r.ID_Estudiante,
                            Text = $"{r.Nombre} {r.PrimerApellido} {r.SegundoApellido}"
                        });

                    ViewBag.ListaEstudiantes = new SelectList(listaEstudiantes, "Value", "Text");

                    var clases = clasesModel.ListarClases()
                        .Where(c => gradosDocente.Contains(c.NombreGrado));

                    var listaClases = clases.Select(r => new {
                        Value = r.ID_Clase,
                        Text = $"{r.NombreCurso} de {r.NombreGrado}"
                    });

                    ViewBag.ListaClases = new SelectList(listaClases, "Value", "Text");

                    var estadoAsistencia = estadosAsistenciaModel.ListarEstadosAsistencia();
                    var listaEstadosAsistencia = estadoAsistencia.Select(r => new {
                        Value = r.ID_Estado,
                        Text = $"{r.NombreEstado}"
                    });

                    ViewBag.ListaEstadosAsistencia = new SelectList(listaEstadosAsistencia, "Value", "Text");

                    return View();
                }


                else if ((int)Session["ID_Rol"] == 1) //ADMINISTRADOR PUEDE VER TODO
                {
                    var estudiante = estudiantesModel.ListarEstudiantesGrados();
                    var listaEstudiantes = estudiante.Select(r => new {
                        Value = r.ID_Estudiante,
                        Text = $"{r.Nombre} {r.PrimerApellido} {r.SegundoApellido}"
                    });

                    ViewBag.ListaEstudiantes = new SelectList(listaEstudiantes, "Value", "Text");

                    var clase = clasesModel.ListarClases();
                    var listaClases = clase.Select(r => new {
                        Value = r.ID_Clase,
                        Text = $"{r.NombreCurso} de {r.NombreGrado}"
                    });

                    ViewBag.ListaClases = new SelectList(listaClases, "Value", "Text");

                    var estadoAsistencia = estadosAsistenciaModel.ListarEstadosAsistencia();
                    var listaEstadosAsistencia = estadoAsistencia.Select(r => new {
                        Value = r.ID_Estado,
                        Text = $"{r.NombreEstado}"
                    });

                    ViewBag.ListaEstadosAsistencia = new SelectList(listaEstadosAsistencia, "Value", "Text");

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
        public ActionResult CrearAsistencia(AsistenciaEntity asistenciaNueva)
        {
            asistenciaNueva.ID_Usuario = (int)Session["ID_Usuario"];
            var resultado = asistenciaModel.CrearAsistencia(asistenciaNueva);

            TempData["respuesta"] = resultado.ToString(); //guardar respuesta del api

            if (resultado?.IndexOf("exitosamente", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var EstadoAsistencia = estadosAsistenciaModel.ListarEstadoAsistencia(asistenciaNueva.ID_Estado);
                if (EstadoAsistencia.NombreEstado.ToLower().Equals("ausente"))
                {
                    EmailEntity email = new EmailEntity();
                    email.Asunto = "Ausencia Injustificada";

                    var EstudianteAusente = estudiantesModel.ListarEstudiante(asistenciaNueva.ID_Estudiante);
                    email.NombreHijo = EstudianteAusente.Nombre + " " + EstudianteAusente.PrimerApellido + " " + EstudianteAusente.SegundoApellido;

                    var PadresEstudianteAusente = estudiantesPadresModel.ListarEstudiantesPadres().Where(e => e.ID_Estudiante == asistenciaNueva.ID_Estudiante);
                    if (PadresEstudianteAusente.Count() > 0)
                    {
                        try
                        {
                            foreach (var padre in PadresEstudianteAusente)
                            {
                                var padreInfo = padresModel.ListarPadre(padre.ID_Padre);
                                email.NombreDestinatario = padreInfo.Nombre;
                                email.Destinatario = padreInfo.Email;
                                emailModel.EnviarEmailEstudianteAusente(email);
                            }

                            TempData["emails"] = "Correos enviados exitosamente";
                        }
                        catch (Exception)
                        {
                            // Manejar la excepción
                            TempData["emails"] = "Error al enviar correos";
                        }


                    }

                }

                TempData["respuesta"] = resultado.ToString(); // Guardar respuesta del API

                int? id_Clase = asistenciaNueva.ID_Clase;

                if (id_Clase != 0)
                {
                    return RedirectToAction("ReportarEstudiantes", "Asistencia", new
                    {
                        idClase = id_Clase
                    });
                }
                return RedirectToAction("ElegirClase", "Asistencia");
            }

            else
            {
                return RedirectToAction("ElegirClase", "Asistencia");
            }
        }
    }
}