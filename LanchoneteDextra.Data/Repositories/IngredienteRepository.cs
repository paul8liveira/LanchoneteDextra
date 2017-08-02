using LanchoneteDextra.Domain.Entities;
using LanchoneteDextra.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LanchoneteDextra.Data.Repositories
{
    public class IngredienteRepository : RepositoryBase<Ingrediente>, IIngredienteRepository
    {
        private List<Ingrediente> lstIngredientes;

        public IngredienteRepository()
        {
            lstIngredientes = new List<Ingrediente>
            {
                new Ingrediente()
                {
                    Id = "alface",
                    Nome = "Alface",
                    Valor = 0.40M
                },
                new Ingrediente()
                {
                    Id = "bacon",
                    Nome = "Bacon",
                    Valor = 2
                },
                new Ingrediente()
                {
                    Id = "hamburguer",
                    Nome = "Hamburguer de carne",
                    Valor = 3
                },
                new Ingrediente()
                {
                    Id = "ovo",
                    Nome = "Ovo",
                    Valor = 0.80M
                },
                new Ingrediente()
                {
                    Id = "queijo",
                    Nome = "Queijo",
                    Valor = 1.50M
                }
            };
        }

        public new IEnumerable<Ingrediente> GetAll()
        {
            IEnumerable<Ingrediente> enIngredientes = lstIngredientes;
            return enIngredientes;
        }

        public new Ingrediente GetById(string id)
        {
            return lstIngredientes.FirstOrDefault(f => f.Id.Equals(id));
        }
    }
}
