using LanchoneteDextra.Application.Interface;
using LanchoneteDextra.Domain.Entities;
using LanchoneteDextra.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace LanchoneteDextra.Application
{
    //classe concreta herda metodos da base e implementa (caso necessario) metodos especificos indicados na interface implementada
    public class IngredienteAppService : AppServiceBase<Ingrediente>, IIngredienteAppService
    {
        private readonly IIngredienteService _service;

        public IngredienteAppService(IIngredienteService service) : base(service)
        {
            _service = service;
        }

        public new IEnumerable<Ingrediente> GetAll()
        {
            return _service.GetAll();
        }

        public new Ingrediente GetById(string id)
        {
            return _service.GetById(id);
        }
    }
}
