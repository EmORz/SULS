using System.Collections.Generic;
using System.Linq;
using PandaRTE.Data.Models;
using PandaRTE.Services;
using PandaRTE.Web.ViewModels.Packages;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace PandaRTE.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesServices packagesServices;
        private readonly IUsersServices usersServices;

        public PackagesController(IPackagesServices packagesServices, IUsersServices usersServices)
        {
            this.packagesServices = packagesServices;
            this.usersServices = usersServices;
        }
        [Authorize()]
        public IActionResult Create()
        {

            var userNames = this.usersServices.GetUserNames();

            return this.View(userNames);
        }

        [Authorize()]
        [HttpPost]
        public IActionResult Create(CreateInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return  this.Redirect("/Package/Create");
            }
            this.packagesServices.Create(input.Description, input.Weight, input.ShippingAddress, input.RecipientName);

            return Redirect("/Packages/Pending");

        }

        [Authorize()]
        public IActionResult Delivered()
        {
            var packages = this.packagesServices.GetAllPackageByStatus(PackageStatus.Delivered)
                .Select(x => new PackageViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    ShippingAddress = x.ShippingAddress,
                    RecipientName = x.Recipient.Username,
                    Weight = x.Weight
                }).ToList();
            return this.View(new PackagesListViewModel(){Packages = packages});
        }
        [Authorize()]
        public IActionResult Pending()
        {
            var packages = this.packagesServices.GetAllPackageByStatus(PackageStatus.Pending)
                .Select(x => new PackageViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                ShippingAddress = x.ShippingAddress,
                RecipientName = x.Recipient.Username,
                Weight = x.Weight
            }).ToList();
            return this.View(new PackagesListViewModel(){Packages = packages});
        }

        public IActionResult Deliver(string id)
        {
            this.packagesServices.Deliver(id);
            return this.Redirect("/Packages/Delivered");
        }
    }
}