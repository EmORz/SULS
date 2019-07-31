using System;
using System.Collections.Generic;
using System.Linq;
using FDMC.App.ViewModels.Kittens;
using FDMC.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace FDMC.App.Controllers
{
    public class KittenController : Controller
    {
        private readonly IKittenService kittenService;

        public KittenController(IKittenService  kittenService)
        {
            this.kittenService = kittenService;
        }

        [Authorize()]
        public IActionResult Add()
        {
            return this.View();
        }


        [Authorize()]
        [HttpPost]
        public IActionResult Add(AddKittenInputModel addKitten )
        {
            var isValidKitten = this.kittenService.IsValidKitten(addKitten.Breed);
            if (isValidKitten==false)
            {
                return this.Redirect("/Kitten/Add");
            }
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Kitten/Add");
            }

            this.kittenService.AddKitten(addKitten.Name, addKitten.Age, addKitten.Breed);

            return this.Redirect("/Kitten/All");
        }

        [Authorize()]
        public IActionResult All()
        {

            var test = this.kittenService.GetAllKittens().To<AllKittenViewModel>();
            //AllKittenViewModel KittenView = new AllKittenViewModel();
            //List<ListOfAllKittensViewModel> all = new List<ListOfAllKittensViewModel>();
            //ListOfAllKittensViewModel temp = new ListOfAllKittensViewModel();

            //var allKittens = this.kittenService.GetAllKittens();
            //foreach (var kitten in allKittens)
            //{
            //    KittenView.Age = kitten.Age;
            //    KittenView.Name = kitten.Name;
            //    KittenView.Breed = kitten.Breed.ToString();
            //    temp.AllKittenViewModels.Add(KittenView);
            //    all.Add(temp);
            //}

            //foreach (var listOfAllKittensViewModel in all)
            //{
            //    Console.WriteLine(listOfAllKittensViewModel.AllKittenViewModels.Select(x => x.));
            //}
            return this.View(test);
        }

    }
}