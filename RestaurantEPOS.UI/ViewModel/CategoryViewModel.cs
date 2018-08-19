using Prism.Events;
using RestaurantEPOS.UI.Event;
using RestaurantEPOS.UI.Interface;
using System.Collections.ObjectModel;

namespace RestaurantEPOS.UI.ViewModel
{
    public class CategoryViewModel : ViewModelBase, ICategoryViewModel
    {
        private ICategoryDataService _categoryDataService;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<CategoryItemViewModel> Categories { get; }

        public CategoryViewModel(ICategoryDataService categoryDataService,
            IEventAggregator eventAggregator)
        {
            _categoryDataService = categoryDataService;
            _eventAggregator = eventAggregator;
        }

        public void LoadAsync()
        {
            var categories = _categoryDataService.GetAll();
            Categories.Clear();
            foreach (var item in categories)
            {
                Categories.Add(new CategoryItemViewModel(item.Id, item.CategoryName.ToString()));
            }
        }

        private int _selectedCategory;

        public int SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                if (_selectedCategory != 0)
                {
                    _eventAggregator.GetEvent<ShowCategoriesMenuItemEvent>()
                        .Publish(_selectedCategory);
                }
            }
        }
    }
}
