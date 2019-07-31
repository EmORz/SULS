using Musaca.Data1.Models;
using Musaca.Services1;
using Musaca.Web.ViewModels;
using Musaca.Web.ViewModels.Orders;
using Musaca.Web.ViewModels.Products;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace Musaca.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly IOrderService orderService;

        public ProductsController(IProductsService productsService, IOrderService orderService)
        {
            this.productsService = productsService;
            this.orderService = orderService;
        }

        [HttpPost]
        public IActionResult Order(ProductOrderInputModel productOrder)
        {

            var product = this.productsService.GetByName(productOrder.Product);

            this.orderService.AddProductToCurrentActiveOrder(product.Id, User.Id);


            return Redirect("/");



        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult All()
        {
            var all = this.productsService.AllProducts().To<ProductAllViewModel>();
            return this.View(all);
        }



        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateProductInputModel createProduct)
        {
            if (!this.ModelState.IsValid)
            {
                // TODO: SAVE FORM RESULT
                return this.View();
            }

            this.productsService.CreateProduct(createProduct.Name, createProduct.Price);

            return this.Redirect("All");
        }





    }
}
