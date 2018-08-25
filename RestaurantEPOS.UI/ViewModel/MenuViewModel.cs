using Prism.Events;
using RestaurantEPOS.Model;
using RestaurantEPOS.Model.Lookup;
using RestaurantEPOS.UI.Event;
using RestaurantEPOS.UI.Interface;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantEPOS.UI.ViewModel
{
    public class MenuViewModel : ViewModelBase, IMenuViewModel
    {
        private IFoodItemDataService _foodItemDataService;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<FoodItemLookup> FoodItems { get; set; }

        public MenuViewModel(IFoodItemDataService foodItemDataService, IEventAggregator eventAggregator)
        {
            _foodItemDataService = foodItemDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<ShowCategoriesMenuItemEvent>()
                .Subscribe(OnCategoriesChanged);

            FoodItems = new ObservableCollection<FoodItemLookup>();
        }

        private async void OnCategoriesChanged(int categoryId)
        {
            await LoadAsync(categoryId);
        }

        public async Task LoadAsync(int categoryId)
        {
            var allItems = await _foodItemDataService.GetFoodItemAsync();
            var lookup = allItems.Where(x => x.CategoryId == categoryId);
            FoodItems.Clear();
            foreach (var item in lookup)
            {
                FoodItems.Add(item);
            }
        }
    }
}
