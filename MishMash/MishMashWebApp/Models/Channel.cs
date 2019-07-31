using System.Collections.Generic;
using MishMashWebApp.Models.Enums;

namespace MishMashWebApp.Models
{
    public class Channel
    {
        public Channel()
        {
            this.Followers = new List<UserInChannel>();
            this.Tags = new List<ChannelTag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ChannelType ChannelType { get; set; }

        public List<ChannelTag> Tags { get; set; } //*

        public virtual List<UserInChannel> Followers { get; set; }

        /*•	Has an Id – a UUID String or an Integer.
           •	Has a Name
           •	Has a Description
           •	Has a Type – can be one of the following values (“Game”, “Motivation”, “Lessons”, “Radio”, “Other”).
           •	Has Tags – a collection of Strings.
           •	Has Followers – a collection of Users.
           */
    }
}