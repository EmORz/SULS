﻿using System.Collections.Generic;
using System.Text;

namespace ChushkaWebApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
