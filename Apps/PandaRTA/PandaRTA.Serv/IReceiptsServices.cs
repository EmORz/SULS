using System.Linq;
using PandaRTA.Data.Models;

namespace PandaRTA.Serv
{
    public interface IReceiptsServices
    {
        void CreateFromPackage(decimal weight, string packageId, string recipientId);

        IQueryable<Receipt> GetAll();
    }

}