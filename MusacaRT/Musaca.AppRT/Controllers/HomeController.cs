using Musaca.AppRT.ViewModels.Orders;
using Musaca.AppRT.ViewModels.Product;
using MusacaRT.Models;
using MusacaRT.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace Musaca.AppRT.Controllers
{
    public class HomeController : Controller
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
            if (IsLoggedIn())
            {
                Order order = this.orderService.GetCurrentActiveOrderByCashierId(this.User.Id);

                 orderHomeViewModel = order.To<OrderHomeViewModel>();

                 foreach (var product in order.Products)
                 {
                     ProductHomeViewModel productHomeViewModel =
                         product.Product.To<ProductHomeViewModel>();
                     orderHomeViewModel.Products.Add(productHomeViewModel);
                 }
            }
            return this.View(orderHomeViewModel);

        }
    }
}
    