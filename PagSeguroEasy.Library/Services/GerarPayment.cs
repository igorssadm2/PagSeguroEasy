
using PagSeguroEasy.Library.Configurations;
using PagSeguroEasy.Library.Entities;
using PagSeguroEasy.Library.Enums;
using System;
using System.Collections.Generic;
using static PagSeguroEasy.Library.ViewModels.PagCondicoesParcelamentoViewModel;

namespace PagSeguroEasy.Library.Services
{
    public class GerarPayment : IGerarPayment
    {
        public Payment GetPayment(string IdUser, string emailUser, string cardToken, string ValorFrete, int tipoFrete, CondicoesParcelamento? condicoesParcelamento, MeioPagamentoEnum meioPagamento, Bank? bank, DadosComprador dadosComprador, CartaoDeCredito cartaoDeCredito, List<ShoppingCarItems> itensCarrinho)
        {
            Payment payment = new Payment();
            payment.mode = "default";

            payment.method = meioPagamento.ToString();
            payment.currency = Currency.Brl;
            //var dadosUser = this._dadosUsuarioBLL.GetDadosUsuarioByIdUser(IdUser);
            string tipoDoc = string.Empty;


            if (meioPagamento == MeioPagamentoEnum.eft)
            {
                payment.bank = new Bank()
                {
                    Name = bank.Name
                };
            }
            if ((int)TipoDocumentoEnum.CNPJ == dadosComprador.TipoDocumento)
                tipoDoc = TipoDocumentoEnum.CNPJ.ToString();
            else
                tipoDoc = TipoDocumentoEnum.CPF.ToString();
            payment.sender = new Sender()
            {
                email = emailUser,
                name = dadosComprador.Nome,
                phone = new Phone()
                {
                    areaCode = dadosComprador.CodigoArea,
                    number = dadosComprador.NumeroTelefone
                }

            };
            var document = new SenderDocument()
            {
                value = dadosComprador.CPFCNPJ,
                type = tipoDoc
            };
            payment.sender.documents.Add(document);

            //  var itensCarrinho = _Carrinho.GetShoppingCartItens();
            Item NovoItem = new Item();
            NovoItem.id = "22";//itemCarrinho.ShoppingCartItemId.ToString();
            NovoItem.description = "Celular";//itemCarrinho.Produto.Nome;
            NovoItem.amount = 20; //itemCarrinho.Produto.ValorBruto;
            NovoItem.quantity = 1; //itemCarrinho.Produto.Quantidade;
            payment.items.Add(NovoItem);


            //if (itensCarrinho.Count > 0)
            //{
            //    foreach (var itemCarrinho in itensCarrinho)
            //    {
            //        //var listprodutos = _Carrinho.GetListProdutoByIdShoppingCartID();
            //        Item NovoItem = new Item();
            //        NovoItem.id = "22";//itemCarrinho.ShoppingCartItemId.ToString();
            //        NovoItem.description = "Celular";//itemCarrinho.Produto.Nome;
            //        NovoItem.amount = 20; //itemCarrinho.Produto.ValorBruto;
            //        NovoItem.quantity = 1; //itemCarrinho.Produto.Quantidade;
            //        payment.items.Add(NovoItem);

            //    }
            //}
            if (meioPagamento == MeioPagamentoEnum.creditCard)
            {
                //  var cartaoCredito = this._cartaoCreditoBLL.GetCartaoCreditoByIdUser(IdUser);
                payment.creditCard = new CreditCard()
                {
                    token = cardToken,
                    billingAddress = new Address()
                    {
                        street = dadosComprador.Enderenco,
                        number = dadosComprador.Numero.ToString(),
                        district = dadosComprador.Bairro,
                        city = dadosComprador.Cidade,
                        state = dadosComprador.Estado,
                        country = "BRA",
                        postalCode = dadosComprador.CEP,
                        complement = dadosComprador.Complemento,
                    },
                    installment = new Installment()
                    {
                        quantity = condicoesParcelamento.quantity,
                        value = condicoesParcelamento.totalAmount.ToString("F").Replace(",", ".")

                    },
                    holder = new Holder()
                    {
                        name = cartaoDeCredito.NomeCartao,
                        phone = new Phone()
                        {
                            areaCode = dadosComprador.CodigoArea,
                            number = dadosComprador.NumeroTelefone
                        }

                    }
                };
                payment.creditCard.holder.documents.Add(document);
            }
            if (payment.shipping.addressRequired)
            {

                payment.shipping.street = dadosComprador.Enderenco;
                payment.shipping.number = dadosComprador.Numero.ToString();
                payment.shipping.district = dadosComprador.Bairro;
                payment.shipping.city = dadosComprador.Cidade;
                payment.shipping.state = dadosComprador.Estado;
                payment.shipping.country = "BRA";
                payment.shipping.postalCode = dadosComprador.CEP;
                payment.shipping.complement = dadosComprador.Complemento;

            }
            payment.shipping.Cost = ValorFrete;
            payment.shipping.ShippingType = tipoFrete;

            payment.reference = Guid.NewGuid().ToString();
            //payment.receiverEmail = "emersonhsilva@gmail.com";
            //payment.receiverEmail = "https://www.gestaointeligentesoftware.com.br/";
            return payment;
        }

    }
}


