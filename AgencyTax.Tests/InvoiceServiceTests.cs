using Xunit;
using Moq;
using AgencyTax.Api.Services;
using AgencyTax.Api.Repositories;
using AgencyTax.Api.DTOs;
using AgencyTax.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace AgencyTax.Tests
{
    public class InvoiceServiceTests
    {
        private readonly Mock<IInvoiceRepository> _mockRepo;
        private readonly InvoiceService _service;

        public InvoiceServiceTests()
        {
            _mockRepo = new Mock<IInvoiceRepository>();
            _service = new InvoiceService(_mockRepo.Object);
        }

        [Fact]
        public async Task CreateInvoiceAsync_ShouldCalculateTaxAndTotalCorrectly()
        {
            // Arrange
            var dto = new CreateInvoiceDto
            {
                ClientName = "Test Client",
                Amount = 1000,
                TaxRate = 0.1m
            };

            _mockRepo.Setup(r => r.AddAsync(It.IsAny<Invoice>()))
                     .ReturnsAsync((Invoice inv) => inv);

            // Act
            var result = await _service.CreateInvoiceAsync(dto);

            // Assert
            Assert.Equal(100m, result.TaxAmount);
            Assert.Equal(1100m, result.TotalAmount);
        }

        [Fact]
        public async Task GetMonthlyReportAsync_ShouldReturnCorrectTotals()
        {
            // Arrange
            var invoices = new List<Invoice>
            {
                new Invoice { Amount = 100, TaxAmount = 10, TotalAmount = 110, DateIssued = DateTime.UtcNow },
                new Invoice { Amount = 200, TaxAmount = 20, TotalAmount = 220, DateIssued = DateTime.UtcNow }
            };

            _mockRepo.Setup(r => r.GetByMonthAsync(It.IsAny<int>(), It.IsAny<int>()))
                     .ReturnsAsync(invoices);

            // Act
            var report = await _service.GetMonthlyReportAsync(2026, 3);

            // Assert
            Assert.Equal(2, report.InvoiceCount);
            Assert.Equal(300, report.TotalRevenue);
            Assert.Equal(30, report.TotalTaxCollected);
            Assert.Equal(330, report.TotalInvoicedAmount);
        }

        [Fact]
        public async Task CreateInvoiceAsync_ShouldThrowException_WhenTaxRateTooHigh()
        {
            var dto = new CreateInvoiceDto
            {
                ClientName = "Test",
                Amount = 100,
                TaxRate = 0.5m
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.CreateInvoiceAsync(dto));
        }
    }
}