using System;

namespace PandaRTA.Web.ViewModels.Recipient
{
    public class RecipientViewModel
    {
        public string Id { get; set; }

        public string Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecipientName { get; set; }
    }
}