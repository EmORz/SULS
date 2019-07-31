using SIS.MvcFramework.Attributes.Validation;

namespace P.Web.ViewModels.Package
{
    public class CreatePackageInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Description should be between 5 and 20 characters.")]
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        [RequiredSis]
        public string RecipientName { get; set; }


    }
}