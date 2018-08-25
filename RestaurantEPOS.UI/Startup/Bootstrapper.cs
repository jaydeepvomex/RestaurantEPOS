using Autofac;
using Prism.Events;
using RestaurantEPOS.UI.Data;
using RestaurantEPOS.UI.Interface;
using RestaurantEPOS.UI.ViewModel;

namespace RestaurantEPOS.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<RestaurantEposDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<LoginWindow>().AsSelf();
            builder.RegisterType<OrderTypeWindow>().AsSelf();

            builder.RegisterType<CategoryViewModel>().As<ICategoryViewModel>();
            builder.RegisterType<MenuViewModel>().As<IMenuViewModel>();

            builder.RegisterType<CategoryDataService>().As<ICategoryDataService>();
            builder.RegisterType<FoodItemDataService>().As<IFoodItemDataService>();
            builder.RegisterType<StaffDataService>().As<IStaffDataService>();
           
            return builder.Build();
        }
    }
}
