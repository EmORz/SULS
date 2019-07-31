using PandaRTA.Data;
using PandaRTA.Serv;
using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;

namespace PandaRTA.Web
{
    internal class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var db = new PandaRtaDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        { 
            serviceProvider.Add<IUserServices, UserServices>();
            serviceProvider.Add<IPackageServices, PackageServices>();
            serviceProvider.Add<IReceiptsServices, ReceiptsServices>();
        }
    }
}