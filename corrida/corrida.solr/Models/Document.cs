using System;
using SolrNet.Attributes;

namespace corrida.solr.Models
{
    public class Document
    {
        [SolrField("ID")]
        public Guid Id { get; set; }

        [SolrField("title")]
        public string Title { get; set; }

        [SolrField("content")]
        public string[] Content { get; set; }

        [SolrField("cat")]
        public string Category { get; set; }
    }
}
