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

    public class PadresImportController : ApiController
    {
        [HttpPost]
        [Route("ImportarPadres")]
        public async Task<IHttpActionResult> CargarPadresDesdeCSV()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest("La solicitud no es válida. Debe incluir un archivo CSV.");
            }

            int totalPadres = 0;
            int padresInsertados = 0;

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

                    var padres = ProcesarArchivoCSV(fileBytes);

                    totalPadres = padres.Count;

                    foreach (var padre in padres)
                    {
                        var padreExistente = db.Padres.Any(p =>
                            p.Nombre == padre.Nombre &&
                            p.PrimerApellido == padre.PrimerApellido &&
                            p.SegundoApellido == padre.SegundoApellido);

                        if (!padreExistente)
                        {
                            db.Padres.Add(padre);
                            db.SaveChanges();
                            padresInsertados++;
                        }
                    }

                    await db.SaveChangesAsync();

                    db.ArchivosCSV.Remove(archivo);
                    await db.SaveChangesAsync();
                }

                return Ok($"Se registraron {padresInsertados} padres correctamente de {totalPadres}.");
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        private List<Padres> ProcesarArchivoCSV(byte[] fileBytes)
        {
            var padres = new List<Padres>();

            using (var memoryStream = new MemoryStream(fileBytes))
            using (var reader = new StreamReader(memoryStream, Encoding.GetEncoding(28591)))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line) || line.Split(',').All(string.IsNullOrWhiteSpace))
                    {
                        continue;
                    }

                    var values = line.Split(',');

                    var padre = new Padres
                    {
                        Nombre = values[0],
                        PrimerApellido = values[1],
                        SegundoApellido = values[2],
                        Email = values[3],
                        Numero = values[4]
                    };

                    padres.Add(padre);
                }
            }

            return padres;
        }


    }
}