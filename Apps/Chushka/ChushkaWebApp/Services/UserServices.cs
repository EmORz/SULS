using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ChushkaWebApp.Data;
using ChushkaWebApp.Models;

namespace ChushkaWebApp.Services
{
    public class UserServices : IUserServices
    {
        private readonly ChushkaDbContext db;

        public UserServices(ChushkaDbContext db)
        {
            this.db = db;
        }
        public int CreateUser(string username, string email, string password, string fullName)
        {
            var role = UserRole.User;
            if (!this.db.Users.Any())
            {
                role = UserRole.Admin;
            }

            var user = new User()
            {
                Username = username,
                FullName = fullName,
                Email = email,
                Password =HashPassword(password),
                Role = role
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
        //*******************
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}