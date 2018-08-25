using Autofac;
using RestaurantEPOS.UI.Data;
using RestaurantEPOS.UI.Data;
using RestaurantEPOS.UI.Interface;
using RestaurantEPOS.UI.Startup;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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

        private async void Add_Item(object sender, RoutedEventArgs e)
        {
            string buttonName = (sender as Button).CommandParameter.ToString();

            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var foodItemDataService = container.Resolve<IFoodItemDataService>();
            var foodItems = await foodItemDataService.GetFoodItemAsync();
            int itemId = Convert.ToInt16(buttonName);

            var item = foodItems.Where(x => x.Id == itemId).SingleOrDefault();

            var isItemInCurrentList = ListItems.Items.Where(x => x.Name == item.DisplayMember).Any();

            if (isItemInCurrentList)
            {
                // increment
                if (ListItems.Items.Where(x => x.Name == item.DisplayMember).Any())
                {
                    int index = ListItems.Items.IndexOf(ListItems.Items.Where(x => x.Name == item.DisplayMember).SingleOrDefault());

                    var itemToIncrement = ListItems.Items[index];
                    ListItems.Items.Remove(itemToIncrement);
                    itemToIncrement.Qty += 1;
                    itemToIncrement.Total = itemToIncrement.Qty * itemToIncrement.Price;
                    ListItems.Items.Add(itemToIncrement);
                }
            }
            else
            {
                // add as new item
                ListItems.Items.Add(new Item() { Name = item.DisplayMember, Qty = 1, Price = (float)item.Price, Total = (float)item.Price });
            }
        }
    }
}
