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
using System.Windows.Shapes;

namespace RestaurantEPOS.UI
{
    /// <summary>
    /// Interaction logic for OrderTypeWindow.xaml
    /// </summary>
    public partial class OrderTypeWindow : Window
    {
        public OrderTypeWindow()
        {
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;

            InitializeComponent();

            lblUsername.Content = "Hello Jaydeep!";

            CloseWindow.Close(typeof(IFoorItemDataService));
        }
    }
}
