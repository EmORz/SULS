using System;
using System.Collections.Generic;
using System.Linq;
using P.Data;
using P.Data.Models;

namespace P.Services
{
    public class ReceiptsServices : IReceiptsServices
    {
        private readonly PdbContext db;

        public ReceiptsServices(PdbContext db)
        {
            this.db = db;
        }
        public void CreateFromPackage(string recipientId, string packageId, decimal weight)
        {
            var receipt = new Receipt
            {
                RecipientId = recipientId,
                Fee = weight * 2.67M,
                IssuedOn = DateTime.UtcNow,
                PackageId = packageId
            };

            this.db.Receipts.Add(receipt);
            this.db.SaveChanges();
        }

        public IQueryable<Receipt> GetAll()
        {
            var allReceipts = this.db.Receipts;
            return allReceipts;
        }
    }
}