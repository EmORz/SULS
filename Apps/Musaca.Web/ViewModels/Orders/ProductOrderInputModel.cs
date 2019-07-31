using SIS.MvcFramework.Attributes.Validation;
using SIS.MvcFramework.Result;

namespace Musaca.Web.ViewModels.Orders
{
    public class ProductOrderInputModel
    {
        [RequiredSis]
        public string Product { get; set; }
    }
}