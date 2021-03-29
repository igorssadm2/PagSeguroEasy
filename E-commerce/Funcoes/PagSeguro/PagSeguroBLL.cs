using msShop.Models;
using msShop.Models.DTO;
using msShop.TagHelpers.Enum;
using PagSeguroEasy.Library.Configurations;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using static msShop.Models.PagCondicoesParcelamento;

namespace msShop.Funcoes.PagSeguro
{
    public class PagSeguroBLL : FuncoesBase
    {
        public DadosUsuarioBLL _dadosUsuarioBLL { get; set; }
        public CartaoCreditoBLL _cartaoCreditoBLL { get; set; }
        public ShoppingCart _Carrinho { get; set; }
        public PagSeguroBLL(AppDbContext contextoBancodeDados, DadosUsuarioBLL dadosUsuario, ShoppingCart carrinho, CartaoCreditoBLL cartaoCreditoBLL) : base(contextoBancodeDados)
        {
            _dadosUsuarioBLL = dadosUsuario;
            _Carrinho = carrinho;
            _cartaoCreditoBLL = cartaoCreditoBLL;
        }

        public ReturnPagamentoDTO PagamentoCartaoCredito(string cardtoken, string IdUser, string emailUser, string ValorFrete, int tipoFrete, CondicoesParcelamento condicoesParcelamento)
        {

            payment payment = GetPayment(IdUser, emailUser, cardtoken, ValorFrete, tipoFrete, condicoesParcelamento, MeioPagamentoEnum.creditCard, null);

            var URLBase = GlobalConfiguration.CARTAODECREDITO.Replace("{{email}}", GlobalConfiguration.Email).Replace("{{token}}", GlobalConfiguration.TokenSandBox);

            var retorno = ExecutePOSTWebAPI(URLBase, payment);
            return retorno;
        }

        public ReturnPagamentoDTO PagamentoCartaoDebito(string token, string email, string cardToken, string IdUser, string emailUser, string ValorFrete, int tipoFrete, string nomeBanco)
        {

            var banck = new bank() { name = nomeBanco };
            payment payment = GetPayment(IdUser, emailUser, cardToken, ValorFrete, tipoFrete, null, MeioPagamentoEnum.eft, banck);

            var URLBase = GlobalConfiguration.CARTAODECREDITO.Replace("{{email}}", email).Replace("{{token}}", token);

            var retorno = ExecutePOSTWebAPI(URLBase, payment);
            return retorno;
        }
        public ReturnPagamentoDTO PagamentoBoleto(string token, string email, string cardToken, string IdUser, string emailUser, string ValorFrete, int tipoFrete)
        {

            payment payment = GetPayment(IdUser, emailUser, cardToken, ValorFrete, tipoFrete, null, MeioPagamentoEnum.boleto, null);

            var URLBase = GlobalConfiguration.CARTAODECREDITO.Replace("{{email}}", email).Replace("{{token}}", token);

            var retorno = ExecutePOSTWebAPI(URLBase, payment);
            return retorno;
        }

        public payment GetPayment(string IdUser, string emailUser, string cardToken, string ValorFrete, int tipoFrete, CondicoesParcelamento? condicoesParcelamento, MeioPagamentoEnum meioPagamento, bank? bank)
        {
            payment payment = new payment();
            payment.mode = "default";
          
            payment.method = meioPagamento.ToString();
            payment.currency = Currency.Brl;
            var dadosUser = this._dadosUsuarioBLL.GetDadosUsuarioByIdUser(IdUser);
            string tipoDoc = string.Empty;


            if (meioPagamento == MeioPagamentoEnum.eft)
            {
                payment.bank = new bank()
                {
                    name = bank.name
                };
            }
            if ((int)TipoDocumentoCPFCNPJ.CNPJ == dadosUser.TipoDocumento)
                tipoDoc = TipoDocumentoCPFCNPJ.CNPJ.ToString();
            else
                tipoDoc = TipoDocumentoCPFCNPJ.CPF.ToString();
            payment.sender = new sender()
            {
                email = emailUser,
                name = dadosUser.Nome,
                phone = new Phone()
                {
                    areaCode = dadosUser.CodigoArea,
                    number = dadosUser.NumeroTelefone
                }

            };
            var document = new document()
            {
                value = dadosUser.CPFCNPJ,
                type = tipoDoc
            };
            payment.sender.documents.Add(document);

            var itensCarrinho = _Carrinho.GetShoppingCartItens();
            //item NovoItem = new item();
            //NovoItem.id = "14004"; //itemCarrinho.ShoppingCartItemId.ToString();
            //NovoItem.description = "Halo Reach XBox 360";// itemCarrinho.Produto.Nome;
            //NovoItem.amount = 79.90M;// itemCarrinho.Produto.ValorBruto;
            //NovoItem.quantity = 1; //itemCarrinho.Produto.Quantidade;
            //payment.items.Add(NovoItem);

            if (itensCarrinho.Count > 0)
            {
                foreach (var itemCarrinho in itensCarrinho)
                {
                    //var listprodutos = _Carrinho.GetListProdutoByIdShoppingCartID();
                    item NovoItem = new item();
                    NovoItem.id = itemCarrinho.ShoppingCartItemId.ToString();
                    NovoItem.description = itemCarrinho.Produto.Nome;
                    NovoItem.amount = itemCarrinho.Produto.ValorBruto;
                    NovoItem.quantity = itemCarrinho.Produto.Quantidade;
                    payment.items.Add(NovoItem);

                }
            }
            if (meioPagamento == MeioPagamentoEnum.creditCard)
            {
                var cartaoCredito = this._cartaoCreditoBLL.GetCartaoCreditoByIdUser(IdUser);
                payment.creditCard = new creditCard()
                {
                    token = cardToken,
                    billingAddress = new Address()
                    {
                        street = dadosUser.Enderenco,
                        number = dadosUser.Numero.ToString(),
                        district = dadosUser.Bairro,
                        city = dadosUser.Cidade,
                        state = dadosUser.Estado,
                        country = "BRA",
                        postalCode = dadosUser.CEP,
                        complement = dadosUser.Complemento,
                    },
                    installment = new installment()
                    {
                        quantity = condicoesParcelamento.quantity,
                        value = condicoesParcelamento.totalAmount.ToString("F").Replace(",", ".")

                    },
                    holder = new holder()
                    {
                        name = cartaoCredito.NomeCartao,
                        phone = new Phone()
                        {
                            areaCode = dadosUser.CodigoArea,
                            number = dadosUser.NumeroTelefone
                        }

                    }
                };
                payment.creditCard.holder.documents.Add(document);
            }
            if (payment.shipping.addressRequired)
            {

                payment.shipping.street = dadosUser.Enderenco;
                payment.shipping.number = dadosUser.Numero.ToString();
                payment.shipping.district = dadosUser.Bairro;
                payment.shipping.city = dadosUser.Cidade;
                payment.shipping.state = dadosUser.Estado;
                payment.shipping.country = "BRA";
                payment.shipping.postalCode = dadosUser.CEP;
                payment.shipping.complement = dadosUser.Complemento;

            }
            payment.shipping.Cost = ValorFrete;
            payment.shipping.ShippingType = tipoFrete;

            payment.reference = Guid.NewGuid().ToString();
            //payment.receiverEmail = "emersonhsilva@gmail.com";
            //payment.receiverEmail = "https://www.gestaointeligentesoftware.com.br/";
            return payment;
        }

        public ReturnPagamentoDTO ExecutePOSTWebAPI(string resourceName, object classObj)
        {
            using (var client = new HttpClient())
            {
                //Bypass SSL Certificate if you want, otherwise remove this line of code
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, certificate, chain, sslPolicyErrors) => true;
                ReturnPagamentoDTO returnPagamentoDTO = new ReturnPagamentoDTO();

                var retornoserealizer = this.Serialize(classObj);
                var httpContent = new StringContent(retornoserealizer, Encoding.UTF8, "application/xml");
                var response = client.PostAsync(resourceName, httpContent).Result;
                var jsonString = response.Content.ReadAsStringAsync().Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    returnPagamentoDTO.transaction = Deserialize<ReturnPagamentoDTO.Transaction>(jsonString);

                    return returnPagamentoDTO;
                }
                else
                {
                    var retornoErro = Deserialize<Models.DTO.Errors>(jsonString);
                    returnPagamentoDTO.Errors = retornoErro;
                }

                return returnPagamentoDTO;
                //}
                //catch (Exception exp)
                //{
                //    return new ReturnPagamentoDTO();
                //}
            }
        }
        public string Serialize(object dataToSerialize)
        {
            if (dataToSerialize == null) return null;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            using (StringWriter stringwriter = new StringWriter())
            {
                // removes namespace

                var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                var serializer = new XmlSerializer(dataToSerialize.GetType(), "");

                var xw = XmlWriter.Create(stringwriter, settings);

                serializer.Serialize(xw, dataToSerialize, emptyNs);
                return stringwriter.ToString();
            }
        }
        public T Deserialize<T>(string input) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }
    }
}
