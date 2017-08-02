using LanchoneteDextra.Application.Interface;
using LanchoneteDextra.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace LanchoneteDextra.Application
{
    //Classe concreta, implementa metodos da interface base de forma generica
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        //Atraves de injecao de dependencia feita pelo Ninject, consigo acionar a camada de dominio convertendo IServiceBase para Domain.Services.ServiceBase
        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public TEntity GetById(string id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
