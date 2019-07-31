using System;

namespace PandaRTE.Web.ViewModels.Receipts
{
    public class ReceiptsViewModel
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecipientName { get; set; }

        /*       <th scope="col" class="col-lg-2 d-flex justify-content-center">Fee</th>
                    <th scope="col" class="col-lg-3 d-flex justify-content-center">Issued On</th>
                    <th scope="col" class="col-lg-3 d-flex justify-content-center">Recipient</th>*/
    }
}