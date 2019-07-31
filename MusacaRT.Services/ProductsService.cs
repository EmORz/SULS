using System.Collections.Generic;
using System.Linq;
using MusacaRT.Data;
using MusacaRT.Models;

namespace MusacaRT.Services
{
    public class ProductsService : IProductService
    {
        private readonly MusacaDbContext db;

        public ProductsService(MusacaDbContext db )
        {
            this.db = db;
        }
        public Product CreateProduct(Product product)
        {
            this.db.Products.Add(product);
            this.db.SaveChanges();
            return product;
        }

        public Product GetByName(string name)
        {
            var productByName = this.db.Products.FirstOrDefault(p => p.Name == name);
            return productByName;
        }

        public List<Product> GetAll()
        {
            var allProducts = this.db.Products.ToList();

            return allProducts;


        }
    }
}