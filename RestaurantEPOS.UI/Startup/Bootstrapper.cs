using Autofac;
using RestaurantEPOS.DataAccess;
using RestaurantEPOS.DataAccess.Interface;
using RestaurantEPOS.DataAccess.Repository;
using RestaurantEPOS.UI.ViewModel;

namespace RestaurantEPOS.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RestaurantEposDbContext>().AsSelf();

            builder.RegisterType<CategoryViewModel>().As<ICategoryViewModel>();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<LoginWindow>().AsSelf();
            builder.RegisterType<OrderTypeWindow>().AsSelf();

            return builder.Build();
        }
    }
}
