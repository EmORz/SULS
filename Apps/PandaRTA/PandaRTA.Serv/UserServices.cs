using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PandaRTA.Data;
using PandaRTA.Data.Models;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace PandaRTA.Serv
{
    public class UserServices : IUserServices
    {
        private readonly PandaRtaDbContext db;

        public UserServices(PandaRtaDbContext db)
        {
            this.db = db;
        }
        public string Create(string username, string email, string password)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password =HashPassword(password) 
            };
            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user.Id;


        }

        public User GerUserOrNull(string username, string password)
        {
            var hashPass = this.HashPassword(password);

            var userFromDb = this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashPass);

            return userFromDb;
        }

        public IEnumerable<string> GetUsernames()
        {
            var usernames = this.db.Users.Select(names => names.Username).ToList();
            return usernames;
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