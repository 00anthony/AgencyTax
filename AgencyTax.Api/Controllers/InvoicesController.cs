using Microsoft.AspNetCore.Mvc;
using AgencyTax.Api.Services;
using AgencyTax.Api.DTOs;

namespace AgencyTax.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoicesController(IInvoiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceResponseDto>>> GetInvoices()
        {
            var invoices = await _service.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceResponseDto>> CreateInvoice(CreateInvoiceDto dto)
        {
            var result = await _service.CreateInvoiceAsync(dto);
            return Ok(result);
        }
    }
}