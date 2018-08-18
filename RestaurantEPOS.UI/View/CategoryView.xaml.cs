using Prism.Events;
using RestaurantEPOS.UI.Event;
using RestaurantEPOS.UI.Interface;
using RestaurantEPOS.UI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {
        public CategoryView()
        {
            InitializeComponent();

            ColumnDefinition columnDefinition = new ColumnDefinition();
            columnDefinition.Width = GridLength.Auto;
            CategoryGridView.ColumnDefinitions.Add(columnDefinition);

            // get categories
            var categoriesRepo = new CategoryRepository(new UI.RestaurantEposDbContext());

            var categories = categoriesRepo.GetItems();

            foreach (var item in categories)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                CategoryGridView.RowDefinitions.Add(row);

                string categoryName = item.CategoryName;
                Button button = new Button();
                button.Name = $"btn{categoryName.Replace(" ", "").ToUpper()+item.Id.ToString()}";
                button.Content = item.CategoryName;
                button.SetValue(Grid.RowProperty, item.Id - 1);
                button.Click += CategoryMenuClicked;
                CategoryGridView.Children.Add(button);
            }
        }

        private void CategoryMenuClicked(object sender, RoutedEventArgs e)
        {
            string buttonName = (sender as Button).Name;
            MessageBox.Show(buttonName);
            string[] numbers = Regex.Split(buttonName, @"\D+");

            int categoryId = Convert.ToInt16(numbers[1]);
            EventAggregator eventAggregator = new EventAggregator();
            eventAggregator.GetEvent<ShowCategoriesMenuItemEvent>()
                        .Publish(categoryId);

        }
    }
}
