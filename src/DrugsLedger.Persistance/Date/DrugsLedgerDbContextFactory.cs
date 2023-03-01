using System.Text.Json;
using Microsoft.EntityFrameworkCore.Design;
using DrugsLedger.Persistance.Date.ConnectionString;

namespace DrugsLedger.Persistance.Date
{
    public class DrugsLedgerDbContextFactory : IDesignTimeDbContextFactory<DrugsLedgerDbContext>
    {
        public DrugsLedgerDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<DrugsLedgerDbContext>();
            //options.UseNpgsql("Host=localhost;Port=5432;Database=DrugsLedger;Username=postgres;Password=qwertyfsy");
            string cs = GetConnectionStringFromFile();
            options.UseNpgsql(cs);
            return new DrugsLedgerDbContext(options.Options);
        }

        private string GetConnectionStringFromFile()
        {
            string path = @"Resources\ConnectionString.json";
            DrugsLedger.Persistance.Date.ConnectionString.
                ConnectionString? connection = JsonSerializer.Deserialize<DrugsLedger.Persistance.Date.ConnectionString.
                ConnectionString>(File.ReadAllText(path));
            return $"Host={connection.Host};Port={connection.Port};Database={connection.Database};Username={connection.Username};Password={connection.Password}";
        }
    }
}
