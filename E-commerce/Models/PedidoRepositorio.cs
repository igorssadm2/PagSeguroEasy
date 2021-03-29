using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public class PedidoRepositorio : IPedidoRepositorio
    {

        private readonly AppDbContext _contextoBancodeDados;
        private readonly ShoppingCart _shoppingCart;


        public PedidoRepositorio(AppDbContext contextoBancodeDados, ShoppingCart shoppingCart)
        {
            _contextoBancodeDados = contextoBancodeDados;
            _shoppingCart = shoppingCart;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.DataPedido = DateTime.Now;
            pedido.TotalPedido = _shoppingCart.TotalCarrinho();
            _contextoBancodeDados.Pedidos.Add(pedido);
            _contextoBancodeDados.SaveChanges();

            var CarrinhoItens = _shoppingCart.GetShoppingCartItens();

            foreach(var carrinhoItem in CarrinhoItens)
            {
                var pedidoDetalhe = new PedidoDetalhe
                {
                    Quantidade = carrinhoItem.Quantidade,
                    Preco = carrinhoItem.Produto.Preco,
                    ProdutoId = carrinhoItem.Produto.ProdutoId,
                    PedidoId = pedido.PedidoId
                };

                _contextoBancodeDados.PedidoDetalhes.Add(pedidoDetalhe);
            }
            _contextoBancodeDados.SaveChanges();
        }
    }
}
