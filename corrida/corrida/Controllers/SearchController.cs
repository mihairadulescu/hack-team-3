using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using corrida.solr;

namespace corrida.Controllers
{
    public class SearchController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var solrProxy = new SolrProxy();
            var response = solrProxy.Search("Watermarque");

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
