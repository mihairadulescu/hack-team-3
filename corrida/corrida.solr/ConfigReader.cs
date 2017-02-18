using System.Configuration;

namespace corrida.solr
{
    public class ConfigReader
    {
        public static string SolrCore => ConfigurationManager.AppSettings["SolrCore"];
    }
}
