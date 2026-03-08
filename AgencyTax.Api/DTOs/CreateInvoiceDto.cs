namespace AgencyTax.Api.DTOs
{
    public class CreateInvoiceDto
    {
        public string ClientName { get;set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal TaxRate { get; set; }
    }
}
