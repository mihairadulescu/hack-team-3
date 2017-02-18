using System;
using System.IO;
using System.Linq;
using corrida.ocr;
using corrida.solr.Models;

namespace corrida.solr.generatetests
{
    class Program
    {
        static void Main(string[] args)
        {
            string category = "Invoice";
            string categoryFolder = @"D:\hackathon\hack-team-3\corrida\corrida.solr.generatetests\testdata\Invoices";

            string[] fileEntries = Directory.GetFiles(categoryFolder);
            foreach (string filePath in fileEntries)
                Process(filePath, Path.GetFileNameWithoutExtension(filePath), category);

        }

        static void Process(string filePath, string fileName, string category)
        {
            var ocr = new TesseractOcr();
            TesseractResult result = ocr.Process(filePath);

            var document = new Document
            {
                Content = result.Pages.ToArray(),
                Title = fileName,
                Id = Guid.NewGuid(),
                Category = category
            };

            var solrProxy = new SolrProxy();
            solrProxy.Add(document);
        }
    }
}
