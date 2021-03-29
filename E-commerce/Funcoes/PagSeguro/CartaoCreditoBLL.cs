using msShop.Models;
using System;
using System.Linq;

namespace msShop.Funcoes.PagSeguro
{
    public class CartaoCreditoBLL : FuncoesBase
    {
        public CartaoCreditoBLL(AppDbContext contextoBancodeDados) : base(contextoBancodeDados)
        {

        }

        public CartaoCredito GetCartaoCreditoByIdCard(Guid IdCartao)
        {
            var cartao = this.bancodeDados.CartaoCredito.Where(x => x.CartaoId == IdCartao).FirstOrDefault();
            return cartao;
        }
        public CartaoCredito GetCartaoCreditoByIdUser(string Iduser)
        {
            var cartao = this.bancodeDados.CartaoCredito.Where(x => x.UserId == Iduser).FirstOrDefault();
            if (cartao == null)
            {
                cartao = new CartaoCredito();
                cartao.UserId = Iduser;
            }
            return cartao;
        }

        public CartaoCredito InsertOuUpdateCartaoCredito(CartaoCredito cartaoCredito)
        {
            var CartaoSave = cartaoCredito;
            var cartao = this.bancodeDados.CartaoCredito.Where(x => x.UserId == cartaoCredito.UserId).FirstOrDefault();
            if (cartao != null)
                this.bancodeDados.Entry(cartao).CurrentValues.SetValues(CartaoSave);
            else
                this.bancodeDados.CartaoCredito.Add(cartaoCredito);

            this.bancodeDados.SaveChanges();
            return cartaoCredito;
        }
    }
}
