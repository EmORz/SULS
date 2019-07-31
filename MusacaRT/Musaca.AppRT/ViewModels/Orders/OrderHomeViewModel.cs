using System.Collections.Generic;
using System.Linq;
using Musaca.AppRT.ViewModels.Product;

namespace Musaca.AppRT.ViewModels.Orders
{
    public class OrderHomeViewModel
    {

        public List<ProductHomeViewModel> Products { get; set; } = new List<ProductHomeViewModel>();

        public decimal Price => this.Products.Sum(product => product.Price);
    }
}