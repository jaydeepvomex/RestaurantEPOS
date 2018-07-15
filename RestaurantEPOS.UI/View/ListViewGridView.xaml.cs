using System.Collections.Generic;
using System.Windows.Controls;

namespace RestaurantEPOS.UI.View
{
    /// <summary>
    /// Interaction logic for ListViewGridView.xaml
    /// </summary>
    public partial class ListViewGridView : UserControl
    {
        //public List<Item> items = new List<Item>();
        public ListItems listItems = new ListItems();
        
        public ListViewGridView()
        {
            InitializeComponent();
            
            ListItems.Items.Add(new Item() { Name = "Butter Chicken", Qty = 2, Price = 6.50F, Total = 13.00F });
            ListItems.Items.Add(new Item() { Name = "Garlic Nan", Qty = 3, Price = 1.50F, Total = 4.50F });
            ListItems.Items.Add(new Item() { Name = "Pilau Rice", Qty = 1, Price = 3.00F, Total = 3.00F });

            ListViewOfItems.ItemsSource = ListItems.Items;
        }
    }
}
