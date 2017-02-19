using System;
using System.Collections.Generic;
using System.Linq;
using corrida.solr.Models;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.Impl;
using SolrNet.Mapping.Validation;

namespace corrida.solr
{
    public class SolrProxy 
    {
        static SolrProxy()
        {
            var url = ConfigReader.SolrCore;
            Startup.Init<Document>(url);
            Startup.Init<DocumentResult>(url);
        }

        public void Add(Document document)
        {
            var url = ConfigReader.SolrCore;
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Document>>();
            solr.Add(document);
            solr.Commit();
        }

        public List<DocumentResult> Search(string keyword)
        {
            var url = ConfigReader.SolrCore;
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<DocumentResult>>();

            var solrQueryOptions = GetSolrQueryOptions();

            var solrQuery = GetSolrQuery(keyword);

            var result = solr.Query(solrQuery, solrQueryOptions);

            foreach (var doc in result)
            {
                doc.Snippet=GetSnippet(result, doc);
            }
         
            return result;
        }

        private static ISolrQuery GetSolrQuery(string keyword)
        {
            string fields = "title content content_nodelimiters content_word_delimiter content_nodelimiters_nozeroes cat";
            var solrQuery = new LocalParams {{"type", "dismax"}, {"qf", fields}} + new SolrQuery(keyword);
            return solrQuery;
        }

        private static QueryOptions GetSolrQueryOptions()
        {
            var solrQueryOptions = new QueryOptions
            {
                Highlight = new HighlightingParameters()
                {
                    Fragsize = 600,
                    Fields = new List<string> {"content"},
                    AlternateField = "content"
                }
            };
            return solrQueryOptions;
        }

        private static string GetSnippet(SolrQueryResults<DocumentResult> result, DocumentResult doc)
        {
            HighlightedSnippets extractedSnippets;
            var canGetSnippet = result.Highlights.TryGetValue(doc.Id.ToString(), out extractedSnippets);
            if (canGetSnippet)
            {
                if (extractedSnippets.Snippets != null)
                {
                    var firstSnippet = extractedSnippets.Values.FirstOrDefault();
                    if (firstSnippet != null)
                    {
                        return firstSnippet.First();
                    }
                }
            }
            return String.Empty;
        }
    }
}
