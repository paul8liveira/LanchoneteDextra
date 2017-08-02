using System;
using LanchoneteDextra.Domain.Entities;
using LanchoneteDextra.Domain.Interfaces.Repositories;
using LanchoneteDextra.Domain.Interfaces.Services;

namespace LanchoneteDextra.Domain.Services
{
    //classe concreta herda metodos da base e implementa (caso necessario) metodos especificos indicados na interface implementada
    public class LancheService : ServiceBase<Lanche>, ILancheService
    {
        private readonly ILancheRepository _repository;

        public LancheService(ILancheRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}