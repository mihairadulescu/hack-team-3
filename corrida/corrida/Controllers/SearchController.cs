using System.Web.Http;
using corrida.solr;
using System.Web.Http.Cors;

namespace corrida.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
        public IHttpActionResult Get(string keywords)
        {
            var solrProxy = new SolrProxy();
            var response = solrProxy.Search(keywords);
            return  Ok(response);
        }
    }
}
