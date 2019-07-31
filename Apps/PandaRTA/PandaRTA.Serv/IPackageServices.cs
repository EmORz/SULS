using System.Linq;
using PandaRTA.Data.Models;

namespace PandaRTA.Serv
{
    public interface IPackageServices
    {
        IQueryable<Package> GetAllPackageByStatus(PackageStatus status);

        void Create(string description, decimal Weight, string shippingAddress, string recipientName);
        void Deliver(string id);
    }
}