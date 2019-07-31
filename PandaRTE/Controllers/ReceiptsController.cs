using System.Linq;
using PandaRTE.Services;
using PandaRTE.Web.ViewModels.Receipts;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace PandaRTE.Web.Controllers
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
            var viewModel = this.receiptsServices.GetAll().Select(x => new ReceiptsViewModel()
            {
                Id = x.Id,
                Fee = x.Fee,
                IssuedOn = x.IssuedOn,
                RecipientName = x.Recipient.Username
            }).ToList();

            return this.View(viewModel);
        }
        
    }
}