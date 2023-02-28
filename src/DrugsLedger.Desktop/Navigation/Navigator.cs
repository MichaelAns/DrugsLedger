using SimpleMvvm.Navigators;
using System.Windows.Input;

namespace DrugsLedger.Desktop.Navigation
{
    internal class Navigator : ViewModel, INavigator
    {
        private ViewModel _currentViewModel;

        public Navigator() { }
        public Navigator(ViewModel currentViewModel)
        {
            _currentViewModel = currentViewModel;
        }

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);   
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}
