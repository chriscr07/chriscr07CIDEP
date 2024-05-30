using API.Helpers;
using API.Models;
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

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DocentesImportController : ApiController
    {
        [HttpPost]
        [Route("ImportarDocentes")]
        public async Task<IHttpActionResult> CargarDocentesDesdeCSV()
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

                    var docentes = ProcesarArchivoCSV(fileBytes);

                    int totalDocentes = docentes.Count;
                    int docentesInsertados = 0;

                    foreach (var docente in docentes)
                    {
                        if (string.IsNullOrWhiteSpace(docente.Cedula))
                        {
                            continue;
                        }

                        var cedulaExistente = db.Docentes.Any(d => d.Cedula == docente.Cedula);
                        if (cedulaExistente)
                        {
                            continue;
                        }

                        var key = $"{docente.Nombre}{docente.Cedula}";
                        if (!emails.TryGetValue(key, out var email))
                        {
                            continue;
                        }

                        var emailExistente = db.Usuarios.Any(u => u.Email == email);
                        if (emailExistente)
                        {
                            continue;
                        }

                        db.Docentes.Add(docente);
                        db.SaveChanges();
                        docentesInsertados++;

                        var usuario = CrearUsuarioParaDocente(docente, email);
                        db.Usuarios.Add(usuario);
                        db.SaveChanges();

                        docente.ID_Usuario = usuario.ID_Usuario;
                        db.Entry(docente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    db.ArchivosCSV.Remove(archivo);
                    await db.SaveChangesAsync();

                    return Ok($"Se registraron {docentesInsertados} docentes correctamente de {totalDocentes}.");
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        private List<Docentes> ProcesarArchivoCSV(byte[] fileBytes)
        {
            var docentes = new List<Docentes>();

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

                    var docente = new Docentes
                    {
                        Cedula = values[0],
                        Nombre = values[1],
                        PrimerApellido = values[2],
                        SegundoApellido = values[3],
                        FechaNacimiento = fechaNacimiento,
                        ID_Usuario = null,
                        Activo = true
                    };

                    docentes.Add(docente);
                }
            }

            return docentes;
        }

        private Dictionary<string, string> ObtenerEmailsDesdeCSV(byte[] fileBytes)
        {
            var emails = new Dictionary<string, string>();

            using (var memoryStream = new MemoryStream(fileBytes))
            using (var reader = new StreamReader(memoryStream, Encoding.GetEncoding(28591)))
            {
                reader.ReadLine(); 

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

        private Usuarios CrearUsuarioParaDocente(Docentes docente, string email)
        {
            var nombreNormalizado = StringNormalizerHelper.CharacterNormalizer(docente.Nombre.Substring(0, 2));
            var apellidoNormalizado = StringNormalizerHelper.CharacterNormalizer(docente.PrimerApellido);
            var cedulaNormalizada = StringNormalizerHelper.CharacterNormalizer(docente.Cedula.Substring(0, 5));

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
                ID_Rol = 2, //Rol de docente
                Activo = true,
                Email = email
            };

            return usuario;
        }
    }
}
