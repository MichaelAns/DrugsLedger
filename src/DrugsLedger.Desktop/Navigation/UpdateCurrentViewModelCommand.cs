using DrugsLedger.Desktop.ViewModels;

namespace DrugsLedger.Desktop.Navigation
{
    internal class UpdateCurrentViewModelCommand : Command
    {
        private Navigator _navigator;

        public UpdateCurrentViewModelCommand(Navigator navigator)
        {
            _navigator = navigator;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    //таблицы
                    case ViewType.Drug:
                        _navigator.CurrentViewModel = new DrugViewModel();
                        break;
                    case ViewType.DrugShipment:
                        _navigator.CurrentViewModel = new DrugShipmentViewModel();
                        break;
                    case ViewType.Shipment:
                        _navigator.CurrentViewModel = new ShipmentViewModel();
                        break;
                    case ViewType.Warehouse:
                        _navigator.CurrentViewModel = new WarehouseViewModel();
                        break;

                    default:
                        _navigator.CurrentViewModel = new MainViewModel();
                        break;
                }
            }
            else
            {
                _navigator.CurrentViewModel = new MainViewModel();
            }
        }
    }
}
