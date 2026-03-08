using Microsoft.AspNetCore.Mvc;
using AgencyTax.Api.Models;
using AgencyTax.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace AgencyTax.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly AgencyTaxDbContext _context;

        public InvoicesController(AgencyTaxDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Invoice>>> GetInvoices()
        {
            return await _context.Invoices.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice)
        {
            invoice.TaxAmount = invoice.Amount * invoice.TaxRate;
            invoice.TotalAmount = invoice.Amount + invoice.TaxAmount;
            invoice.DateIssued = DateTime.UtcNow;

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return Ok(invoice);
        }
    }
}