using MusacaRT.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace Musaca.AppRT.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Cashout()
        {
            var currentActiveOrder = this.orderService.GetCurrentActiveOrderByCashierId(this.User.Id);

            this.orderService.CompliteOrderById(currentActiveOrder.Id, User.Id);

            return Redirect("/");
        }
        
    }
}