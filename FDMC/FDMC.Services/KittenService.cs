using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FDMC.Data;
using FDMC.Data.Models;

namespace FDMC.Services
{
    public class KittenService : IKittenService
    {
        private readonly FdmcDbContext db;

        public KittenService(FdmcDbContext db)
        {
            this.db = db;
        }

        public bool IsValidKitten(string breed)
        {
            var kitten = new Kitten();
            var r = "";
            return Enum.TryParse(breed, true, out Breed _);
        }

        public void AddKitten(string name, int age, string breed)
        {
            var kitten = new Kitten
            {
                Name = name,
                Breed = Enum.Parse<Breed>(breed),
                Age = age
            };

            this.db.Kittens.Add(kitten);
            this.db.SaveChanges();
        }

        public ICollection<KittenT> GetAllKittens()
        {
            var kittens = this.db.Kittens.ToList();
            var tempKitten = new List<KittenT>();
            
            foreach (var kitten in kittens)
            {
                var temp = new KittenT();
                temp.Breed = kitten.Breed.ToString();
                temp.Age = kitten.Age;
                temp.Name = kitten.Name;
                tempKitten.Add(temp);
                
            }
            return tempKitten;
        }
    }

    public class KittenT
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }
    }
}