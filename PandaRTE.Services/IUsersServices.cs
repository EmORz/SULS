using System.Collections.Generic;
using PandaRTE.Data.Models;

namespace PandaRTE.Services
{
    public interface IUsersServices
    {
        string Create(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        IEnumerable<string> GetUserNames();
    }
}