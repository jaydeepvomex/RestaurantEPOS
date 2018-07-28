using RestaurantEPOS.BusinessLayer;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantEPOS.UI.View
{
    /// <summary>
    /// Interaction logic for LogoutView.xaml
    /// </summary>
    public partial class LogoutView : UserControl
    {
        public LogoutView()
        {
            InitializeComponent();
        }

        private void btnLogoutClicked(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            CloseWindow(typeof(MainWindow));
        }

        void CloseWindow(System.Type type)
        {
            var window = App.Current.Windows.OfType<Window>().FirstOrDefault(w => w.GetType() == type);
            if (window != null)
                window.Close();
        }

        private void btnPayClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"You are paying for {Order.OrderType.ToString()}");
        }
    }
}
