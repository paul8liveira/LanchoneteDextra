using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanchoneteDextra.Domain.Entities
{
    public class Pedido
    {
        public string IdLanche { get; set; }
        public string NomeLanche { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
