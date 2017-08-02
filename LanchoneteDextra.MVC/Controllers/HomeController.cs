using LanchoneteDextra.Application.Interface;
using LanchoneteDextra.Domain.Entities;
using LanchoneteDextra.MVC.Util;
using System.Web.Mvc;

namespace LanchoneteDextra.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheAppService _lancheApp;

        public HomeController(ILancheAppService lancheApp)
        {
            _lancheApp = lancheApp;
        }

        public ActionResult Index()
        {
            return View(_lancheApp.GetAll());
        }

        [HttpPost]
        public ActionResult ConfirmarPedido(Pedido[] pedido)
        {
            return PartialView("_Pedido", new CalcValorLanche(_lancheApp).CalcPadrao(pedido));            
        }
    }
}