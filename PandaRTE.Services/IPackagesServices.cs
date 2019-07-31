using System.Collections.Generic;
using System.Linq;
using PandaRTE.Data.Models;

namespace PandaRTE.Services
{
    public interface IPackagesServices
    {
        void Create(string description, decimal weight, string shippingAddress, string recipientName);

        IQueryable<Package> GetAllPackageByStatus(PackageStatus status);
        void Deliver(string id);
    }
}