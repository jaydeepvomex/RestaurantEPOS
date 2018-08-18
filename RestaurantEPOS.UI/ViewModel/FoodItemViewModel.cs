using Prism.Events;
using RestaurantEPOS.Model;
using RestaurantEPOS.UI.Event;
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
        private IEventAggregator _eventAggregator;

        public ObservableCollection<FoodItem> FoodItems { get; set; }

        public FoodItemViewModel(IFoodItemDataService foodItemDataService,
            IEventAggregator eventAggregator)
        {
            FoodItems = new ObservableCollection<FoodItem>();

            _foodItemDataService = foodItemDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<ShowCategoriesMenuItemEvent>()
                .Subscribe(OnCategoriesChanged);
        }

        private void OnCategoriesChanged(int categoryId)
        {
            
        }

        public void Load(int categoryId)
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
