using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanchoneteDextra.Domain.Entities
{
    public class Lanche
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public bool Personalizado { get; set; }
        public IEnumerable<Ingrediente> Ingredientes { get; set; }
    }
}
