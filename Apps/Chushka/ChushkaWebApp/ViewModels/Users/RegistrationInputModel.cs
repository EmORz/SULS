﻿namespace ChushkaWebApp.ViewModels.Users
{
    public class RegistrationInputModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}