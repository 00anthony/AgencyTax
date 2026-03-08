using AgencyTax.Api.DTOs;
using AgencyTax.Api.Models;
using AgencyTax.Api.Repositories;

namespace AgencyTax.Api.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceService(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<InvoiceResponseDto>> GetAllInvoicesAsync()
        {
            var invoices = await _repository.GetAllAsync();

            return invoices.Select(i => new InvoiceResponseDto
            {
                Id = i.Id,
                ClientName = i.ClientName,
                Amount = i.Amount,
                TaxAmount = i.TaxAmount,
                TotalAmount = i.TotalAmount,
                DateIssued = i.DateIssued
            }).ToList();
        }

        public async Task<InvoiceResponseDto> CreateInvoiceAsync(CreateInvoiceDto dto)
        {
            var invoice = new Invoice
            {
                ClientName = dto.ClientName,
                Amount = dto.Amount,
                TaxRate = dto.TaxRate,
                TaxAmount = dto.Amount * dto.TaxRate,
                TotalAmount = dto.Amount + (dto.Amount * dto.TaxRate),
                DateIssued = DateTime.UtcNow
            };

            var created = await _repository.AddAsync(invoice);

            return new InvoiceResponseDto
            {
                Id = created.Id,
                ClientName = created.ClientName,
                Amount = created.Amount,
                TaxAmount = created.TaxAmount,
                TotalAmount = created.TotalAmount,
                DateIssued = created.DateIssued
            };
        }
    }
}