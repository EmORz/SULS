using ChushkaWebApp.Models;

namespace ChushkaWebApp.Services
{
    public interface IUserServices
    {
        int CreateUser(string username, string email, string password, string fullName);

        User GetUserOrNull(string username, string password);
    }
}