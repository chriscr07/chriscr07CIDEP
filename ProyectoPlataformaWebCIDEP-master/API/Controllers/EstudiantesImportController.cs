using API.Entity;
using API.Helpers;
using API.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.WebPages;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class EstudiantesImportController : ApiController
    {
        [HttpPost]
        [Route("ImportarEstudiantes")]
        public async Task<IHttpActionResult> CargarEstudiantesDesdeCSV()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest("La solicitud no es válida. Debe incluir un archivo CSV.");
            }

            try
            {
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                var file = provider.Contents.FirstOrDefault();
                if (file == null)
                {
                    return BadRequest("No se proporcionó ningún archivo CSV.");
                }

                var fileName = file.Headers.ContentDisposition.FileName.Trim('\"');

                if (!fileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest("El archivo debe tener la extensión .csv.");
                }

                var fileBytes = await file.ReadAsByteArrayAsync();

                using (var db = new CIDEPEntities())
                {
                    var archivo = new ArchivosCSV
                    {
                        NombreArchivo = fileName,
                        DatosArchivo = fileBytes,
                        FechaCreacion = DateTime.Now
                    };

                    db.ArchivosCSV.Add(archivo);
                    await db.SaveChangesAsync();

                    var emails = ObtenerEmailsDesdeCSV(fileBytes);

                    var estudiantes = ProcesarArchivoCSV(fileBytes);

                    int totalEstudiantes = estudiantes.Count;
                    int estudiantesInsertados = 0;

                    foreach (var estudiante in estudiantes)
                    {
                        if (string.IsNullOrWhiteSpace(estudiante.Cedula))
                        {
                            continue;
                        }

                        var cedulaExistente = db.Estudiantes.Any(d => d.Cedula == estudiante.Cedula);
                        if (cedulaExistente)
                        {
                            continue;
                        }

                        var key = $"{estudiante.Nombre}{estudiante.Cedula}";
                        if (!emails.TryGetValue(key, out var email))
                        {
                            continue;
                        }

                        var emailExistente = db.Usuarios.Any(u => u.Email == email);
                        if (emailExistente)
                        {
                            continue;
                        }

                        db.Estudiantes.Add(estudiante);
                        db.SaveChanges();
                        estudiantesInsertados++;

                        var usuario = CrearUsuarioParaEstudiante(estudiante, email);
                        db.Usuarios.Add(usuario);
                        db.SaveChanges();

                        estudiante.ID_Usuario = usuario.ID_Usuario;
                        db.Entry(estudiante).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    db.ArchivosCSV.Remove(archivo);
                    await db.SaveChangesAsync();

                    return Ok($"Se registraron {estudiantesInsertados} estudiantes correctamente de {totalEstudiantes}.");
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        private List<Estudiantes> ProcesarArchivoCSV(byte[] fileBytes)
        {
            var estudiantes = new List<Estudiantes>();

            using (var memoryStream = new MemoryStream(fileBytes))
            using (var reader = new StreamReader(memoryStream, Encoding.GetEncoding(28591)))
            {
                reader.ReadLine(); // Omitir la primera línea (encabezados)

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line) || line.Split(',').All(string.IsNullOrWhiteSpace))
                    {
                        continue;
                    }

                    var values = line.Split(',');

                    if (!DateTime.TryParse(values[4], out DateTime fechaNacimiento))
                    {
                        continue;
                    }

                    var estudiante = new Estudiantes
                    {
                        Cedula = values[0],
                        Nombre = values[1],
                        PrimerApellido = values[2],
                        SegundoApellido = values[3],
                        FechaNacimiento = fechaNacimiento,
                        ID_Usuario = null,
                        Activo = true
                    };

                    estudiantes.Add(estudiante);
                }
            }

            return estudiantes;
        }

        private Dictionary<string, string> ObtenerEmailsDesdeCSV(byte[] fileBytes)
        {
            var emails = new Dictionary<string, string>();

            using (var memoryStream = new MemoryStream(fileBytes))
            using (var reader = new StreamReader(memoryStream, Encoding.GetEncoding(28591)))
            {
                reader.ReadLine(); // Omitir la primera línea (encabezados)

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length < 5)
                    {
                        continue; 
                    }

                    var cedula = values[0];
                    var nombre = values[1];
                    var primerApellido = values[2];
                    var email = values[values.Length - 1];

                    var key = $"{nombre}{cedula}";

                    if (!emails.ContainsKey(key))
                    {
                        emails.Add(key, email);
                    }
                }
            }

            return emails;
        }

        private Usuarios CrearUsuarioParaEstudiante(Estudiantes estudiante, string email)
        {
            var nombreNormalizado = StringNormalizerHelper.CharacterNormalizer(estudiante.Nombre.Substring(0, 2));
            var apellidoNormalizado = StringNormalizerHelper.CharacterNormalizer(estudiante.PrimerApellido);
            var cedulaNormalizada = StringNormalizerHelper.CharacterNormalizer(estudiante.Cedula.Substring(0, 5));

            var nombreUsuario = $"{nombreNormalizado}{apellidoNormalizado}.{cedulaNormalizada}";
            nombreUsuario = nombreUsuario.ToLower();

            var random = new Random();
            var longitud = 8;
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var contrasena = new string(Enumerable.Repeat(caracteres, longitud)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var usuario = new Usuarios
            {
                Nombre_Usuario = nombreUsuario,
                ContrasennaHash = UserCreationHelper.HashPassword(contrasena),
                Salt = UserCreationHelper.GenerateSalt(),
                ID_Rol = 3, //Rol de estudiante
                Activo = true,
                Email = email
            };

            return usuario;
        }
    }
}
