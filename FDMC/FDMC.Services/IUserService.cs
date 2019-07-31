using System.Collections.Generic;
using FDMC.Data.Models;

namespace FDMC.Services
{
    public interface IUserService
    {
        int Create(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        IList<string> GetAllUsers();
    }
}