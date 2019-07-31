using System.Linq;
using P.Data.Models;
using P.Services;
using P.Web.ViewModels.Package;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace P.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IUserService userService;
        private readonly IPackageServices packageServices;

        public PackagesController(IUserService userService, IPackageServices packageServices)
        {
            this.userService = userService;
            this.packageServices = packageServices;
        }

        [Authorize()]
        public IActionResult Create()
        {
            var users = this.userService.GetAllUsers();
            return this.View(users);
        }

        [Authorize()]
        public IActionResult Delivered()
        {
            var allByStatus = packageServices.GetAllByStatus(PackageStatus.Delivered)
                .Select(x => new PackageViewModel()
                {
                    Description = x.Description,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    RecipientName = x.Recipient.Username,
                    Id = x.Id
                })
                .ToList();

            var deliveredPackages = new PackageListViewModels()
            {
                Packages = allByStatus
            };

            return this.View(deliveredPackages);
        }

        [Authorize()]
        public IActionResult Pending()
        {
            var allByStatus = packageServices.GetAllByStatus(PackageStatus.Pending)
                .Select(x => new PackageViewModel()
                {
                    Description = x.Description,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    RecipientName = x.Recipient.Username,
                    Id = x.Id
                })
                .ToList();

            var pendingPackages = new PackageListViewModels()
            {
                Packages = allByStatus
            };

            return this.View(pendingPackages);
        }

        [Authorize()]
        [HttpPost]
        public IActionResult Create(CreatePackageInputModel createPackageInput)
        {

            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            this.packageServices.Create(createPackageInput.Description, 
                                       createPackageInput.Weight, 
                                       createPackageInput.ShippingAddress,
                                       createPackageInput.RecipientName);

            return this.Redirect("/Packages/Pending");

        }

        [Authorize()]

        public IActionResult Deliver(string id)
        {
            this.packageServices.Deliver(id);

            return Redirect("/Packages/Delivered");
        }
    }
}