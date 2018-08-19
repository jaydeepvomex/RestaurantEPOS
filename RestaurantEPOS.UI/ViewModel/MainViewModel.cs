using RestaurantEPOS.Model;
using RestaurantEPOS.UI.Interface;
using System.Collections.ObjectModel;
using System.Linq;

namespace RestaurantEPOS.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int _selectedCategory;

        private IFoodItemDataService _foodItemDataService;
        private ICategoryDataService _categoryDataService;

        public ObservableCollection<FoodItem> FoodItems { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public MainViewModel(IFoodItemDataService foodItemDataService,
            ICategoryDataService categoryDataService)
        {
            FoodItems = new ObservableCollection<FoodItem>();
            Categories = new ObservableCollection<Category>();

            _foodItemDataService = foodItemDataService;
            _categoryDataService = categoryDataService;
        }

        public void Load()
        {
            var foodItems = _foodItemDataService.GetAll().Where(x => x.CategoryId == 2);
            var categories = _categoryDataService.GetAll();

            FoodItems.Clear();
            Categories.Clear();

            foreach (var food in foodItems)
            {
                FoodItems.Add(food);
            }

            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }

        public int SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }
    }
}
