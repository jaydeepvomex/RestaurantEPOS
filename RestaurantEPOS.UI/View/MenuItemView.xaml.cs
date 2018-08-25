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

            //ColumnDefinition col = new ColumnDefinition();
            //col.Width = GridLength.Auto;
            //MenuItemGrid.ColumnDefinitions.Add(col);

            //var foodItemDataService = new FoodItemDataService(new RestaurantEposDbContext());

            //var foodItems = foodItemDataService.GetAll();

            //var vegStarters = foodItems.Where(x => x.CategoryId == 1);

            //foreach (var item in vegStarters)
            //{
            //    RowDefinition row = new RowDefinition();
            //    row.Height = new GridLength(2, GridUnitType.Star);
            //    MenuItemGrid.RowDefinitions.Add(row);

            //    string categoryName = item.Name;
            //    Button button = new Button();
            //    button.Name = $"btn{item.Id.ToString()}";
            //    button.FontSize = 18;
            //    button.Content = $"{item.Name} ({item.Price.ToString()})";
            //    button.SetValue(Grid.RowProperty, item.Id - 1);
            //    button.Click += Add_Item;
            //    MenuItemGrid.Children.Add(button);
            //}
        }

        private async void Add_Item(object sender, RoutedEventArgs e)
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
            else
            {
                //string buttonName = (sender as Button).Name;
                string buttonName = (sender as Button).CommandParameter.ToString();

                var bootstrapper = new Bootstrapper();
                var container = bootstrapper.Bootstrap();

                var foodItemDataService = container.Resolve<IFoodItemDataService>();
                var foodItems = await foodItemDataService.GetFoodItemAsync();
                //var vegStarters = foodItems.Where(x => x.CategoryId == 1);
                int itemId = Convert.ToInt16(buttonName);

                //int n = 0;
                //Int32.TryParse(number, out n);

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
                    //ListItems.Items.Add(new Item() { Name = item.DisplayMember, Qty = 1, Price = (float)item.Price, Total = 3.00F });
                    ListItems.Items.Add(new Item() { Name = item.DisplayMember, Qty = 1, Price = (float)3.00, Total = 3.00F });
                }

                //MessageBox.Show(buttonName);
            }
        }
    }
}
