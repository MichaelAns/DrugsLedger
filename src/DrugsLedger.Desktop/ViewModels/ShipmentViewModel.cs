using System.Linq;

namespace DrugsLedger.Desktop.ViewModels
{
    class ShipmentViewModel : TableViewModel<Shipment>
    {
        public ShipmentViewModel()
        {
            using (var dbContext = _drugsLedgerDbContextFactory.CreateDbContext())
            {
                Items = new(dbContext.Shipment.ToList());
            }
        }
    }
}
