using AgencyTax.Api.DTOs;

namespace AgencyTax.Api.Services
{
    public interface IInvoiceService
    {
        Task<List<InvoiceResponseDto>> GetAllInvoicesAsync();
        Task<InvoiceResponseDto> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto);
    }
}
