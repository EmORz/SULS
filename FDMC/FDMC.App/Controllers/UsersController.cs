using FDMC.App.ViewModels.Users;
using FDMC.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace FDMC.App.Controllers
{
    class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService )
        {
            this.userService = userService;
        }

        #region Login
        public IActionResult Login()
        {
            return this.View();
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

            this.SignIn(userId.Id.ToString(), model.Username, model.Password);

            return Redirect("/");

        }


        #endregion


        #region Register

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


            this.SignIn(userId.ToString(), model.Username, model.Email);

            return Redirect("/");

        }


        #endregion

        [Authorize()]
        public IActionResult Logout()
        {
            this.SignOut();
            return Redirect("/");
        }


    }
}
