using System;
using MusacaRT.Data;
using MusacaRT.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Routing;
using IServiceProvider = SIS.MvcFramework.DependencyContainer.IServiceProvider;

namespace Musaca.AppRT
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using(var context = new MusacaDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUserService, UserService>();
            serviceProvider.Add<IProductService, ProductsService>();
            serviceProvider.Add<IOrderService, OrderService>();
        }
    }
}