using System;
using System.Linq;
using P.Data;
using P.Data.Models;

namespace P.Services
{
    public class PackageServices : IPackageServices
    {
        private readonly PdbContext db;
        private readonly IReceiptsServices receiptsServices;

        public PackageServices(PdbContext db, IReceiptsServices receiptsServices)
        {
            this.db = db;
            this.receiptsServices = receiptsServices;
        }
        public void Create(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = db.Users.Where(x => x.Username == recipientName).Select(x => x.Id).FirstOrDefault();
            if (userId == null)
            {
                return;
            }

            var package = new Package
            {
                Description = description,
                ShippingAddress = shippingAddress,
                Status = PackageStatus.Delivered,
                Weight = weight,
                RecipientId = userId
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public IQueryable<Package> GetAllByStatus(PackageStatus status)
        {
            var allByStatus = this.db.Packages.Where(s => s.Status == status);

            return allByStatus;
        }

        public void Deliver(string id)
        {
            var package = this.db.Packages.FirstOrDefault(x => x.Id == id);

            if (package == null)
            {
                return;
            }

            package.Status = PackageStatus.Delivered;

            this.db.SaveChanges();

            this.receiptsServices.CreateFromPackage(package.RecipientId, package.Id, package.Weight);


        }
    }
}