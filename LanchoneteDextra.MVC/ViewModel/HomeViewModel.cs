using LanchoneteDextra.Domain.Entities;
using System.Collections.Generic;

namespace LanchoneteDextra.MVC.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
    }
}