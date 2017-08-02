using LanchoneteDextra.Application.Interface;
using LanchoneteDextra.Domain.Entities;
using LanchoneteDextra.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace LanchoneteDextra.Application
{
    //classe concreta herda metodos da base e implementa (caso necessario) metodos especificos indicados na interface implementada
    public class LancheAppService : AppServiceBase<Lanche>, ILancheAppService
    {
        private readonly ILancheService _service;

        public LancheAppService(ILancheService service) : base(service)
        {
            _service = service;
        }

        public new IEnumerable<Lanche> GetAll()
        {
            return _service.GetAll();
        }

        public new Lanche GetById(string id)
        {
            return _service.GetById(id);
        }

        public Pedido[] CalcPadrao(Pedido[] pedido)
        {
            foreach (var item in pedido)
            {
                var lanche = _service.GetById(item.IdLanche);
                item.Valor = lanche.Ingredientes.AsEnumerable().Sum(s => s.Valor) * item.Quantidade;
                item.NomeLanche = lanche.Nome;
            }
            return pedido;
        }
    }
}
