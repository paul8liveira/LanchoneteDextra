using LanchoneteDextra.Domain.Entities;
using LanchoneteDextra.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LanchoneteDextra.Data.Repositories
{
    public class LancheRepository : RepositoryBase<Lanche>, ILancheRepository
    {
        private List<Lanche> lstLanches;

        public LancheRepository()
        {
            lstLanches = new List<Lanche>
            {
                new Lanche()
                {
                    Id = "xbacon",
                    Nome = "X-Bacon",
                    Personalizado = false,
                    Ingredientes = new List<Ingrediente>() {
                        new Ingrediente() {Id = "bacon", Nome = "Bacon", Valor = 2 },
                        new Ingrediente() {Id = "hamburguer", Nome = "Hamburguer de carnes", Valor = 3 },
                        new Ingrediente() {Id = "queijo", Nome = "Queijo", Valor = 1.5M },
                    }
                },
                new Lanche()
                {
                    Id = "xburger",
                    Nome = "X-Burger",
                    Personalizado = false,
                    Ingredientes = new List<Ingrediente>() {
                        new Ingrediente() {Id = "hamburguer", Nome = "Hamburguer de carnes", Valor = 3 },
                        new Ingrediente() {Id = "queijo", Nome = "Queijo", Valor = 1.5M },
                    }   
                },
                new Lanche()
                {
                    Id = "xegg",
                    Nome = "X-Egg",
                    Personalizado = false,
                    Ingredientes = new List<Ingrediente>() {
                        new Ingrediente() {Id = "ovo", Nome = "Ovo", Valor = 0.80M },
                        new Ingrediente() {Id = "hamburguer", Nome = "Hamburguer de carnes", Valor = 3 },
                        new Ingrediente() {Id = "queijo", Nome = "Queijo", Valor = 1.5M },
                    }
                },
                new Lanche()
                {
                    Id = "xeggbacon",
                    Nome = "X-Egg Bacon",
                    Personalizado = false,
                    Ingredientes = new List<Ingrediente>() {
                        new Ingrediente() {Id = "ovo", Nome = "Ovo", Valor = 0.80M },
                        new Ingrediente() {Id = "bacon", Nome = "Bacon", Valor = 2 },
                        new Ingrediente() {Id = "hamburguer", Nome = "Hamburguer de carnes", Valor = 3 },
                        new Ingrediente() {Id = "queijo", Nome = "Queijo", Valor = 1.5M },
                    }
                }
            };
        }

        public new IEnumerable<Lanche> GetAll()
        {
            IEnumerable<Lanche> enLanches = lstLanches;
            return enLanches;
        }

        public new Lanche GetById(string id)
        {
            return lstLanches.FirstOrDefault(f => f.Id.Equals(id));
        }
    }
}
