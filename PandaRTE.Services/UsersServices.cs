using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PandaRTE.Data;
using PandaRTE.Data.Models;

namespace PandaRTE.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly PandaRteDbContext context;

        public UsersServices(IUsersServices usersServices)
        {
            this.context = context;
        }
        public string Create(string username, string email, string password)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = HashPassword(password)
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return user.Id;
        }

        public User GetUserOrNull(string username, string password)
        {
            var hashPassword = this.HashPassword(password);
            var user = this.context.Users
                .FirstOrDefault(x => 
                    x.Username == username && x.Password == hashPassword);

            return user;
        }

        public IEnumerable<string> GetUserNames()
        {
            var userNames = this.context.Users.Select(x => x.Username).ToList();
            return userNames;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}