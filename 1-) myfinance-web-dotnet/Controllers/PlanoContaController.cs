    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using myfinance_web_dotnet_service.Interfaces;
    using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        // private readonly IPlanoContaService _planoContaService;
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _planoContaService;

        public PlanoContaController(
            ILogger<PlanoContaController> logger, 
            IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaPlanoContas = _planoContaService.ListarRegistros();
            List<PlanoContaModel> listaPlanoContasModel = new List<PlanoContaModel>();
            foreach (var item in listaPlanoContas)
            {
                listaPlanoContasModel.Add(new PlanoContaModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                });
            }

            ViewBag.ListaPlanoConta = listaPlanoContasModel;

            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(int? Id)
        {
            if (Id != null)
            {
                var planoConta = _planoContaService.RetornarRegistro((int)Id);

                var planoContaModel = new PlanoContaModel()
                {
                    Id = planoConta.Id,
                    Descricao = planoConta.Descricao,
                    Tipo = planoConta.Tipo
                };

                return View(planoContaModel);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(PlanoContaModel model)
        {
            var planoConta = new PlanoConta()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo
            };

            _planoContaService.Cadastrar(planoConta);            
            return RedirectToAction("Index");
        }        


        [HttpGet]
        [Route("Excluir/{Id}")]
        public IActionResult Excluir(int? Id)
        {
            _planoContaService.Excluir((int)Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}