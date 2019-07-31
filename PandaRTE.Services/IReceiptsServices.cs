using System.Linq;
using PandaRTE.Data.Models;

namespace PandaRTE.Services
{
    public interface IReceiptsServices
    {
        void CreateFromPackage(decimal weight, string packageId, string receiptId);

        IQueryable<Receipt> GetAll();
    }
}