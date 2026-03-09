using Microsoft.AspNetCore.Mvc;
using AgencyTax.Api.Services;
using AgencyTax.Api.DTOs;

namespace AgencyTax.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public ReportsController(IInvoiceService service)
        {
            _service = service;
        }

        [HttpGet("monthly")]
        public async Task<ActionResult<MonthlyReportDto>> GetMonthlyReport(int year, int month)
        {
            var report = await _service.GetMonthlyReportAsync(year, month);
            return Ok(report);
        }
    }
}
