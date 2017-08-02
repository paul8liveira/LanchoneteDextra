using LanchoneteDextra.Domain.Interfaces.Services;
using LanchoneteDextra.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace LanchoneteDextra.Domain.Services
{
    //Classe concreta, implementa metodos da interface base de forma generica
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        //Atraves de injecao de dependencia feita pelo Ninject, consigo acionar a camada de infra convertendo IRepositoryBase para Infra.Repositories.RepositoryBase
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity GetById(string id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
