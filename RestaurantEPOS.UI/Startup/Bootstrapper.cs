using Autofac;
using Prism.Events;
using RestaurantEPOS.UI;
using RestaurantEPOS.UI.Data;
using RestaurantEPOS.UI.Interface;
using RestaurantEPOS.UI.Repository;
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

            builder.RegisterType<CategoryViewModel>().As<ICategoryViewModel>();
            builder.RegisterType<FoodItemDataService>().As<IFoodItemDataService>();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<LoginWindow>().AsSelf();
            builder.RegisterType<OrderTypeWindow>().AsSelf();

            return builder.Build();
        }
    }
}
