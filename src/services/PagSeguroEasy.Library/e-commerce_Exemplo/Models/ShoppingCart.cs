using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _contextoBancodeDados;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> CarrinhoItens { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession sessao = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var contexto = services.GetService<AppDbContext>();
            string cartId = sessao.GetString("CartId");
            if(cartId == null)
                cartId = Guid.NewGuid().ToString();
            
            sessao.SetString("CartId", cartId);

            return new ShoppingCart(contexto) { ShoppingCartId = cartId };
        }


        public ShoppingCart(AppDbContext contextoBancodeDados)
        {
            _contextoBancodeDados = contextoBancodeDados;
        }
        public void AdicionarItemCarrinho(Produto produto, int quantidade)
        {
            var ItemCarrinho = _contextoBancodeDados.ShoppingCartItens.SingleOrDefault(s => s.Produto.ProdutoId == produto.ProdutoId && s.ShoppingCartId == ShoppingCartId);

            if (ItemCarrinho == null)
            {
                ItemCarrinho = new ShoppingCartItem 
                {
                    ShoppingCartId = ShoppingCartId,
                    Produto = produto,
                    Quantidade = quantidade,
                    altura = produto.altura,
                    largura = produto.largura,
                    comprimento = produto.comprimento,
                    Peso = produto.Peso
                };

                _contextoBancodeDados.ShoppingCartItens.Add(ItemCarrinho);
            }
            else
            {
                ItemCarrinho.Quantidade++;
            }

            _contextoBancodeDados.SaveChanges();
        }

        public int RemoverItemCarrinho(Produto produto)
        {
            var shoppingCartItem = _contextoBancodeDados.ShoppingCartItens.SingleOrDefault(s => s.Produto.ProdutoId == produto.ProdutoId && s.ShoppingCartId == ShoppingCartId);
            var QuantidadeLocal = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantidade > 1)
                {
                    shoppingCartItem.Quantidade--;
                    QuantidadeLocal = shoppingCartItem.Quantidade;
                }
                else
                {
                    _contextoBancodeDados.ShoppingCartItens.Remove(shoppingCartItem);
                }
            }

            _contextoBancodeDados.SaveChanges();
            return QuantidadeLocal;
        }

        public List<ShoppingCartItem> GetShoppingCartItens()
        {
            var CarrinhoItens =  _contextoBancodeDados.ShoppingCartItens.Where(c => c.ShoppingCartId == ShoppingCartId).Include(p => p.Produto).ToList();
            return CarrinhoItens;

        }

        public void LimparCarrinho()
        {
            var ItensCarrinho = _contextoBancodeDados.ShoppingCartItens.Where(c => c.ShoppingCartId == ShoppingCartId);
            _contextoBancodeDados.ShoppingCartItens.RemoveRange(ItensCarrinho);
            _contextoBancodeDados.SaveChanges();
        }

        public decimal TotalCarrinho()
        {
            var total = _contextoBancodeDados.ShoppingCartItens.Where(c => c.ShoppingCartId == ShoppingCartId).Select(p => p.Produto.Preco * p.Quantidade).Sum();

            return total;
        }

        public List<Produto> GetListProdutoByIdShoppingCartID()
        {
            var produtos = _contextoBancodeDados.ShoppingCartItens
                                                .Where(c => c.ShoppingCartId == ShoppingCartId)
                                                .Include("Produto").ToList();
            return new List<Produto>();

        }

    }
}
