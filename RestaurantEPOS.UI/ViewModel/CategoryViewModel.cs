using RestaurantEPOS.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEPOS.UI.ViewModel
{
    public class CategoryViewModel : ViewModelBase, ICategoryViewModel
    {
        private ICategoryRepository _categoryRepository;

        public ObservableCollection<CategoryItemViewModel> Categories { get; }

        public CategoryViewModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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

        private CategoryItemViewModel _selectedCategory;

        public CategoryItemViewModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                //if (_selectedFriend != null)
                //{
                //    _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                //        .Publish(_selectedFriend.Id);
                //}
            }
        }
    }
}
