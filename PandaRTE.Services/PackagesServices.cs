using System.Collections.Generic;
using System.Linq;
using PandaRTE.Data;
using PandaRTE.Data.Models;

namespace PandaRTE.Services
{
    public class PackagesServices : IPackagesServices
    {
        private readonly PandaRteDbContext db;
        private readonly IReceiptsServices receiptsServices;

        public PackagesServices(PandaRteDbContext db, IReceiptsServices receiptsServices)
        {
            this.db = db;
            this.receiptsServices = receiptsServices;
        }
        public void Create(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = this.db.Users.Where(x => x.Username == recipientName).Select(x => x.Id).FirstOrDefault();
            if (userId == null)
            {
                return;
            }
            var package = new Package()
            {
                Description = description,
                ShippingAddress = shippingAddress,
                Status = PackageStatus.Pending,
                Weight = weight,
                RecipientId = userId
            };
            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public IQueryable<Package> GetAllPackageByStatus(PackageStatus status)
        {
            var packages = this.db.Packages.Where(x => x.Status == status);
            return packages;


        }

        public void Deliver(string id)
        {
            var package = this.db.Packages.FirstOrDefault(x => x.Id == id);
            if (package ==null)
            {
                return;
            }

            package.Status = PackageStatus.Delivered;
            this.db.SaveChanges();

            this.receiptsServices.CreateFromPackage(package.Weight, package.Id, package.RecipientId);


        }
    }
}