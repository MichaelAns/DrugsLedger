using System.Linq;

namespace DrugsLedger.Desktop.ViewModels
{
    class DrugViewModel : TableViewModel<Drug>
    {
        public DrugViewModel()
        {
            using (var dbContext = _drugsLedgerDbContextFactory.CreateDbContext())
            {
                Items = new(dbContext.Drug.ToList());
            }
        }
    }
}
