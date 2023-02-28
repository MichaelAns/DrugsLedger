
using Microsoft.EntityFrameworkCore.Design;

namespace DrugsLedger.Persistance.Date
{
    public class DrugsLedgerDbContextFactory : IDesignTimeDbContextFactory<DrugsLedgerDbContext>
    {
        public DrugsLedgerDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<DrugsLedgerDbContext>();
            options.UseNpgsql("Host=localhost;Port=5432;Database=DrugsLedger;Username=postgres;Password=qwertyfsy");
            return new DrugsLedgerDbContext(options.Options);
        }
    }
}
