using System.Collections.Generic;

namespace FDMC.App.ViewModels.Kittens
{
    public class ListOfAllKittensViewModel
    {
        public ICollection<AllKittenViewModel> AllKittenViewModels { get; set; } = new List<AllKittenViewModel>();
    }
}