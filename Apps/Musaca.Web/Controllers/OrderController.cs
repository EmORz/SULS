using Musaca.Services1;
using SIS.MvcFramework;
using SIS.MvcFramework.Result;

namespace Musaca.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Cashout()
        {
            var currentOrder = this.orderService.GetCurrentActiveOrderByCashierId(this.User.Id);
            orderService.CoplitedOrder(currentOrder.Id, this.User.Id);

            return this.Redirect("/");



        }
    }
}