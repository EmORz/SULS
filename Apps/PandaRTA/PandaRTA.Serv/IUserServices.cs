using System.Collections.Generic;
using PandaRTA.Data.Models;

namespace PandaRTA.Serv
{
    public interface IUserServices
    {
        string Create(string username, string email, string password);

        User GerUserOrNull(string username, string password);

        IEnumerable<string> GetUsernames();
    }
}