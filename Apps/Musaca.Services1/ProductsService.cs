using System.Collections.Generic;
using System.Linq;
using Musaca.Data1;
using Musaca.Data1.Models;

namespace Musaca.Services1
{
    public class ProductsService : IProductsService
    {
        private readonly MusacaDbContext db;

        public ProductsService(MusacaDbContext db)
        {
            this.db = db;
        }
        public void CreateProduct(string name, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Price = price
            };
            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public List<Product> AllProducts()
        {
            return this.db.Products.ToList();
        }

        public Product GetByName(string name)
        {
            var productFromDb = this.db.Products.FirstOrDefault(x => x.Name == name);

            return productFromDb;
        }
    }
}