using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.AppRT.BindingModels.Users
{
    public class UserLoginBindingModel
    {
        private const string ErrorMessage = "Invalid username or password!";

        [RequiredSis(ErrorMessage)]
        public string Username { get; set; }

        [RequiredSis(ErrorMessage)]
        public string Password { get; set; }
    }
}
