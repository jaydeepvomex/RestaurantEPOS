using Prism.Events;
using RestaurantEPOS.Model;
using RestaurantEPOS.Model.Lookup;
using RestaurantEPOS.UI.Event;
using RestaurantEPOS.UI.Interface;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RestaurantEPOS.UI.ViewModel
{
    public class MenuViewModel : ViewModelBase, IMenuViewModel
    {
        private IFoodItemDataService _foodItemDataService;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<LookupItem> FoodItems { get; set; }

        public MenuViewModel(IFoodItemDataService foodItemDataService, IEventAggregator eventAggregator)
        {
            _foodItemDataService = foodItemDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<ShowCategoriesMenuItemEvent>()
                .Subscribe(OnCategoriesChanged);

            FoodItems = new ObservableCollection<LookupItem>();
        }

        private void OnCategoriesChanged(int categoryId)
        {

        }

        //public async Task LoadAsync(int categoryId)
        //{
        //    var lookup = await _foodItemDataService.GetFoodItemAsync();
        //    FoodItems.Clear();
        //    foreach (var item in lookup)
        //    {
        //        FoodItems.Add(item);
        //    }
        //}

        public async Task LoadAsync()
        {
            var lookup = await _foodItemDataService.GetFoodItemAsync();
            FoodItems.Clear();
            foreach (var item in lookup)
            {
                FoodItems.Add(item);
            }
        }
    }
}
