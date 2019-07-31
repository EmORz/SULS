using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using P.Data;
using P.Data.Models;

namespace P.Services
{
    public class UserService : IUserService
    {
        private readonly PdbContext db;

        public UserService(PdbContext db)
        {
            this.db = db;
        }
        public string Create(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = HashPassword(password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Id;
        }

        public User GetUserOrNull(string username, string password)
        {
            var hashPass = HashPassword(password);

            var user = this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashPass);
            return user;

        }

        public IList<string> GetAllUsers()
        {
            var userList = this.db.Users.Select(x => x.Username).ToList();
            return userList;
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