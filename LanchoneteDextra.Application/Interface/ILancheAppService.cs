using LanchoneteDextra.Domain.Entities;
using System.Collections.Generic;

namespace LanchoneteDextra.Application.Interface
{
    public interface ILancheAppService : IAppServiceBase<Lanche>
    {
        new IEnumerable<Lanche> GetAll();
        new Lanche GetById(string id);
        Pedido[] CalcPadrao(Pedido[] pedido);
    }
}