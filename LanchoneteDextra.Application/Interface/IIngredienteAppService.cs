using LanchoneteDextra.Domain.Entities;
using System.Collections.Generic;

namespace LanchoneteDextra.Application.Interface
{
    public interface IIngredienteAppService : IAppServiceBase<Ingrediente>
    {
        new IEnumerable<Ingrediente> GetAll();
        new Ingrediente GetById(string id);
    }
}