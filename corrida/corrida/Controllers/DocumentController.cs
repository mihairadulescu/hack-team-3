using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace corrida.Controllers
{
    public class DocumentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string file = @"D:\hackathon\hack-team-3\corrida\corrida.ocr.test\Files\InvoiceStay_NY.tif";

            string fileName = "InvoiceStay_NY.tif";

            var corridaProcessor = new CorridaAwesomeProcessingStuff();
          //  corridaProcessor.Process();
            return
                Request.CreateResponse
                    (HttpStatusCode.OK);
        }
        public Task<HttpResponseMessage> Post()
        {
            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads");
            var provider = new MultipartFormDataStreamProvider(root);

            var task = request.Content.ReadAsMultipartAsync(provider).
                ContinueWith<HttpResponseMessage>(o =>
                {

                    string file1 = provider.FileData.First().LocalFileName;
                // this is the file name on the server where the file was saved 

                return new HttpResponseMessage()
                    {
                        Content = new StringContent("File uploaded.")
                    };
                }
            );
            return task;
        }
    }
     
}
