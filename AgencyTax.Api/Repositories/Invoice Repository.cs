using AgencyTax.Api.Data;
using AgencyTax.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyTax.Api.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AgencyTaxDbContext _context;

        public InvoiceRepository(AgencyTaxDbContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetAllAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> AddAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }
    }
}