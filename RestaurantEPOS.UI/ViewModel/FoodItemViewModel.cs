using RestaurantEPOS.Model;
using RestaurantEPOS.UI.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEPOS.UI.ViewModel
{
    public class FoodItemViewModel
    {
        private IFoodItemDataService _foodItemDataService;

        public ObservableCollection<FoodItem> FoodItems { get; set; }

        public FoodItemViewModel(IFoodItemDataService foodItemDataService)
        {
            FoodItems = new ObservableCollection<FoodItem>();

            _foodItemDataService = foodItemDataService;
        }

        public void Load()
        {
            var foodItems = _foodItemDataService.GetAll();
            FoodItems.Clear();
            foreach (var foodItem in foodItems)
            {
                FoodItems.Add(foodItem);
            }
        }
    }
}
