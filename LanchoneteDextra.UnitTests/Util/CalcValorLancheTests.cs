using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using LanchoneteDextra.Application.Interface;
using LanchoneteDextra.Domain.Entities;

namespace LanchoneteDextra.MVC.Util.Tests
{
    [TestClass()]
    public class CalcValorLancheTests
    {
        #region Id dos lanches
        private const string IdXBacon = "xbacon";
        private const string IdXBurguer = "xburguer";
        private const string IdXEgg = "xegg";
        private const string IdXEggBacon = "xeggbacon";
        #endregion

        #region Model para teste
        private Pedido[] model_PedidoPadrao = new Pedido[]
        {
            new Pedido
            {
                IdLanche = IdXBacon,
                Quantidade = 1,
            },
            new Pedido
            {
                IdLanche = IdXBurguer,
                Quantidade = 1,
            },
            new Pedido
            {
                IdLanche = IdXEgg,
                Quantidade = 1,
            },
            new Pedido
            {
                IdLanche = IdXEggBacon,
                Quantidade = 1,
            }
        };

        private Lanche model_XBacon = new Lanche()
        {
            Id = IdXBacon,
            Nome = "X-Bacon",
            Personalizado = false,
            Ingredientes = new List<Ingrediente>() {
                new Ingrediente() {Id = "bacon", Nome = "Bacon", Valor = 2 },
                new Ingrediente() {Id = "hamburguer", Nome = "Hamburguer de carnes", Valor = 3 },
                new Ingrediente() {Id = "queijo", Nome = "Queijo", Valor = 1.5M },
            }
        };

        private Lanche model_XBurguer = new Lanche()
        {
            Id = "xburger",
            Nome = "X-Burger",
            Personalizado = false,
            Ingredientes = new List<Ingrediente>() {
                new Ingrediente() {Id = "hamburguer", Nome = "Hamburguer de carnes", Valor = 3 },
                new Ingrediente() {Id = "queijo", Nome = "Queijo", Valor = 1.5M },
            }
        };

        private Lanche model_XEgg = new Lanche()
        {
            Id = "xegg",
            Nome = "X-Egg",
            Personalizado = false,
            Ingredientes = new List<Ingrediente>() {
                new Ingrediente() {Id = "ovo", Nome = "Ovo", Valor = 0.80M },
                new Ingrediente() {Id = "hamburguer", Nome = "Hamburguer de carnes", Valor = 3 },
                new Ingrediente() {Id = "queijo", Nome = "Queijo", Valor = 1.5M },
            }
        };

        private Lanche model_XEggBacon = new Lanche()
        {
            Id = "xeggbacon",
            Nome = "X-Egg Bacon",
            Personalizado = false,
            Ingredientes = new List<Ingrediente>() {
                new Ingrediente() {Id = "ovo", Nome = "Ovo", Valor = 0.80M },
                new Ingrediente() {Id = "bacon", Nome = "Bacon", Valor = 2 },
                new Ingrediente() {Id = "hamburguer", Nome = "Hamburguer de carnes", Valor = 3 },
                new Ingrediente() {Id = "queijo", Nome = "Queijo", Valor = 1.5M },
            }
        };
        #endregion

        #region Modelo para validação do teste
        private Pedido[] model_PedidoPadraoEsperado = new Pedido[]
    {
            new Pedido
            {
                IdLanche = IdXBacon,
                NomeLanche = "X-Bacon",
                Quantidade = 1,
                Valor = 6.5M
            },
            new Pedido
            {
                IdLanche = IdXBurguer,
                NomeLanche = "X-Burguer",
                Quantidade = 1,
                Valor = 4.5M
            },
            new Pedido
            {
                IdLanche = IdXEgg,
                NomeLanche = "X-Egg",
                Quantidade = 1,
                Valor = 5.3M
            },
            new Pedido
            {
                IdLanche = IdXEggBacon,
                NomeLanche = "X-Egg Bacon",
                Quantidade = 1,
                Valor = 7.3M
            }
        };
        #endregion

        [TestMethod()]
        public void CalcPadraoTest()
        {
            Mock<ILancheAppService> mockLancheAppService = new Mock<ILancheAppService>();
            mockLancheAppService.Setup(s => s.GetById(IdXBacon)).Returns(model_XBacon);
            mockLancheAppService.Setup(s => s.GetById(IdXBurguer)).Returns(model_XBurguer);
            mockLancheAppService.Setup(s => s.GetById(IdXEgg)).Returns(model_XEgg);
            mockLancheAppService.Setup(s => s.GetById(IdXEggBacon)).Returns(model_XEggBacon);

            var calcValorLanche = new CalcValorLanche(mockLancheAppService.Object);
            var resultado = calcValorLanche.CalcPadrao(model_PedidoPadrao);
            CollectionAssert.AreEqual(resultado, model_PedidoPadraoEsperado);
        }
    }
}