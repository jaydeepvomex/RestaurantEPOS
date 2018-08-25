namespace RestaurantEPOS.UI.ViewModel
{
    public class MenuItemViewModel : ViewModelBase
    {
        private string _displayMember;

        public MenuItemViewModel(int id, string displayMember)
        {
            Id = id;
            DisplayMember = displayMember;
        }

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }
        //private IFoodItemDataService _foodItemDataService;
        //private IEventAggregator _eventAggregator;

        //public ObservableCollection<FoodItem> FoodItems { get; set; }

        //public MenuItemViewModel(IFoodItemDataService foodItemDataService,
        //    IEventAggregator eventAggregator)
        //{
        //    FoodItems = new ObservableCollection<FoodItem>();

        //    _foodItemDataService = foodItemDataService;
        //    _eventAggregator = eventAggregator;
        //    _eventAggregator.GetEvent<ShowCategoriesMenuItemEvent>()
        //        .Subscribe(OnCategoriesChanged);
        //}

        //private void OnCategoriesChanged(int categoryId)
        //{

        //}

        //public void Load(int categoryId)
        //{
        //    var foodItems = _foodItemDataService.GetAll();
        //    FoodItems.Clear();
        //    foreach (var foodItem in foodItems)
        //    {
        //        FoodItems.Add(foodItem);
        //    }
        //}
    }
}
