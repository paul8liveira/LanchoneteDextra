using LanchoneteDextra.Domain.Entities;
using System.Collections.Generic;

namespace LanchoneteDextra.Domain.Interfaces.Services
{
    //Interface de repositorio para adicionar metodos especificos para a entidade fora do contrato base
    public interface ILancheService : IServiceBase<Lanche>
    {
        new IEnumerable<Lanche> GetAll();
        new Lanche GetById(string id);
    }
}
