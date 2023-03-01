using DrugsLedger.Desktop.MVVM;
using DrugsLedger.Desktop.ViewModels;

namespace DrugsLedger.Desktop.Navigation
{
    internal class Navigator : ViewModel
    {
        private ViewModel _currentViewModel;

        public Navigator() { }
        public Navigator(ViewModel currentViewModel)
        {
            _currentViewModel = currentViewModel;
            UpdateCurrentViewModelCommand = new RelayCommand(UpdateCurrentViewModelExecute, (obj) => true);
        }

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        public Command UpdateCurrentViewModelCommand { get; }

        private void UpdateCurrentViewModelExecute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    //таблицы
                    case ViewType.Drug:
                        CurrentViewModel = new DrugViewModel();
                        break;
                    case ViewType.DrugShipment:
                        CurrentViewModel = new DrugShipmentViewModel();
                        break;
                    case ViewType.Shipment:
                        CurrentViewModel = new ShipmentViewModel();
                        break;
                    case ViewType.Warehouse:
                        CurrentViewModel = new WarehouseViewModel();
                        break;

                    default:
                        CurrentViewModel = new MainViewModel();
                        break;
                }
            }
            else
            {
                CurrentViewModel = new MainViewModel();
            }
        }


    }
}
