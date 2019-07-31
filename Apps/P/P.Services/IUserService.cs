using System.Collections.Generic;
using P.Data.Models;

namespace P.Services
{
    public interface IUserService
    {
        string Create(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        IList<string> GetAllUsers();
    }
}