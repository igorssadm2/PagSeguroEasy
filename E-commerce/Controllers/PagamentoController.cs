using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using msShop.Funcoes.PagSeguro;
using msShop.Models;
using msShop.Models.DTO;
using PagSeguroEasy.Library.Entitys;
using PagSeguroEasy.Library.InputModels;
using PagSeguroEasy.Library.Services;
using PagSeguroEasy.Library.ViewModels;
using static msShop.Models.PagCondicoesParcelamento;
using static PagSeguroEasy.Library.Models.PagSeguroSessao;

namespace msShop.Controllers
{
    [Route("api/pagamento")]
    [ApiController]
    public class PagamentoController : BaseController
    {
        protected PagSeguroBLL _pagSeguroBLL { get; set; }
        private readonly ICriarSessaoService _criarSessaoService;
        private readonly IObterMeiosPagamentoService _obterMeiosPagamentoService;
        private readonly IObterBandeiraCartaoService _obterBandeiraCartaoService;
        private readonly IObterCondicoesParcelamentoService _obterCondicoesParcelamentoService;
        private readonly IObterTokenCartaoService _obterTokenCartaoService;

        public PagamentoController(IConfiguration configuration, PagSeguroBLL pagSeguro, ShoppingCart shoppingCart,
           SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
           ICriarSessaoService criarSessaoService, IObterMeiosPagamentoService obterMeiosPagamentoService,
           IObterBandeiraCartaoService obterBandeiraCartaoService, IObterCondicoesParcelamentoService obterCondicoesParcelamentoService,
           IObterTokenCartaoService obterTokenCartaoService) : base(configuration, signInManager, userManager)
        {
            _pagSeguroBLL = pagSeguro;
            _criarSessaoService = criarSessaoService;
            _obterMeiosPagamentoService = obterMeiosPagamentoService;
            _obterBandeiraCartaoService = obterBandeiraCartaoService;
            _obterCondicoesParcelamentoService = obterCondicoesParcelamentoService;
            _obterTokenCartaoService = obterTokenCartaoService;

        }

        [Route("criarsessao")]
        [HttpPost]
        public session CriarSessao()
        {
            var email = "igorssadm2@gmail.com";
            var token = "81FA224D1C63427A89BE25F4BD67702A";
            return _criarSessaoService.CriarSessao(email, token);
        }

        [Route("obtermeiosdepagamento")]
        [HttpGet]
        public PagMeiosPagamentos ObterMeiosdePagamento(decimal valor, string IdSessao)
        {
            return _obterMeiosPagamentoService.ObterMeiosdePagamento(valor, IdSessao);
        }
        [Route("obterbandeiracartao")]
        [HttpGet]
        public PagBandeiraCartaoViewModel ObterBandeiraCartao(string IdSessao, string BinCartao)
        {
            return _obterBandeiraCartaoService.ObterBandeiraCartao(IdSessao, BinCartao);
        }
        
        [Route("obtertokencartao")]
        [HttpPost]
        public card ObterTokenCartao(ObterTokenCartaoInputModel obterTokenDTO)
        {
            return _obterTokenCartaoService.ObterTokenCartao(obterTokenDTO);
        }

        [Route("obtercondicoesparcelamento")]
        [HttpGet]
        public PagCondicoesParcelamentoViewModel ObterCondicoesParcelamento(decimal valor, string IdSessao, string creditCardBrand)
        {
            return _obterCondicoesParcelamentoService.ObterCondicoesParcelamento(valor, IdSessao, creditCardBrand);
        }

        [Route("transactions/cartaocredito")]
        [HttpPost]
        public ReturnPagamentoDTO PagtoCartaoCredito(string cardtoken,string ValorFrete, int tipoFrete, int quantity, float installmentAmount, float totalAmount, bool interestFree)
        {
            CondicoesParcelamento condicoesParcelamento = new CondicoesParcelamento()
            {
                installmentAmount = installmentAmount,
                interestFree = interestFree,
                quantity = quantity,
                totalAmount = totalAmount
            };
     
            return _pagSeguroBLL.PagamentoCartaoCredito(cardtoken, _user.Id, _user.Email, ValorFrete, tipoFrete, condicoesParcelamento);

        }
        [Route("transactions/boleto")]
        [HttpPost]
        public ReturnPagamentoDTO PagtoBoleto(string token, string email, string cardToken, string ValorFrete, int tipoFrete)
        {
           
            return _pagSeguroBLL.PagamentoBoleto(token, email,  cardToken, _user.Id, _user.Email, ValorFrete, tipoFrete);

        }
        [Route("transactions/debitoonline")]
        [HttpPost]
        public ReturnPagamentoDTO PagtoCartaoDebito(string token, string email, string cardToken, string ValorFrete, int tipoFrete, string nomeBanco)
        {
            return _pagSeguroBLL.PagamentoCartaoDebito(token, email, cardToken, _user.Id, _user.Email, ValorFrete, tipoFrete, nomeBanco);

        }


    }
}
