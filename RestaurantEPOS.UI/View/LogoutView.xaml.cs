using RestaurantEPOS.BusinessLayer;
using RestaurantEPOS.UI.Helpers;
using System.Globalization;
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
            CloseWindow.Close(typeof(MainWindow));
        }

        private void btnPayClick(object sender, RoutedEventArgs e)
        {
            float total = 0.0f;

            foreach (var item in ListItems.Items)
            {
                total += item.Total;
            }

            MessageBox.Show($"You are paying for {Order.OrderType.ToString()}: total is {total.ToString("C", new CultureInfo("en-GB"))}");
        }

        private void btnShowOrderSelectionWindow(object sender, RoutedEventArgs e)
        {
            OrderTypeWindow orderSelectionWindows = new OrderTypeWindow();
            orderSelectionWindows.Show();
            CloseWindow.Close(typeof(MainWindow));
        }
    }
}
