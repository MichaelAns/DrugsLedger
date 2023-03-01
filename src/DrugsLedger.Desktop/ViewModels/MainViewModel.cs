using DrugsLedger.Desktop.Navigation;

namespace DrugsLedger.Desktop.ViewModels
{
    class MainViewModel : ViewModel
    {
        public static Navigator Navigator { get; set; } = new Navigator(new DrugViewModel());
    }
}
