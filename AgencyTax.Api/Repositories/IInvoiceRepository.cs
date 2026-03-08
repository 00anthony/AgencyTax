using AgencyTax.Api.Models;
namespace AgencyTax.Api.Repositories
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllAsync();
        Task<Invoice> AddAsync(Invoice invoice);
    }
}
