using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Web.Http;
using API.Entity;
using System.IO;
using System.Web.Http.Cors;

namespace API.Controllers
{
    public class EmailController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("EnviarCorreoElectronico")]
        public IHttpActionResult EnviarCorreoElectronico(EmailEntity correo, string urlProyectoWeb)
        {
            try
            {
                // Cargar la plantilla HTML
                string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "PasswordReset.html");

                string plantilla = ObtenerPlantillaHtml(rutaArchivo);
                string link = $"{urlProyectoWeb}/Autenticacion/RestableceContrasenna?key=";


                string cuerpoCorreo = plantilla
                    .Replace("{token}", correo.Token)
                    .Replace("{name}", correo.NombreDestinatario)
                    .Replace("{action_url}", link);

                var mensaje = new MimeKit.MimeMessage();

                mensaje.From.Add(new MimeKit.MailboxAddress("Centro Integral de Educación Privada",
                    "cidep.notificaciones@gmail.com"));
                mensaje.To.Add(new MimeKit.MailboxAddress("", correo.Destinatario));

                mensaje.Subject = correo.Asunto;
                mensaje.Body = new MimeKit.TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = cuerpoCorreo
                };

                using (var clienteSmtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    clienteSmtp.Connect("smtp.gmail.com", 587, false);

                    clienteSmtp.Authenticate("cidep.notificaciones@gmail.com", "kgck eowj adgn xrie");

                    clienteSmtp.Send(mensaje);
                    clienteSmtp.Disconnect(true);
                }

                return Ok("Correo electrónico enviado correctamente.");
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("EnviarCorreoAusencia")]
        public IHttpActionResult EnviarCorreoAusencia(EmailEntity correo)
        {
            try
            {
                // Cargar la plantilla HTML
                string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "AbsentStudent.html"); 

                string plantilla = ObtenerPlantillaHtml(rutaArchivo);

                string cuerpoCorreo = plantilla
                    .Replace("{nombreHijo}", correo.NombreHijo)
                    .Replace("{nombrePadre}", correo.NombreDestinatario);

                var mensaje = new MimeKit.MimeMessage();

                mensaje.From.Add(new MimeKit.MailboxAddress("Centro Integral de Educación Privada",
                    "cidep.notificaciones@gmail.com"));
                mensaje.To.Add(new MimeKit.MailboxAddress("", correo.Destinatario));

                mensaje.Subject = correo.Asunto;
                mensaje.Body = new MimeKit.TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = cuerpoCorreo
                };

                using (var clienteSmtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    clienteSmtp.Connect("smtp.gmail.com", 587, false);

                    clienteSmtp.Authenticate("cidep.notificaciones@gmail.com", "kgck eowj adgn xrie");

                    clienteSmtp.Send(mensaje);
                    clienteSmtp.Disconnect(true);
                }

                return Ok("Correo electrónico enviado correctamente.");
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        private string ObtenerPlantillaHtml(string rutaArchivo)
        {
            string contenido = string.Empty;
            try
            {
                contenido = System.IO.File.ReadAllText(rutaArchivo);
            }
            catch (Exception)
            {
                throw new Exception("Error al cargar la plantilla HTML.");
            }

            return contenido;
        }

    }
}
