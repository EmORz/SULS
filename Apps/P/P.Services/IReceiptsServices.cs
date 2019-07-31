using System.Collections.Generic;
using System.Linq;
using P.Data.Models;

namespace P.Services
{
    public interface IReceiptsServices
    {
        void CreateFromPackage(string recipientId, string packageId, decimal weight);

        IQueryable<Receipt> GetAll();
    }
}