using System.Linq;
using PandaRTA.Data.Models;
using PandaRTA.Serv;
using PandaRTA.Web.ViewModels.Packages;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace PandaRTA.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackageServices packageServices;
        private readonly IUserServices userServices;

        public PackagesController(IPackageServices packageServices, IUserServices userServices)
        {
            this.packageServices = packageServices;
            this.userServices = userServices;
        }


        [Authorize()]
        public IActionResult Create()
        {
            var listUusers = this.userServices.GetUsernames();
            return this.View(listUusers);
        }

        [HttpPost]
        [Authorize()]
        public IActionResult Create(CreateInputModel createInputModel)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Package/Create");
            }

            this.packageServices.Create(createInputModel.Description, createInputModel.Weight, createInputModel.ShippingAddress, createInputModel.RecipientName);
            return this.Redirect("/Packages/Pending");
        }

        [Authorize()]
        public IActionResult Delivered()
        {
            var packages = this.packageServices.GetAllPackageByStatus(PackageStatus.Delivered)
                .Select(x => new PackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    RecipientName = x.Recipient.Username,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress

                }).ToList();
            return this.View(new PackagesListViewModel(){Packages = packages});
        }

        [Authorize()]
        public IActionResult Pending()
        {
            var packages = this.packageServices.GetAllPackageByStatus(PackageStatus.Pending)
                .Select(x => new PackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    RecipientName = x.Recipient.Username,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress

                }).ToList(); ;
            return this.View(new PackagesListViewModel() { Packages = packages });
        }

        [Authorize()]

        public IActionResult Deliver(string id)
        {
            this.packageServices.Deliver(id);


            return this.Redirect("/Packages/Delivered");
        }
    }
}