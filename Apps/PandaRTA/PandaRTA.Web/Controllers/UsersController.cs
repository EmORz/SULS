using System;
using System.Collections.Generic;
using System.Text;
using PandaRTA.Serv;
using PandaRTA.Web.ViewModels;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace PandaRTA.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserServices userServices;

        public UsersController(IUserServices userServices)
        {
            this.userServices = userServices;
        }
        //todo add post 
        public IActionResult Login()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password!=input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }
            var userId = this.userServices.Create(input.Username, input.Email, input.Password);

            this.SignIn(userId, input.Username, input.Email);

            return this.Redirect("/");

        }

        [HttpPost]
        public IActionResult Login(LoginInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.userServices.GerUserOrNull(input.Username, input.Password);
            if (user ==  null)
            {
                return this.Redirect("/Users/Login");
            }


            this.SignIn(user.Id, user.Username, user.Email);

            return this.Redirect("/");

        }


        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
