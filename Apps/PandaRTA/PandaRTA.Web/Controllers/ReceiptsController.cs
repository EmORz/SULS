using System.Linq;
using Panda.Web.ViewModels.Receipts;
using PandaRTA.Serv;
using PandaRTA.Web.ViewModels.Recipient;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace PandaRTA.Web.Controllers
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
            var temp = this.receiptsServices.GetAll()
                .Select(x => new RecipientViewModel
                {
                    Id = x.Id,
                    Fee = x.Fee.ToString(),
                    IssuedOn = x.IssuedOn,
                    RecipientName = x.Recipient.Username

            }).ToList();
            return this.View(temp);
        }
    }
}