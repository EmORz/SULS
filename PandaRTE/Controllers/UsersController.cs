using System;
using System.Collections.Generic;
using System.Text;
using PandaRTE.Services;
using PandaRTE.Web.ViewModels.Users;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace PandaRTE.Web.Controllers
{
    class UsersController : Controller
    {
        private readonly IUsersServices usersServices;

        public UsersController(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        [HttpPost]
        public IActionResult Login(LoginInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var userFromDb = this.usersServices.GetUserOrNull(input.Username, input.Password);
            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }
            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);
            return this.Redirect("/");
        }
        public IActionResult Login()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }



        [HttpPost]
        public IActionResult Register(RegisterInputModel registerInputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (registerInputModel.Password != registerInputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }
            var userId = this.usersServices.Create(registerInputModel.Username, registerInputModel.Email, registerInputModel.Password);



            this.SignIn(userId, registerInputModel.Username, registerInputModel.Email);

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
