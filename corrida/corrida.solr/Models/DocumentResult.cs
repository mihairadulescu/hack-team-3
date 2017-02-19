using System;
using SolrNet.Attributes;

namespace corrida.solr.Models
{
    public class DocumentResult
    {
        [SolrField("ID")]
        public Guid Id { get; set; }

        [SolrField("title")]
        public string Title { get; set; }

        public string Snippet { get; set; }

        [SolrField("cat")]
        public string Category { get; set; }
    }
}
