using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.AppRT.BindingModels.Products
{
    public class ProductCreateBindingModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, errorMessage: "Product name must be between 5 and 20 symbols!")]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(0.01, 1596345445842000255.00, "Product price must be greater than or equal to 0.01!")]
        public double Price { get; set; }
    }
}