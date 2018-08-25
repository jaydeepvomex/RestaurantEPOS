using Prism.Events;
using RestaurantEPOS.UI.Event;
using RestaurantEPOS.UI.Interface;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RestaurantEPOS.UI.ViewModel
{
    public class CategoryViewModel : ViewModelBase, ICategoryViewModel
    {
        private ICategoryDataService _categoryDataService;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<CategoryItemViewModel> Categories { get; }

        public CategoryViewModel(ICategoryDataService categoryDataService, IEventAggregator eventAggregator)
        {
            _categoryDataService = categoryDataService;
            _eventAggregator = eventAggregator;

            Categories = new ObservableCollection<CategoryItemViewModel>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _categoryDataService.GetCategoryLookupAsync();
            Categories.Clear();
            foreach (var item in lookup)
            {
                Categories.Add(new CategoryItemViewModel(item.Id, item.DisplayMember));
            }
        }

        private CategoryItemViewModel _selectedCategory;

        public CategoryItemViewModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                if (_selectedCategory != null)
                {
                    _eventAggregator.GetEvent<ShowCategoriesMenuItemEvent>()
                        .Publish(_selectedCategory.Id);
                }
            }
        }
    }
}
