﻿using System;
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
        [Route("api/search/{keywords}")]
        [HttpGet]
        public HttpResponseMessage Search(string keywords)
        {
            var solrProxy = new SolrProxy();
            var response = solrProxy.Search(keywords);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
