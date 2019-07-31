using System;
using PandaRTE.Data;
using PandaRTE.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Routing;
using IServiceProvider = SIS.MvcFramework.DependencyContainer.IServiceProvider;

namespace PandaRTE.Web
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var db = new PandaRteDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUsersServices, UsersServices>();
            serviceProvider.Add<IPackagesServices, PackagesServices>();
            serviceProvider.Add<IReceiptsServices, ReceiptsServices>();
        }
    }
}