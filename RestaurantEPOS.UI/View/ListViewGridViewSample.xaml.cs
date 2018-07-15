using System.Collections.Generic;
using System.Windows;

namespace RestaurantEPOS.UI
{
    /// <summary>
    /// Interaction logic for ListViewGridViewSample.xaml
    /// </summary>
    public partial class ListViewGridViewSample : Window
    {
        public ListViewGridViewSample()
        {
            InitializeComponent();

            List<Item> items = new List<Item>();
            items.Add(new Item() { Name = "Butter Chicken", Qty = 2, Price = 6.50F, Total = 13.00F });
            items.Add(new Item() { Name = "Garlic Nan", Qty = 3, Price = 1.50F, Total = 4.50F });
            items.Add(new Item() { Name = "Pilau Rice", Qty = 1, Price = 3.00F, Total = 3.00F });
            lvUsers.ItemsSource = items;
        }
    }
}
