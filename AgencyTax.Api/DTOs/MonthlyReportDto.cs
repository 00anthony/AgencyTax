namespace AgencyTax.Api.DTOs
{
    public class MonthlyReportDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int InvoiceCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalTaxCollected { get; set; }
        public decimal TotalInvoicedAmount { get; set; }
    }
}
