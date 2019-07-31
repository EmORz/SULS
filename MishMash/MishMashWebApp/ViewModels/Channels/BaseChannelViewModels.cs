using System.Collections.Generic;
using MishMashWebApp.Models.Enums;

namespace MishMashWebApp.ViewModels.Channels
{
    public class BaseChannelViewModels
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ChannelType Type { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string TagsAsString => string.Join(", ", Tags);

        public int FollowersCount { get; set; }
    }
}