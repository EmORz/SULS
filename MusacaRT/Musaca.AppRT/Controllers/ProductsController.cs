using Musaca.AppRT.BindingModels.Products;
using Musaca.AppRT.ViewModels.Product;
using MusacaRT.Models;
using MusacaRT.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace Musaca.AppRT.Controllers
{
    public class ProductsController: Controller

    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductsController(IProductService productService, IOrderService orderService )
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult All()
        {
            return this.View(this.productService.GetAll().To<ProductAllViewModel>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateBindingModel productCreateBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.productService.CreateProduct(productCreateBindingModel.To<Product>());

            return this.Redirect("All");

        }

        [HttpPost]
        public IActionResult Order(ProductsOrderBindingModel bindingModel)
        {
            var productToOrder = this.productService.GetByName(bindingModel.Name);

            this.orderService.AddProductToCurrentActiveOrder( productToOrder.Id, this.User.Id);

            return this.Redirect("/");
        }

    }
}