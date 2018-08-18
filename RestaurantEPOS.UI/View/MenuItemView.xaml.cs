using RestaurantEPOS.UI.Data;
using RestaurantEPOS.UI.Repository;
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

            ColumnDefinition col = new ColumnDefinition();
            col.Width = GridLength.Auto;
            MenuItemGrid.ColumnDefinitions.Add(col);

            var foodItemDataService = new FoodItemDataService(new RestaurantEposDbContext());

            var foodItems = foodItemDataService.GetAll();

            var vegStarters = foodItems.Where(x => x.CategoryId == 1);

            foreach (var item in vegStarters)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(2, GridUnitType.Star);
                MenuItemGrid.RowDefinitions.Add(row);

                string categoryName = item.Name;
                Button button = new Button();
                button.Name = $"btn{item.Id.ToString()}";
                button.FontSize = 18;
                button.Content = $"{item.Name} ({item.Price.ToString()})";
                button.SetValue(Grid.RowProperty, item.Id - 1);
                button.Click += Add_Item;
                MenuItemGrid.Children.Add(button);
            }
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
            else
            {
                string buttonName = (sender as Button).Name;
                var foodItemDataService = new FoodItemDataService(new RestaurantEposDbContext());
                var foodItems = foodItemDataService.GetAll();
                var vegStarters = foodItems.Where(x => x.CategoryId == 1);

                var number = buttonName.Split('n')[1];

                int n = 0;
                Int32.TryParse(number, out n);

                var item = vegStarters.Where(x => x.Id == n).SingleOrDefault();

                ListItems.Items.Add(new Item() { Name = item.Name, Qty = 1, Price = (float)item.Price, Total = 3.00F });

                //MessageBox.Show(buttonName);
            }
        }
    }
}
