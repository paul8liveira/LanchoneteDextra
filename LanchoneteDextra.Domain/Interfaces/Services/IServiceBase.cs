using System.Collections.Generic;

namespace LanchoneteDextra.Domain.Interfaces.Services
{
    //Interface de servico base. Contrato de crud basico
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(string id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
