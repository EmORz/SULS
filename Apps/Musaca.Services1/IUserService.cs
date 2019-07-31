using System.Collections.Generic;
using Musaca.Data1.Models;

namespace Musaca.Services1
{
    public interface IUserService
    {
        string Create(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        IList<string> GetAllUsers();
    }
}