using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using msShop.Funcoes.PagSeguro;
using msShop.Models;
using msShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly ShoppingCart _carrinho;
        private readonly AppDbContext _contextoBancodeDados;
        public CartaoCreditoBLL _cartaoCreditoUser;
        public DadosUsuarioBLL _dadosUsuarioBll;
        public PedidoVieoModel pedidoVieoModel { get; set; }

        public IdentityUser _User { get; set; }
        public PedidoController(IPedidoRepositorio pedidoRepositorio, ShoppingCart carrinho, AppDbContext contextoBancodeDados,
            UserManager<IdentityUser> userManager, CartaoCreditoBLL cartao, DadosUsuarioBLL dadosUsuario)
        {
            _dadosUsuarioBll = dadosUsuario;
            _cartaoCreditoUser = cartao;
            _pedidoRepositorio = pedidoRepositorio;
            _carrinho = carrinho;
            _contextoBancodeDados = contextoBancodeDados;
            this._User = userManager.Users.FirstOrDefault();

        }


        public IActionResult Checkout()
        {
            pedidoVieoModel = new PedidoVieoModel();
            pedidoVieoModel.DadosUsuario = _dadosUsuarioBll.GetDadosUsuarioByIdUser(_User.Id);

            return View(pedidoVieoModel);
        }

        public IActionResult CheckoutPag()
        {
            pedidoVieoModel = new PedidoVieoModel();
            pedidoVieoModel.DadosUsuario = _dadosUsuarioBll.GetDadosUsuarioByIdUser(_User.Id);
            var dadosCartao = _cartaoCreditoUser.GetCartaoCreditoByIdUser(_User.Id);

            pedidoVieoModel.CartaoCredito = new CartaoCreditoViwelModel()
            {
                CartaoId = dadosCartao.CartaoId,
                UserId = dadosCartao.UserId,
                NomeCartao = dadosCartao.NomeCartao,
                DataValidade = dadosCartao.DataValidade,
                NumeroCartao = dadosCartao.NumeroCartao
            };
            return View(pedidoVieoModel);
        }

        [HttpPost]
        public IActionResult Checkout(PedidoVieoModel pedido)
        {
            _carrinho.CarrinhoItens = _carrinho.GetShoppingCartItens();

            if (_carrinho.CarrinhoItens.Count < 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio");
            }

            if (ModelState.IsValid)
            {
                _pedidoRepositorio.CriarPedido(pedido.pedido);
                _carrinho.LimparCarrinho();
                return RedirectToAction("CheckoutComplete");
            }

            return View(pedido);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Seu pedido foi incluido com sucesso. Obrigado!";
            return View();

        }

    }
}
