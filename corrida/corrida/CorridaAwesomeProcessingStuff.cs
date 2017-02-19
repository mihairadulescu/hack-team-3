using System;
using System.IO;
using System.Web;
using corrida.ocr;
using corrida.solr;
using corrida.solr.Models;

namespace corrida
{
    public class CorridaAwesomeProcessingStuff
    {
        public void Process(string filePath, string fileName)
        {
            var rootPath = HttpContext.Current.Server.MapPath("~/");
            var tessDataPath = Path.Combine(rootPath, @"bin\tessdata");
            var ocr = new TesseractOcr();
            TesseractResult result = ocr.Process(filePath, tessDataPath);

            var document = new Document
            {
                Content = result.Pages.ToArray(),
                Title = fileName,
                Id = Guid.NewGuid(),
            };

            var solrProxy = new SolrProxy();
            solrProxy.Add(document);
        }
    }
}