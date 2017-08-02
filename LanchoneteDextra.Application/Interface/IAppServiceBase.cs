using System.Collections.Generic;

namespace LanchoneteDextra.Application.Interface
{
    //Interface de repositorio base. Contrato de crud basico
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(string id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
