using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanchoneteDextra.Domain.Entities
{
    public class IngredientePersonalizado
    {
        public string IdIngrediente { get; set; }
        public string NomeIngrediente { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
