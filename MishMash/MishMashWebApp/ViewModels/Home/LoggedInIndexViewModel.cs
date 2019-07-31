using System.Collections.Generic;
using MishMashWebApp.ViewModels.Channels;

namespace MishMashWebApp.ViewModels.Home
{
    public class LoggedInIndexViewModel
    {
        public string UserRole { get; set; }
        public IEnumerable<BaseChannelViewModels> YouChannels { get; set;}
        public IEnumerable<BaseChannelViewModels> SuggestedChannels { get; set;}
        public IEnumerable<BaseChannelViewModels> SeeOtherChannels { get; set; }
    }
}