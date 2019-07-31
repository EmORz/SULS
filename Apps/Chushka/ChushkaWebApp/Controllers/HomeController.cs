using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace ChushkaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                return this.View("IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }

        [HttpGet(Url = "/")]
        public IActionResult RootIndex()
        {
            return this.Index();
        }
    }
}