using System.Collections.Generic;
using MishMashWebApp.Models.Enums;

namespace MishMashWebApp.Models
{
    public class User
    {
        public User()
        {
            Channels = new List<UserInChannel>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public virtual List<UserInChannel> Channels { get; set; }
        public Role Role { get; set; }

        /*•	Has an Id – a UUID String or an Integer.
           •	Has an Username
           •	Has a Password
           •	Has an Email
           •	Has Followed Channels – a collection of Channels.
           •	Has an Role – can be one of the following values (“User”, “Admin”)
           */
    }
}
