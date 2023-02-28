using DrugsLedger.Desktop.Navigation;
using SimpleMvvm.Navigators;

namespace DrugsLedger.Desktop.ViewModels
{
    class MainViewModel : ViewModel
    {
        public INavigator Navigator { get; set; } = new Navigator();
    }
}
