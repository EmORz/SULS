using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaRTE.Web.ViewModels.Users
{
    class RegisterInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Username should be between 5 and 20 characters")]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, "Email should be between 5 and 20 characters")]
        public string Email { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        /*    <form class="w-50 mx-auto" action="/Users/Register" method="POST">
        <div class="form-group">
            <label for="username" class="text-panda">Username</label>
            <input type="text" class="form-control" id="username" name="username" placeholder="Username..." />
        </div>
        <div class="form-group">
            <label for="email" class="text-panda">Email</label>
            <input type="email" class="form-control" id="email" name="email" placeholder="Email..." />
        </div>
        <div class="form-group">
            <label for="password" class="text-panda">Password</label>
            <input type="password" class="form-control" id="password" name="password" placeholder="Password..." />
        </div>
        <div class="form-group">
            <label for="confirmPassword" class="text-panda">Confirm Password</label>
            <input type="password" class="form-control" id="confirmPassword" name="confirmPassword" placeholder="Confirm Password..." />
        </div>*/
    }
}
