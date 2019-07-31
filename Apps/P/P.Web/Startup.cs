using P.Data;
using P.Services;
using Panda.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;

namespace P.Web
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            // Once on start
            using (var db = new PdbContext())
            {
                db.Database.EnsureCreated();
            }
        }


        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUserService, UserService>();
            serviceProvider.Add<IPackageServices, PackageServices>();
            serviceProvider.Add<IReceiptsServices, ReceiptsServices>();
        }
    }


}
