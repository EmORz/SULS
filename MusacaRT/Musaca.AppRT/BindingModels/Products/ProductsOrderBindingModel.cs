using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.AppRT.BindingModels.Products
{
    public class ProductsOrderBindingModel
    {
        [RequiredSis]
        public string Name { get; set; }
    }
}