using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.Web.ViewModels.Products
{
    public class CreateProductInputModel
    {
        [RequiredSis]
        [StringLengthSis(3, 10, "Name must be between 3 and 10 symbols!")]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(typeof(decimal),"0.01", "100000000000000000", errorMessage:"Price must be creater or  equal than 0.01!")]
        public decimal Price { get; set; }
    }
}