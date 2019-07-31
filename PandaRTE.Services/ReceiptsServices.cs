using System;
using System.Linq;
using PandaRTE.Data;
using PandaRTE.Data.Models;

namespace PandaRTE.Services
{
    public class ReceiptsServices : IReceiptsServices
    {
        private readonly PandaRteDbContext db;

        public ReceiptsServices(PandaRteDbContext db )
        {
            this.db = db;
        }

        public void CreateFromPackage(decimal weight, string packageId, string receiptId)
        {
            var receipt = new Receipt()
            {
                Fee = weight*2.67M,
                RecipientId =  receiptId,
                PackageId =  packageId,
                IssuedOn = DateTime.UtcNow

            };
            this.db.Receipts.Add(receipt);
            this.db.SaveChanges();
        }

        public IQueryable<Receipt> GetAll()
        {
            return this.db.Receipts;
        }
    }
}