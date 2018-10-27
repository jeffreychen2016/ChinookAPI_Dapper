using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAPI_Dapper.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string ClientFullName { get; set; }
        public string SalesAgentFullName { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public decimal? Total { get; set; }
        public int CustomerId { get; set; }
    }
}
