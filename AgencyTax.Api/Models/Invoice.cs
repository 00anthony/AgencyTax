using System;

namespace AgencyTax.Api.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateIssued { get; set; }
    }
}