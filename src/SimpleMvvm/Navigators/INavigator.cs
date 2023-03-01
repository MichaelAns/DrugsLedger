using System.Windows.Input;

namespace SimpleMvvm.Navigators
{
    public interface INavigator
    {
        public ViewModel CurrentViewModel { get; set; }
        //public ICommand UpdateCurrentViewModelCommand { get; }
    }
}
