using System.Linq;
using PandaRTA.Data;
using PandaRTA.Data.Models;

namespace PandaRTA.Serv
{
    public class PackageServices : IPackageServices
    {
        private readonly PandaRtaDbContext db;
        private readonly IReceiptsServices receiptsServices;

        public PackageServices(PandaRtaDbContext db, IReceiptsServices receiptsServices )
        {
            this.db = db;
            this.receiptsServices = receiptsServices;
        }

        public IQueryable<Package> GetAllPackageByStatus(PackageStatus status)
        {
            var packages = this.db.Packages.Where(s => s.Status == status);
            return packages;
        }

        public void Create(string description, decimal Weight, string shippingAddress, string recipientName)
        {
            var userId = this.db.Users.Where(x => x.Username == recipientName).Select(x => x.Id).FirstOrDefault();

            if (userId == null)
            {
                return;
            }

            var package = new Package
            {
                Description = description,
                Weight = Weight,
                ShippingAddress = shippingAddress,
                RecipientId = userId,
                Status = PackageStatus.Pending
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();

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

            this.receiptsServices.CreateFromPackage(package.Weight, package.Id, package.RecipientId);

        }
    }
}