﻿using MishMashWebApp.Data;
using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;

namespace MishMashWebApp
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new MishMashDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            //serviceProvider.Add<IUserService, UserService>();
            //serviceProvider.Add<IProductService, ProductService>();
            //serviceProvider.Add<IOrderService, OrderService>();
        }
    }
}
