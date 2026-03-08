using Microsoft.EntityFrameworkCore;
using AgencyTax.Api.Models;

namespace AgencyTax.Api.Data
{
    public class AgencyTaxDbContext : DbContext
    {
        public AgencyTaxDbContext(DbContextOptions<AgencyTaxDbContext> options)
            : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
    }
}