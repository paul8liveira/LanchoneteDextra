using LanchoneteDextra.Domain.Entities;
using System.Collections.Generic;

namespace LanchoneteDextra.Domain.Interfaces.Repositories
{
    //Interface de repositorio para adicionar metodos especificos para a entidade fora do contrato base
    public interface IIngredienteRepository : IRepositoryBase<Ingrediente>
    {
        new IEnumerable<Ingrediente> GetAll();
        new Ingrediente GetById(string id);
    }
}
