using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ChushkaWebApp.Models;
using ChushkaWebApp.Services;
using ChushkaWebApp.ViewModels.Users;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Action;
using SIS.MvcFramework.Result;

namespace ChushkaWebApp.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserServices userServices;

        public UsersController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpGet()]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpGet(Url = "/Users/Login")]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost()]
        public IActionResult Login(LoginInputModel loginInputModel)
        {
            var hashPassword = this.HashPassword(loginInputModel.Password);

        

            var userId = this.userServices.GetUserOrNull(loginInputModel.Username, loginInputModel.Password);
            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }
            this.SignIn(userId.Id.ToString(), loginInputModel.Username, loginInputModel.Password);

            return this.Redirect("/");



        }


        [HttpPost()]
        public IActionResult Register(RegistrationInputModel registrationInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (registrationInputModel.Password != registrationInputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            this.userServices.
                CreateUser(registrationInputModel.Username, registrationInputModel.Email,
                registrationInputModel.Password, registrationInputModel.FullName);


            return Redirect("/");
        }

        //***********************************
        [NonAction]
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

    }
}