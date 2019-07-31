using System.Collections.Generic;
using FDMC.Data.Models;

namespace FDMC.Services
{
    public interface IKittenService
    {
        bool IsValidKitten(string breed);
        void AddKitten(string name, int age, string breed);

        ICollection<KittenT> GetAllKittens();
    }
}