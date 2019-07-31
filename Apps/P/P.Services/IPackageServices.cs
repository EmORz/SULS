using System.Linq;
using P.Data.Models;

namespace P.Services
{
    public interface IPackageServices
    {
        void Create(string description, decimal weight, string shippingAddress, string recipientName);

        IQueryable<Package> GetAllByStatus(PackageStatus status);

        void Deliver(string id);
    }
}