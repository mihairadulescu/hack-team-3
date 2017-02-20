using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using corrida.solr;
using System.Web.Http.Cors;

namespace corrida.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
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
