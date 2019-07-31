using System.Collections.Generic;
using MusacaRT.Models;

namespace MusacaRT.Services
{
    public interface IProductService
    {
        Product CreateProduct(Product product);

        Product GetByName(string name);

        List<Product> GetAll();

    }
}