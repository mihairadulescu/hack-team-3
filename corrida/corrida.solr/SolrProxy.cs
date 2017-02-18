using System.Collections.Generic;
using corrida.solr.Models;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.Mapping.Validation;

namespace corrida.solr
{
    public class SolrProxy 
    {
        static SolrProxy()
        {
            var url = ConfigReader.SolrCore;
            Startup.Init<Document>(url);
        }

        public void Add(Document document)
        {
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Document>>();
            solr.Add(document);
            solr.Commit();
        }

        public List<Document> Search(string keyword)
        {
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Document>>();

         /*   var solrQueryOptions = new QueryOptions
            {
                Highlight = new HighlightingParameters()
                {
                    Fragsize = 300,
                    Fields = new List<string> { "content" }
                }
               
            }; */

            var result = solr.Query(new LocalParams { { "type", "dismax" }, { "qf", "title content cat" } } + new SolrQuery(keyword));
            return result;
        }

    }
}
