using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MishMashWebApp.Models;
using MishMashWebApp.Models.Enums;
using MishMashWebApp.ViewModels.Users;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Action;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace MishMashWebApp.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public IHttpResponse Login()
        {
            return this.View();
        }

        [HttpPost()]
        public IHttpResponse Login(DoLoginInputModel loginInputModel)
        {
            var hashPassword = this.HashPassword(loginInputModel.Password);

            var user = this.Db.Users.FirstOrDefault(x => x.Username == loginInputModel.Username
                                                         && x.Password == hashPassword);
            if (user==null)
            {
                return this.Redirect("/Users/Login");
            }
            this.SignIn(user.Id.ToString(), user.Username, user.Email);

            return this.Redirect("/");



        }

        [HttpPost]
        public IHttpResponse Register(DoRegistrationInputModel registrationInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (registrationInputModel.Password != registrationInputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            User user = new User
            {
                Username = registrationInputModel.Username,
                Password = this.HashPassword(registrationInputModel.Password),
                Email = registrationInputModel.Email,
                Role = Role.User
            };

            this.Db.Users.Add(user);
            this.Db.SaveChanges();


            return this.Redirect("/Users/Login");
        }

        [HttpGet]
        public IHttpResponse Register()
        {
            return this.View();
        }

        [HttpGet]
        public IHttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }

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