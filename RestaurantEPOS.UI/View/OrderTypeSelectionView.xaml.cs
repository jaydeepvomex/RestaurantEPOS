using Autofac;
using RestaurantEPOS.BusinessLayer;
using RestaurantEPOS.UI.Startup;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantEPOS.UI.View
{
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
