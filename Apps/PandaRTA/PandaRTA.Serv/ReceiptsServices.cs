using System;
using System.Linq;
using PandaRTA.Data;
using PandaRTA.Data.Models;

namespace PandaRTA.Serv
{
    public class ReceiptsServices : IReceiptsServices
    {
        private readonly PandaRtaDbContext db;

        public ReceiptsServices(PandaRtaDbContext db)
        {
            this.db = db;
        }
        public void CreateFromPackage(decimal weight, string packageId, string recipientId)
        {
            var receipt = new Receipt
            {
                Fee = weight*2.67M,
                PackageId = packageId,
                RecipientId = recipientId,
                IssuedOn = DateTime.UtcNow
            };
            this.db.Add(receipt);
            this.db.SaveChanges();
        }

        public IQueryable<Receipt> GetAll()
        {
            return this.db.Receipts;
        }
    }
}