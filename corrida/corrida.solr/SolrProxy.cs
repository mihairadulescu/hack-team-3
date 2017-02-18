using System.Collections.Generic;
using corrida.solr.Models;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;

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

            var solrQueryOptions = new QueryOptions
            {
                Rows = 10000,
                Start = 0
            };

            var result = solr.Query(SolrQuery.All, solrQueryOptions);
            return result;
        }

    }
}
