using Prism.Events;
using RestaurantEPOS.UI.Event;
using RestaurantEPOS.UI.Interface;
using System.Collections.ObjectModel;

namespace RestaurantEPOS.UI.ViewModel
{
    public class CategoryViewModel : ViewModelBase, ICategoryViewModel
    {
        private ICategoryRepository _categoryRepository;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<CategoryItemViewModel> Categories { get; }

        public CategoryViewModel(ICategoryRepository categoryRepository,
            IEventAggregator eventAggregator)
        {
            _categoryRepository = categoryRepository;
            _eventAggregator = eventAggregator;
        }

        public void LoadAsync()
        {
            var categories = _categoryRepository.GetItems();
            Categories.Clear();
            foreach (var item in categories)
            {
                Categories.Add(new CategoryItemViewModel(item.Id, item.FoodItems.ToString()));
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
