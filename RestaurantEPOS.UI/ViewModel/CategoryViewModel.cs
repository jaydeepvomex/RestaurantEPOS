using Prism.Events;
using RestaurantEPOS.Model.Lookup;
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

        public ObservableCollection<LookupItem> Categories { get; }

        public CategoryViewModel(ICategoryDataService categoryDataService, IEventAggregator eventAggregator)
        {
            _categoryDataService = categoryDataService;
            _eventAggregator = eventAggregator;

            Categories = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _categoryDataService.GetCategoryLookupAsync();
            Categories.Clear();
            foreach (var item in lookup)
            {
                Categories.Add(item);
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
