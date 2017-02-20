using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace corrida.Controllers
{
    public class DocumentController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
        public HttpResponseMessage Get()
        {
            string file = @"D:\hackathon\hack-team-3\corrida\corrida.ocr.test\Files\InvoiceStay_NY.tif";

            string fileName = "InvoiceStay_NY.tif";

            var corridaProcessor = new CorridaAwesomeProcessingStuff();
            corridaProcessor.Process(file, fileName);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            } 

            var basePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads");


            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            var provider = new MultipartFormDataStreamProvider(basePath);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var fileName = file.Headers.ContentDisposition.FileName;
                    fileName = fileName.Trim().Replace("\"", "");

                    var fullFileName = Path.Combine(basePath, fileName);
                    if (File.Exists(fullFileName))
                    {
                        File.Delete(fullFileName);
                    }
                       
                    File.Move(file.LocalFileName, fullFileName);
                      DoKinkyStuff(fullFileName, fileName);
    
                }
                return Ok();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "An error has occured");
                return BadRequest(ModelState);
            }

            return Ok();
        }

        private void DoKinkyStuff(string baseFolderPath, string file)
        {
            var corridaProcessor = new CorridaAwesomeProcessingStuff();
            corridaProcessor.Process(baseFolderPath, file); 
        }
    }
     
}
