using System.ComponentModel.DataAnnotations;

namespace AgencyTax.Api.DTOs
{
    public class CreateInvoiceDto
    {
        [Required]
        [MaxLength(100)]
        public required string ClientName { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Range(0, 1, ErrorMessage = "TaxRate must be between 0 and 1.")]
        public decimal TaxRate { get; set; }
    }
}
