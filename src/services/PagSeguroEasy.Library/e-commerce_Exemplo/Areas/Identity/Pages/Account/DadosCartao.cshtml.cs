using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using msShop.Funcoes.PagSeguro;
using msShop.Models;
using msShop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Areas.Identity.Pages.Account
{
    public class CartaoCreditoModel : PageModel
    {

        public CartaoCreditoBLL cartaoCreditoUser;
        protected IdentityUser _user { get; set; }
        [BindProperty]
        public CartaoCredito DadosCartao { get; set; }

        public CartaoCreditoModel(IConfiguration configuration, CartaoCreditoBLL cartao,
                SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.cartaoCreditoUser = cartao;
            this._user = userManager.Users.FirstOrDefault();
            //this.DadosCartao = cartaoCreditoUser.GetCartaoCreditoByIdUser(this._user.Id);

        }
        public IActionResult OnGet()
        {
            DadosCartao = cartaoCreditoUser.GetCartaoCreditoByIdUser(_user.Id);
            return Page();
        }

        public IActionResult OnPost()
        {
            var dados = cartaoCreditoUser.GetCartaoCreditoByIdUser(_user.Id);
            if (ModelState.IsValid)
            {
                DadosCartao.CartaoId = dados.CartaoId;
                DadosCartao.UserId = _user.Id;
                var retorno = cartaoCreditoUser.InsertOuUpdateCartaoCredito(DadosCartao);
                return Page();
            }
            return Page();
        }

    }
}
