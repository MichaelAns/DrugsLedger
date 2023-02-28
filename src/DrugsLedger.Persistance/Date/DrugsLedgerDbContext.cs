using DrugsLedger.Persistance.Models;

namespace DrugsLedger.Persistance.Date
{
    public class DrugsLedgerDbContext : DbContext
    {
        public DrugsLedgerDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Drug> Drug { get; set; }
        public DbSet<DrugShipment> DrugShipment { get; set; }
        public DbSet<Shipment> Shipment { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
    }
}
