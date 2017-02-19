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
    }

}
