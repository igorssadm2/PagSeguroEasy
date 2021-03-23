using Microsoft.AspNetCore.Mvc;
using msShop.Models;
using msShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _carrinho;

        public ShoppingCartSummary(ShoppingCart carrinho)
        {
            _carrinho = carrinho;
        }

        public IViewComponentResult Invoke()
        {
            _carrinho.CarrinhoItens = _carrinho.GetShoppingCartItens();

            var shoppingCartViewModel = new CarrinhoViewModel
            {
                ShoppingCart = _carrinho,
                CarrinhoTotal = _carrinho.TotalCarrinho()
            };

            return View(shoppingCartViewModel);

        }


    }
}
