using LanchoneteDextra.Domain.Entities;
using System.Collections.Generic;

namespace LanchoneteDextra.Domain.Interfaces.Repositories
{
    //Interface de repositorio para adicionar metodos especificos para a entidade fora do contrato base
    public interface ILancheRepository : IRepositoryBase<Lanche>
    {
        new IEnumerable<Lanche> GetAll();
        new Lanche GetById(string id);
    }
}
