using System.Collections.Generic;
using Musaca.Data1.Models;

namespace Musaca.Services1
{
    public interface IProductsService
    {
        void CreateProduct(string name, decimal price);

        List<Product> AllProducts();

        Product GetByName(string name);
    }
}