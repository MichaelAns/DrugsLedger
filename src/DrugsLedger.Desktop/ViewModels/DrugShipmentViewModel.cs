using System.Configuration;
using System.Linq;

namespace DrugsLedger.Desktop.ViewModels
{
    class DrugShipmentViewModel : TableViewModel<DrugShipment>
    {
        public DrugShipmentViewModel()
        {
            using (var dbContext = _drugsLedgerDbContextFactory.CreateDbContext())
            {
                Items = new(dbContext.DrugShipment.ToList());
            }
        }
    }
}
