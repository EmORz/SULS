using System.Collections.Generic;

namespace MishMashWebApp.ViewModels.Channels
{
    public class FollowedChannelsViewModel
    {
        public IEnumerable<FollowedChannelViewModel> FollowedChannels { get; set; }
    }
}