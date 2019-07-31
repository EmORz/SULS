using System.Linq;
using Musaca.Data1.Models;
using Musaca.Services1;
using Musaca.Web.ViewModels;
using Musaca.Web.ViewModels.Orders;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace Musaca.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IOrderService orderService;

        public UsersController(IUserService userService, IOrderService orderService)
        {
            this.userService = userService;
            this.orderService = orderService;
        }
        public IActionResult Login()
        {
            return this.View();
        }
        [Authorize()]
        public IActionResult Logout()
        {
            this.SignOut();
            return Redirect("/");
        }

        [Authorize()]
        public IActionResult Profile()
        {
            var usersProfileViewModel = new UserProfileViewModel();
            var ordersFromDb = this.orderService.GetAllCompleteOrderByCashierId(this.User.Id);


            usersProfileViewModel.Orders = ordersFromDb.To<OrderProfileViewModel>().ToList();

            foreach (var order in usersProfileViewModel.Orders)
            {
                order.Cashier = this.User.Username;
                order.IssuedOn = ordersFromDb.SingleOrDefault(x => x.Id == order.Id).IssuedOn.ToString();

                order.Total = ordersFromDb.Where(x => x.Id == order.Id)
                    .SelectMany(x => x.Products)
                    .Sum(x => x.Product.Price);
            }
            return this.View(usersProfileViewModel);
        }


        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }


            var userId = this.userService.Create(model.Username, model.Email, model.Password);


            this.SignIn(userId, model.Username, model.Email);

            return Redirect("/");

        }

        [HttpPost]
        public IActionResult Login(UserLoginBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }


            var userId = this.userService.GetUserOrNull(model.Username, model.Password);

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId.Id, model.Username, model.Password);

            return Redirect("/");

        }
    }
}
