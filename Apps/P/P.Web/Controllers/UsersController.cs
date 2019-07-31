using P.Services;
using P.Web.ViewModels.User;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace P.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Login()
        {

            return this.View();

        }
        [HttpPost]
        public IActionResult Login(LoginInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.userService.GetUserOrNull(input.Username,  input.Password);

            this.SignIn(user.Id, user.Username, user.Password);
            return Redirect("/");

        }

        public IActionResult Register()
        {

            return this.View();

        }

        [HttpPost]
        public IActionResult Register(RegisterInputModel register)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (register.Password != register.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            var userId = this.userService.Create(register.Username, register.Email, register.Password);

           this.SignIn(userId, register.Username, register.Email);
            return Redirect("/");

        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }


    }
}