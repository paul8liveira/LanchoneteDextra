using System.Collections.Generic;

namespace LanchoneteDextra.Domain.Interfaces.Repositories
{
    //Interface de repositorio base. Contrato de crud basico
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity GetById(string id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
