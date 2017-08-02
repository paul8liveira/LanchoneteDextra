using LanchoneteDextra.MVC.Util;
using LanchoneteDextra.Application.Interface;
using LanchoneteDextra.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using FluentAssertions;

namespace LanchoneteDextra.MVC.Util.Tests
{
    [TestClass()]
    public class CalcValorLancheTests
    {
        private Mock<ILancheAppService> mockLancheAppService;
        private Mock<IIngredienteAppService> mockIngredienteAppService;

        [TestInitialize]
        public void TestInitialize()
        {
            mockLancheAppService = new Mock<ILancheAppService>();
            mockIngredienteAppService = new Mock<IIngredienteAppService>();
        }

        #region Id dos lanches
        private const string IdXBacon = "xbacon";
        private const string IdXBurguer = "xburguer";
        private const string IdXEgg = "xegg";
        private const string IdXEggBacon = "xeggbacon";
        #endregion

        #region Id dos ingredientes
        private const string IdAlface = "alface";
        private const string IdBacon = "bacon";
        private const string IdHamburguer = "hamburguer";
        private const string IdOvo = "ovo";
        private const string IdQueijo = "queijo";
        #endregion


        #region Model para teste
        #region Cardapio
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
        #endregion

        #region Lanches
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
            Nome = "X-Burguer",
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

        #region Ingredientes
        private Ingrediente model_Alface = new Ingrediente()
        {
            Id = IdAlface,
            Nome = "Alface",
            Valor = 0.40M
        };
        private Ingrediente model_Bacon = new Ingrediente()
        {
            Id = IdBacon,
            Nome = "Bacon",
            Valor = 2
        };
        private Ingrediente model_Hamburguer = new Ingrediente()
        {
            Id = IdHamburguer,
            Nome = "Hamburguer de carne",
            Valor = 3
        };
        private Ingrediente model_Ovo = new Ingrediente()
        {
            Id = IdOvo,
            Nome = "Ovo",
            Valor = 0.80M
        };
        private Ingrediente model_Queijo = new Ingrediente()
        {
            Id = IdQueijo,
            Nome = "Queijo",
            Valor = 1.50M
        };

        #region Inflação
        private Ingrediente model_AlfaceInflacao = new Ingrediente()
        {
            Id = IdAlface,
            Nome = "Alface",
            Valor = 0.80M
        };
        private Ingrediente model_BaconInflacao = new Ingrediente()
        {
            Id = IdBacon,
            Nome = "Bacon",
            Valor = 4
        };
        private Ingrediente model_HamburguerInflacao = new Ingrediente()
        {
            Id = IdHamburguer,
            Nome = "Hamburguer de carne",
            Valor = 6.5M
        };
        private Ingrediente model_OvoInflacao = new Ingrediente()
        {
            Id = IdOvo,
            Nome = "Ovo",
            Valor = 1.80M
        };
        private Ingrediente model_QueijoInflacao = new Ingrediente()
        {
            Id = IdQueijo,
            Nome = "Queijo",
            Valor = 2.50M
        };
        #endregion

        #endregion

        #region Ingredientes Personalizados
        private IngredientePersonalizado[] model_IngredientePersonalizado_PrecoLight = new IngredientePersonalizado[]
        {
           new IngredientePersonalizado()
           {
               IdIngrediente = IdAlface,
               NomeIngrediente = "Alface",
               Quantidade = 1
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdHamburguer,
               NomeIngrediente = "Hamburguer",
               Quantidade = 1
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdOvo,
               NomeIngrediente = "Ovo",
               Quantidade = 1
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdQueijo,
               NomeIngrediente = "Queijo",
               Quantidade = 1
           },
        };
        private IngredientePersonalizado[] model_IngredientePersonalizado_PrecoMuitaCarne = new IngredientePersonalizado[]
        {
           new IngredientePersonalizado()
           {
               IdIngrediente = IdAlface,
               NomeIngrediente = "Alface",
               Quantidade = 1
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdBacon,
               NomeIngrediente = "Bacon",
               Quantidade = 1
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdHamburguer,
               NomeIngrediente = "Hamburguer",
               Quantidade = 3
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdOvo,
               NomeIngrediente = "Ovo",
               Quantidade = 1
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdQueijo,
               NomeIngrediente = "Queijo",
               Quantidade = 1
           },
        };
        private IngredientePersonalizado[] model_IngredientePersonalizado_PrecoMuitoQueijo = new IngredientePersonalizado[]
        {
           new IngredientePersonalizado()
           {
               IdIngrediente = IdAlface,
               NomeIngrediente = "Alface",
               Quantidade = 1
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdBacon,
               NomeIngrediente = "Bacon",
               Quantidade = 1
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdHamburguer,
               NomeIngrediente = "Hamburguer",
               Quantidade = 3
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdOvo,
               NomeIngrediente = "Ovo",
               Quantidade = 1
           },
           new IngredientePersonalizado()
           {
               IdIngrediente = IdQueijo,
               NomeIngrediente = "Queijo",
               Quantidade = 6
           },
        };
        #endregion

        #endregion

        #region Modelo para validação do teste
        #region Cardapio
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

        #region Personalizados
        Pedido[] model_IngredientePersonalizado_PrecoLightEsperado = new Pedido[]
        {
            new Pedido
            {
                IdLanche = "personalizado",
                NomeLanche = "Lanche personalizado",
                Quantidade = 1,
                Valor = 5.13M
            }
        };
        Pedido[] model_IngredientePersonalizado_PrecoMuitaCarneEsperado = new Pedido[]
        {
            new Pedido
            {
                IdLanche = "personalizado",
                NomeLanche = "Lanche personalizado",
                Quantidade = 1,
                Valor = 10.7M
            }
        };
        Pedido[] model_IngredientePersonalizado_PrecoMuitoQueijoEsperado = new Pedido[]
        {
            new Pedido
            {
                IdLanche = "personalizado",
                NomeLanche = "Lanche personalizado",
                Quantidade = 1,
                Valor = 15.2M
            }
        };

        #region Inflação
        Pedido[] model_IngredientePersonalizado_PrecoLightEsperadoInflacao = new Pedido[]
        {
            new Pedido
            {
                IdLanche = "personalizado",
                NomeLanche = "Lanche personalizado",
                Quantidade = 1,
                Valor = 10.44M
            }
        };
        #endregion

        #endregion

        #endregion

        [TestMethod()]
        public void CalcPadraoTest()
        {
            //Padrão AAA
            //Arrange            
            mockLancheAppService.Setup(s => s.GetById(IdXBacon)).Returns(model_XBacon);
            mockLancheAppService.Setup(s => s.GetById(IdXBurguer)).Returns(model_XBurguer);
            mockLancheAppService.Setup(s => s.GetById(IdXEgg)).Returns(model_XEgg);
            mockLancheAppService.Setup(s => s.GetById(IdXEggBacon)).Returns(model_XEggBacon);

            var calcValorLanche = new CalcValorLanche(mockLancheAppService.Object);

            //Act
            var resultado = calcValorLanche.CalcPadrao(model_PedidoPadrao);

            //Acert
            CollectionAssert.AllItemsAreNotNull(resultado);
            resultado.ShouldBeEquivalentTo(model_PedidoPadraoEsperado);
        }

        [TestMethod()]
        public void CalcPersonalizadoPrecoLigthTest()
        {
            //Padrão AAA
            //Arrange            
            mockIngredienteAppService.Setup(s => s.GetById(IdAlface)).Returns(model_Alface);
            mockIngredienteAppService.Setup(s => s.GetById(IdBacon)).Returns(model_Bacon);
            mockIngredienteAppService.Setup(s => s.GetById(IdHamburguer)).Returns(model_Hamburguer);
            mockIngredienteAppService.Setup(s => s.GetById(IdOvo)).Returns(model_Ovo);
            mockIngredienteAppService.Setup(s => s.GetById(IdQueijo)).Returns(model_Queijo);

            var calcValorLanche = new CalcValorLanche(mockIngredienteAppService.Object, model_IngredientePersonalizado_PrecoLight);

            //Act
            var resultado = calcValorLanche.CalcPersonalizado();

            //Acert
            CollectionAssert.AllItemsAreNotNull(resultado);
            resultado.ShouldBeEquivalentTo(model_IngredientePersonalizado_PrecoLightEsperado);
        }

        [TestMethod()]
        public void CalcPersonalizadoPrecoMuitaCarneTest()
        {
            //Padrão AAA
            //Arrange            
            mockIngredienteAppService.Setup(s => s.GetById(IdAlface)).Returns(model_Alface);
            mockIngredienteAppService.Setup(s => s.GetById(IdBacon)).Returns(model_Bacon);
            mockIngredienteAppService.Setup(s => s.GetById(IdHamburguer)).Returns(model_Hamburguer);
            mockIngredienteAppService.Setup(s => s.GetById(IdOvo)).Returns(model_Ovo);
            mockIngredienteAppService.Setup(s => s.GetById(IdQueijo)).Returns(model_Queijo);

            var calcValorLanche = new CalcValorLanche(mockIngredienteAppService.Object, model_IngredientePersonalizado_PrecoMuitaCarne);

            //Act
            var resultado = calcValorLanche.CalcPersonalizado();

            //Acert
            CollectionAssert.AllItemsAreNotNull(resultado);
            resultado.ShouldBeEquivalentTo(model_IngredientePersonalizado_PrecoMuitaCarneEsperado);
        }

        [TestMethod()]
        public void CalcPersonalizadoPrecoMuitoQueijoTest()
        {
            //Padrão AAA
            //Arrange            
            mockIngredienteAppService.Setup(s => s.GetById(IdAlface)).Returns(model_Alface);
            mockIngredienteAppService.Setup(s => s.GetById(IdBacon)).Returns(model_Bacon);
            mockIngredienteAppService.Setup(s => s.GetById(IdHamburguer)).Returns(model_Hamburguer);
            mockIngredienteAppService.Setup(s => s.GetById(IdOvo)).Returns(model_Ovo);
            mockIngredienteAppService.Setup(s => s.GetById(IdQueijo)).Returns(model_Queijo);

            var calcValorLanche = new CalcValorLanche(mockIngredienteAppService.Object, model_IngredientePersonalizado_PrecoMuitoQueijo);

            //Act
            var resultado = calcValorLanche.CalcPersonalizado();

            //Acert
            CollectionAssert.AllItemsAreNotNull(resultado);
            resultado.ShouldBeEquivalentTo(model_IngredientePersonalizado_PrecoMuitoQueijoEsperado);
        }

        [TestMethod()]
        public void CalcPersonalizadoPrecoLigthInflacaoTest()
        {
            //Padrão AAA
            //Arrange            
            mockIngredienteAppService.Setup(s => s.GetById(IdAlface)).Returns(model_AlfaceInflacao);
            mockIngredienteAppService.Setup(s => s.GetById(IdBacon)).Returns(model_BaconInflacao);
            mockIngredienteAppService.Setup(s => s.GetById(IdHamburguer)).Returns(model_HamburguerInflacao);
            mockIngredienteAppService.Setup(s => s.GetById(IdOvo)).Returns(model_OvoInflacao);
            mockIngredienteAppService.Setup(s => s.GetById(IdQueijo)).Returns(model_QueijoInflacao);

            var calcValorLanche = new CalcValorLanche(mockIngredienteAppService.Object, model_IngredientePersonalizado_PrecoLight);

            //Act
            var resultado = calcValorLanche.CalcPersonalizado();

            //Acert
            CollectionAssert.AllItemsAreNotNull(resultado);
            resultado.ShouldBeEquivalentTo(model_IngredientePersonalizado_PrecoLightEsperadoInflacao);
        }
    }
}