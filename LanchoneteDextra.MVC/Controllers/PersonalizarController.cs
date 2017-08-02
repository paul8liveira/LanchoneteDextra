using LanchoneteDextra.Application.Interface;
using LanchoneteDextra.Domain.Entities;
using LanchoneteDextra.MVC.Util;
using System.Web.Mvc;

namespace LanchoneteDextra.MVC.Controllers
{
    public class PersonalizarController : Controller
    {
        private readonly IIngredienteAppService _ingredienteApp;

        public PersonalizarController(IIngredienteAppService ingredienteApp)
        {
            _ingredienteApp = ingredienteApp;
        }

        public ActionResult Index()
        {
            return View(_ingredienteApp.GetAll());
        }

        [HttpPost]
        public ActionResult ConfirmarPedido(IngredientePersonalizado[] ingredientePersonalizado)
        {
            return PartialView("_Pedido", new CalcValorLanche(_ingredienteApp, ingredientePersonalizado).CalcPersonalizado());
        }
    }
}