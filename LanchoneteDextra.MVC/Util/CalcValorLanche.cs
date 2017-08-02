using LanchoneteDextra.Application.Interface;
using LanchoneteDextra.Domain.Entities;
using System;
using System.Linq;

namespace LanchoneteDextra.MVC.Util
{
    public class CalcValorLanche
    {
        private readonly ILancheAppService _lancheApp;
        private readonly IIngredienteAppService _ingredienteApp;
        private IngredientePersonalizado[] _ingredientePersonalizado;
        private const decimal DESCONTO = 0.10M;

        public CalcValorLanche(ILancheAppService lancheApp)
        {
            _lancheApp = lancheApp;
            _ingredienteApp = null;
        }
        public CalcValorLanche(IIngredienteAppService ingredienteApp, IngredientePersonalizado[] ingredientePersonalizado)
        {
            _lancheApp = null;
            _ingredienteApp = ingredienteApp;
            _ingredientePersonalizado = ingredientePersonalizado;
        }

        public Pedido[] CalcPadrao(Pedido[] pedido)
        {
            foreach(var item in pedido)
            {
                var lanche = _lancheApp.GetById(item.IdLanche);
                item.Valor = lanche.Ingredientes.AsEnumerable().Sum(s => s.Valor) * item.Quantidade;
                item.NomeLanche = lanche.Nome;
            }
            return pedido;
        }

        public Pedido[] CalcPersonalizado()
        {
            foreach (var item in _ingredientePersonalizado)
            {
                var ingrediente = _ingredienteApp.GetById(item.IdIngrediente);

                //atende ao requisito de muita carne e muito queijo, como o cliente seleciona a quantidade de cada item, bastou multiplicar o valor
                //do ingrediente pela quantidade selecionada seguindo a regra de desconto a cada 3 porcoes
                if (item.IdIngrediente.Equals("hamburguer") || item.IdIngrediente.Equals("queijo"))
                {
                    item.Valor = ingrediente.Valor * (item.Quantidade % 3 == 0 ? (item.Quantidade - (item.Quantidade / 3)) : item.Quantidade);
                }
                else
                {
                    item.Valor = ingrediente.Valor * item.Quantidade;
                }
                item.NomeIngrediente = ingrediente.Nome;                
            }

            Pedido[] pedido = new Pedido[]             
            {
                new Pedido
                {
                    IdLanche = "personalizado",
                    NomeLanche = "Lanche personalizado",
                    Quantidade = 1,
                    Valor = ValorPedidoPersonalizado()
                }
            };
            return pedido;
        }

        private decimal ValorPedidoPersonalizado()
        {
            decimal valorPedido = _ingredientePersonalizado.Sum(s => s.Valor);
            return valorPedido - (TemDesconto() ? valorPedido * DESCONTO : 0);
        }

        private bool TemDesconto()
        {
            int alface = _ingredientePersonalizado.Count(c => c.IdIngrediente.Equals("alface"));
            int bacon = _ingredientePersonalizado.Count(c => c.IdIngrediente.Equals("bacon"));
            return (alface > 0 && bacon == 0);
        }
    }
}