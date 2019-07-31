using System.Collections.Generic;

namespace MishMashWebApp.Models
{
    public class Tag
    {
        public Tag()
        {
            Channels = new List<ChannelTag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<ChannelTag> Channels { get; set; } 
    }
}