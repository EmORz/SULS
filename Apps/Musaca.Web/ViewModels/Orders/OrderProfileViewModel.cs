using System.Collections.Generic;
using Musaca.Data1.Models;

namespace Musaca.Web.ViewModels.Orders
{
    public class OrderProfileViewModel
    {
        public string Id { get; set; }

        public decimal Total { get; set; }

        public string IssuedOn { get; set; }

        public string Cashier { get; set; }

    }
}