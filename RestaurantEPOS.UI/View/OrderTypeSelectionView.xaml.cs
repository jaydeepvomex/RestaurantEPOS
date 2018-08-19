using Autofac;
using RestaurantEPOS.BusinessLayer;
using RestaurantEPOS.UI.Data;
using RestaurantEPOS.UI.Repository;
using RestaurantEPOS.UI.Startup;
using RestaurantEPOS.UI.ViewModel;
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
    /// Interaction logic for OrderTypeSelection.xaml
    /// </summary>
    public partial class OrderTypeSelection : UserControl
    {
        public OrderTypeSelection()
        {
            InitializeComponent();
        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            string orderType = (sender as Button).Name;

            SetOrderServiceType(orderType);

            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
            CloseWindow(typeof(OrderTypeWindow));
        }

        public void SetOrderServiceType(string orderType)
        {
            if (orderType == "btnTableService")
                Order.OrderType = OrderType.TableService;
            else if (orderType == "btnTakeawayService")
                Order.OrderType = OrderType.Takeaway;
            else if (orderType == "btnDeliveryService")
                Order.OrderType = OrderType.Delivery;
            else
                Order.OrderType = OrderType.TableService;
        }

        void CloseWindow(System.Type type)
        {
            var window = App.Current.Windows.OfType<Window>().FirstOrDefault(w => w.GetType() == type);
            if (window != null)
                window.Close();
        }
    }
}
