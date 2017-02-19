﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using corrida.solr;
using CsvHelper.Configuration;

namespace corrida.Controllers
{
    public class AssistentController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get()
        {
            var payments = GetPayments();
            CheckPayments(payments);
            var invalidPayments = GetInvalidPayments(payments);
            return Ok(invalidPayments);
        }

        private List<Payment> GetInvalidPayments(List<Payment> payments)
        {
            return payments.Where(x => !x.IsMatched).ToList();
        }

        private void CheckPayments(List<Payment> payments)
        {
            var solrProxy = new SolrProxy();
            foreach (var payment in payments)
            { 
                var response = solrProxy.Search(payment.Debit);
                if (response.Count > 0) payment.IsMatched = true;
            }
        }

        private List<Payment> GetPayments()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Tranzactii_pe_perioada.csv");
            var csv = new CsvReader(new StreamReader(File.OpenRead(path)));
            csv.Configuration.RegisterClassMap<PaymentMap>();
            var records = csv.GetRecords<Payment>();
            return records.ToList();
        }
    }

    public class Payment
    {
        public string Data { get; set; }
        public string Detalii { get; set; }

        public bool IsMatched { get; set; }

        public string Debit { get; set; }

    }

    public sealed class PaymentMap : CsvClassMap<Payment>
    {
        public PaymentMap()
        {
            Map(m => m.Data).Name("Data");
            Map(m => m.Detalii).Name("Detalii");
            Map(m => m.Debit).Name("Debit");
        }
    }
}
