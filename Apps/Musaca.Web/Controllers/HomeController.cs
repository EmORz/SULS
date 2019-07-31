using System.Collections.Generic;
using System.Linq;
using Musaca.Data1.Models;
using Musaca.Services1;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace Musaca.Web.Controllers
{
    class HomeController : Controller
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }
        public IActionResult Index()
        {

            OrderHomeViewModel orderHomeViewModel = new OrderHomeViewModel();

            if (this.IsLoggedIn())
            {
                Order order = this.orderService
                    .GetCurrentActiveOrderByCashierId(this.User.Id);

                orderHomeViewModel = order.To<OrderHomeViewModel>();

                orderHomeViewModel.Products.Clear();

                foreach (var product in order.Products)
                {
                    ProductHomeViewModel productHomeViewModel = product.Product.To<ProductHomeViewModel>();

                    orderHomeViewModel.Products.Add(productHomeViewModel);

                }
            }


            return this.View(orderHomeViewModel);
        }
    }

    public class OrderHomeViewModel
    {
        public OrderHomeViewModel()
        {
            this.Products = new List<ProductHomeViewModel>();
        }

        public List<ProductHomeViewModel> Products { get; set; }

        public decimal Price => this.Products.Sum(product => product.Price);
    }

    public class ProductHomeViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
