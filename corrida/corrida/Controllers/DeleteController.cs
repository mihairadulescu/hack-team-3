using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using corrida.solr;

namespace corrida.Controllers
{
    public class DeleteController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Delete(Guid guid)
        {
            SolrProxy proxy = new SolrProxy();
            proxy.Delete(guid);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }

}
