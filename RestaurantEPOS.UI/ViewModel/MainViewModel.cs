using RestaurantEPOS.UI.Interface;
using System.Threading.Tasks;

namespace RestaurantEPOS.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICategoryViewModel CategoryViewModel { get; }
        public IMenuViewModel MenuViewModel { get; }

        public MainViewModel(ICategoryViewModel categoryViewModel, IMenuViewModel menuViewModel)
        {
            CategoryViewModel = categoryViewModel;
            MenuViewModel = menuViewModel;
        }

        public async Task LoadAsync()
        {
            await CategoryViewModel.LoadAsync();
            await MenuViewModel.LoadAsync();
        }
    }
}
