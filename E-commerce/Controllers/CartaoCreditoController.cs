using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using msShop.Funcoes.PagSeguro;
using msShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Controllers
{
    public class CartaoCreditoController : BaseController
    {
        protected CartaoCreditoBLL cartaoCreditoUser;

        public CartaoCreditoController(IConfiguration configuration, CartaoCreditoBLL cartao,
            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) : base(configuration, signInManager, userManager)
        {
            this.cartaoCreditoUser = cartao;

        }
        public IActionResult Index()
        {
            var cartao = cartaoCreditoUser.GetCartaoCreditoByIdUser(this._user.Id);
            return View(cartao);
        }
        [HttpPost]
        public IActionResult Cadastrar(CartaoCredito cartaoCredito)
        {
            var cartao = cartaoCreditoUser.InsertOuUpdateCartaoCredito(cartaoCredito);

            return RedirectToAction("Index");
        }
    }
}
