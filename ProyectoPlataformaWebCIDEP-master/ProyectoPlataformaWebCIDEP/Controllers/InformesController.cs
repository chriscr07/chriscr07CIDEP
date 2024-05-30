
using ProyectoPlataformaWebCIDEP.Models;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ProyectoPlataformaWebCIDEP.Controllers
{
    public class InformesController : Controller
    {

        public InformesModel informesModel = new InformesModel();
        public PerfilModel perfilModel = new PerfilModel();
        public CalificacionesModel calificacionesModel = new CalificacionesModel();
        public AsistenciaModel asistenciaModel = new AsistenciaModel();


        [HttpGet]
        public ActionResult Informes()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] != 3)
                {
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

        [HttpGet]
        public ActionResult InformeAsistencia()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] != 3)
                {
                    var asistenciaE = asistenciaModel.ListarEstudiantesConRegistroAsistencia();
                    var listaAsistenciaE = asistenciaE.Select(a => new { Value = a.ID_Estudiante, Text = $"{a.Nombre} {a.PrimerApellido} {a.SegundoApellido}" });
                    ViewBag.ListaEstudiantesAsistencia = new SelectList(listaAsistenciaE, "Value", "Text");

                    var asistenciaG = asistenciaModel.ObtenerGradosConAsistencia();
                    var listaAsistenciaG = asistenciaG.Select(a => new { Value = a.ID_Grado, Text = $"{a.NombreGrado}" });
                    ViewBag.ListaGradosAsistencia = new SelectList(listaAsistenciaG, "Value", "Text");

                    var asistencia = asistenciaModel.ObtenerClasesConAsistencia();
                    var listaAsistenciaC = asistencia.Select(a => new { Value = a.ID_Clase, Text = $"{a.NombreCurso} {a.NombreGrado}" });
                    ViewBag.ListaClasesAsistencia = new SelectList(listaAsistenciaC, "Value", "Text");

                    return View();
                }
                else
                {
                    return RedirectToAction("Perfil", "Perfil"); //validar funcionamiento
                }

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult InformeCalificaciones()
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] != 3)
                {
                    var calificaciones = calificacionesModel.ListarEstudiantesConRegistroCalificaciones();
                    var listaCalificaciones = calificaciones.Select(a => new { Value = a.ID_Estudiante, Text = $"{a.Nombre} {a.PrimerApellido} {a.SegundoApellido}" });

                    ViewBag.ListaCalificaciones = new SelectList(listaCalificaciones, "Value", "Text");
                    return View();
                }
                else
                {
                    return RedirectToAction("Perfil", "Perfil"); //validar funcionamiento

                }

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public ActionResult GenerarCSVCalificaciones(int idEstudiante, DateTime fechaInicio, DateTime fechaFin)
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 3)
                {
                    return RedirectToAction("Perfil", "Perfil");
                }

                int rolUsuario = (int)Session["ID_Rol"];

                if (fechaInicio > fechaFin)
                {
                    DateTime temp = fechaInicio;
                    fechaInicio = fechaFin;
                    fechaFin = temp;
                }
                fechaInicio = fechaInicio.AddDays(-1);

                var datos = informesModel.ObtenerCalificacionesEstudiantePorFechas(rolUsuario, idEstudiante, fechaInicio, fechaFin);

                StringBuilder csv = new StringBuilder();

                csv.AppendLine("Nombre,Primer Apellido,Segundo Apellido,Curso,Grado,Fecha,Evaluacion,Calificacion,Porcentaje Total,Porcentaje Obtenido, Retroalimentacion");

                foreach (var dato in datos)
                {
                    string curso = dato.NombreCurso.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string evaluacion = dato.Descripcion.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string nombre = dato.Nombre.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string primerApellido = dato.PrimerApellido.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n"); ;
                    string segundoApellido = dato.SegundoApellido.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string retroalimentacion = dato.Retroalimentacion.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string grado = dato.NombreGrado.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string fechaCalificacion = dato.FechaCalificacion.ToString("dd / MM / yyyy", new System.Globalization.CultureInfo("es-MX"));

                    csv.AppendLine($"{nombre},{primerApellido},{segundoApellido},{curso},{grado},{fechaCalificacion},{evaluacion},{dato.Calificacion}," +
                        $"{dato.PorcentajeTotal},{dato.PorcentajeObtenido},{retroalimentacion}");
                }

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=informe.csv");
                Response.Charset = "";
                Response.ContentType = "text/csv; charset=utf-8";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Output.Write(csv.ToString());
                Response.Flush();
                Response.End();

                return RedirectToAction("Informes", "Informes");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GenerarCSVAsistenciaEstudiante(int idEstudiante, DateTime fechaInicio, DateTime fechaFin)
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 3)
                {
                    return RedirectToAction("Perfil", "Perfil");
                }
                int rolUsuario = (int)Session["ID_Rol"];

                if (fechaInicio > fechaFin)
                {
                    DateTime temp = fechaInicio;
                    fechaInicio = fechaFin;
                    fechaFin = temp;
                }
                fechaInicio = fechaInicio.AddDays(-1);

                var datos = informesModel.ObtenerAsistenciaEstudiantePorFechas(rolUsuario, idEstudiante, fechaInicio, fechaFin);

                StringBuilder csv = new StringBuilder();

                csv.AppendLine("Nombre,Primer Apellido,Segundo Apellido,Curso,Grado,Fecha,Estado");

                foreach (var dato in datos)
                {
                    string curso = dato.NombreCurso.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string estado = dato.NombreEstado.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string nombre = dato.Nombre.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string primerApellido = dato.PrimerApellido.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n"); ;
                    string segundoApellido = dato.SegundoApellido.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string grado = dato.NombreGrado.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string fechaAsistencia = dato.Fecha_Asistencia.ToString("dd / MM / yyyy", new System.Globalization.CultureInfo("es-MX"));

                    csv.AppendLine($"{nombre},{primerApellido},{segundoApellido},{curso},{grado},{fechaAsistencia},{estado}");
                }

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=informe.csv");
                Response.Charset = "";
                Response.ContentType = "text/csv; charset=utf-8";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Output.Write(csv.ToString());
                Response.Flush();
                Response.End();

                return RedirectToAction("Informes", "Informes");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GenerarCSVAsistenciaClase(int idClase, DateTime fechaInicio, DateTime fechaFin)
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 3)
                {
                    return RedirectToAction("Perfil", "Perfil");
                }
                int rolUsuario = (int)Session["ID_Rol"];

                if (fechaInicio > fechaFin)
                {
                    DateTime temp = fechaInicio;
                    fechaInicio = fechaFin;
                    fechaFin = temp;
                }
                fechaInicio = fechaInicio.AddDays(-1);

                var datos = informesModel.ObtenerAsistenciaClasePorFechas(rolUsuario, idClase, fechaInicio, fechaFin);

                StringBuilder csv = new StringBuilder();

                csv.AppendLine("Nombre,Primer Apellido,Segundo Apellido,Curso,Grado,Fecha,Estado");

                foreach (var dato in datos)
                {
                    string curso = dato.NombreCurso.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string estado = dato.NombreEstado.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string nombre = dato.Nombre.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string primerApellido = dato.PrimerApellido.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n"); ;
                    string segundoApellido = dato.SegundoApellido.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string grado = dato.NombreGrado.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string fechaAsistencia = dato.Fecha_Asistencia.ToString("dd / MM / yyyy", new System.Globalization.CultureInfo("es-MX"));

                    csv.AppendLine($"{nombre},{primerApellido},{segundoApellido},{curso},{grado},{fechaAsistencia},{estado}");
                }

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=informe.csv");
                Response.Charset = "";
                Response.ContentType = "text/csv; charset=utf-8";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Output.Write(csv.ToString());
                Response.Flush();
                Response.End();

                return RedirectToAction("Informes", "Informes");
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public ActionResult GenerarCSVAsistenciaGrado(int idGrado, DateTime fechaInicio, DateTime fechaFin)
        {
            if (Session["ID_Usuario"] != null)
            {
                if ((int)Session["ID_Rol"] == 3)
                {
                    return RedirectToAction("Perfil", "Perfil");
                }
                int rolUsuario = (int)Session["ID_Rol"];

                if (fechaInicio > fechaFin)
                {
                    DateTime temp = fechaInicio;
                    fechaInicio = fechaFin;
                    fechaFin = temp;
                }
                fechaInicio = fechaInicio.AddDays(-1);

                var datos = informesModel.ObtenerAsistenciaGradoPorFechas(rolUsuario, idGrado, fechaInicio, fechaFin);

                StringBuilder csv = new StringBuilder();

                csv.AppendLine("Nombre,Primer Apellido,Segundo Apellido,Curso,Grado,Fecha,Estado");

                foreach (var dato in datos)
                {
                    string curso = dato.NombreCurso.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string estado = dato.NombreEstado.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string nombre = dato.Nombre.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string primerApellido = dato.PrimerApellido.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n"); ;
                    string segundoApellido = dato.SegundoApellido.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string grado = dato.NombreGrado.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
                    string fechaAsistencia = dato.Fecha_Asistencia.ToString("dd / MM / yyyy", new System.Globalization.CultureInfo("es-MX"));

                    csv.AppendLine($"{nombre},{primerApellido},{segundoApellido},{curso},{grado},{fechaAsistencia},{estado}");
                }

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=informe.csv");
                Response.Charset = "";
                Response.ContentType = "text/csv; charset=utf-8";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Output.Write(csv.ToString());
                Response.Flush();
                Response.End();

                return RedirectToAction("Informes", "Informes");
            }
            return RedirectToAction("Index", "Home");

        }



    }
}