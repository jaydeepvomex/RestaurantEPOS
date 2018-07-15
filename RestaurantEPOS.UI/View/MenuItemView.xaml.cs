using System.Windows;
using System.Windows.Controls;

namespace RestaurantEPOS.UI.View
{
    /// <summary>
    /// Interaction logic for MenuItemView.xaml
    /// </summary>
    public partial class MenuItemView : UserControl
    {
        public MenuItemView()
        {
            InitializeComponent();
        }

        private void Add_Item(object sender, RoutedEventArgs e)
        {
            if (((System.Windows.Controls.ContentControl)e.Source).Content.ToString() == "Butter Chicken")
            {
                ListItems.Items.Add(new Item() { Name = "Butter Chicken", Qty = 2, Price = 6.50F, Total = 13.00F });
            }
            else if (((System.Windows.Controls.ContentControl)e.Source).Content.ToString() == "Garlic Nan")
            {
                ListItems.Items.Add(new Item() { Name = "Garlic Nan", Qty = 3, Price = 1.50F, Total = 4.50F });
            }
            else if (((System.Windows.Controls.ContentControl)e.Source).Content.ToString() == "Pilau Rice")
            {
                ListItems.Items.Add(new Item() { Name = "Pilau Rice", Qty = 1, Price = 3.00F, Total = 3.00F });
            }
        }
    }
}
