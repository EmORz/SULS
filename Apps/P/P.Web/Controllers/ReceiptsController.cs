using System.Linq;
using P.Services;
using P.Web.ViewModels.Receipt;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace P.Web.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsServices receiptsServices;

        public ReceiptsController(IReceiptsServices receiptsServices)
        {
            this.receiptsServices = receiptsServices;
        }

        [Authorize()]
        public IActionResult Index()
        {
            var allReceipts = this.receiptsServices.GetAll()
                .Select(x => new ReceiptViewModel
            {
                Id = x.Id,
                Fee = x.Fee,
                IssuedOn = x.IssuedOn,
                RecipientName = x.RecipientId
            }).ToList();

            return this.View(allReceipts);
        }
        
    }
}