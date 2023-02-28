using System.Linq;

namespace DrugsLedger.Desktop.ViewModels
{
    class WarehouseViewModel : TableViewModel<Warehouse>
    {
        public WarehouseViewModel()
        {
            using (var dbContext = _drugsLedgerDbContextFactory.CreateDbContext())
            {
                Items = new(dbContext.Warehouse.ToList());
            }
        }
    }
}
