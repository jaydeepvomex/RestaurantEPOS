using Autofac;
using RestaurantEPOS.UI.Startup;
using System.Windows;

namespace RestaurantEPOS.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var loginWindow = container.Resolve<LoginWindow>();
            loginWindow.Show();
        }
    }
}
