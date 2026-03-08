using System;

namespace AgencyTax.Api.DTOs
{
    public class InvoiceResponseDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateIssued { get; set; }
    }
}