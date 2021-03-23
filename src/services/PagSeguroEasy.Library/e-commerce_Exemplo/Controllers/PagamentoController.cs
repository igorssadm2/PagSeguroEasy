using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using msShop.Funcoes.PagSeguro;
using msShop.Models;
using msShop.Models.DTO;
using msShop.TagHelpers.Enum;
using static msShop.Models.PagamentoPagSeguro;
using static msShop.Models.PagCondicoesParcelamento;

namespace msShop.Controllers
{
    [Route("api/pagamento")]
    [ApiController]
    public class PagamentoController : BaseController
    {
        protected PagSeguroBLL _pagSeguroBLL { get; set; }

        public PagamentoController(IConfiguration configuration, PagSeguroBLL pagSeguro, ShoppingCart shoppingCart,
           SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) : base(configuration, signInManager, userManager)
        {
            _pagSeguroBLL = pagSeguro;

        }

        [Route("criarsessao")]
        [HttpPost]
        public session CriarSessao()
        {
            var email = "igorssadm2@gmail.com";
            var token = "81FA224D1C63427A89BE25F4BD67702A";
            return _pagSeguroBLL.CriarSessao(email, token);
        }

        [Route("obtermeiosdepagamento")]
        [HttpGet]
        public PagMeiosPagamento ObterMeiosdePagamento(decimal valor, string IdSessao)
        {
            return _pagSeguroBLL.ObterMeiosdePagamento(valor, IdSessao);
        }
        [Route("obterbandeiracartao")]
        [HttpGet]
        public PagBandeiraCartao ObterBandeiraCartao(string IdSessao, string BinCartao)
        {
            return _pagSeguroBLL.ObterBandeiraCartao(IdSessao, BinCartao);
        }
        
        [Route("obtertokencartao")]
        [HttpPost]
        public card ObterTokenCartao(ObterTokenDTO obterTokenDTO)
        {
            return _pagSeguroBLL.ObterTokenCartao(obterTokenDTO);
        }

        [Route("obtercondicoesparcelamento")]
        [HttpGet]
        public PagCondicoesParcelamento ObterCondicoesParcelamento(decimal valor, string IdSessao, string creditCardBrand)
        {
            return _pagSeguroBLL.ObterCondicoesParcelamento(valor, IdSessao, creditCardBrand);
        }

        [Route("transactions/cartaocredito")]
        [HttpPost]
        public ReturnPagamentoDTO PagtoCartaoCredito(string token, string email, string cardtoken,string ValorFrete, int tipoFrete, int quantity, float installmentAmount, float totalAmount, bool interestFree)
        {
            CondicoesParcelamento condicoesParcelamento = new CondicoesParcelamento()
            {
                installmentAmount = installmentAmount,
                interestFree = interestFree,
                quantity = quantity,
                totalAmount = totalAmount
            };
     
            return _pagSeguroBLL.PagamentoCartaoCredito(token, email, cardtoken, _user.Id, _user.Email, ValorFrete, tipoFrete, condicoesParcelamento);

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
