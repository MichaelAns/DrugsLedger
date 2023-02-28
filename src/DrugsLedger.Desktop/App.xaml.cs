using DrugsLedger.Desktop.Windows;
using System.Windows;

namespace DrugsLedger.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {            
            Window window = new MainWindow();
            //window.DataContext = new OpenViewModel();
            window.Show();
            base.OnStartup(e);
        }
    }

}
