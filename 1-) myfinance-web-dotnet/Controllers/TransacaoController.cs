    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using myfinance_web_dotnet_service.Interfaces;
    using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(
            ILogger<TransacaoController> logger, 
            ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaTransacoes = _transacaoService.ListarRegistros();
            List<TransacaoModel> listaTransacoesModel = new List<TransacaoModel>();
            foreach (var item in listaTransacoes)
            {
                listaTransacoesModel.Add(new TransacaoModel()
                {
                    Id = item.Id,
                    Historico = item.Historico,
                    Data = item.Data,
                    Valor = item.Valor,
                    Tipo = item.PlanoConta.Tipo,
                    PlanoContaId = item.PlanoContaId
                });
            }

            ViewBag.ListaTransacao = listaTransacoesModel;

            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(int? Id)
        {
            if (Id != null)
            {
                var transacao = _transacaoService.RetornarRegistro((int)Id);            
                var transacaoModel = new TransacaoModel()
                {
                    Id = transacao.Id,
                    Historico = transacao.Historico,
                    Data = transacao.Data,
                    Valor = transacao.Valor,
                    PlanoContaId = transacao.PlanoContaId
                };
           
                return View(transacaoModel);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(TransacaoModel model)
        {                     
            var transacao = new Transacao()
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId
            };

            _transacaoService.Cadastrar(transacao);            
            return RedirectToAction("Index");
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}