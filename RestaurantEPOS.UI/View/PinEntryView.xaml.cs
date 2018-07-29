using RestaurantEPOS.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantEPOS.UI.View
{
    /// <summary>
    /// Interaction logic for PinEntryView.xaml
    /// </summary>
    public partial class PinEntryView : UserControl
    {
        public PinEntryView()
        {
            InitializeComponent();
        }

        private void btnClockIn(object sender, RoutedEventArgs e)
        {
            OrderTypeWindow window = new OrderTypeWindow();
            window.Show();
            CloseWindow.Close(typeof(LoginWindow));
            ClearPinEntry();
        }

        private void HandlePinEntryButtonClick(object sender, RoutedEventArgs e)
        {
            string buttonText = (sender as Button).Content.ToString();

            txtInputPin.Password += buttonText;
        }

        private void ClearPinEntryPasswordBox(object sender, RoutedEventArgs e)
        {
            ClearPinEntry();
        }

        private void ClearPinEntry()
        {
            txtInputPin.Password = string.Empty;
        }
    }
}
