

namespace PagSeguroEasy.Library.Configurations
{
   public class GlobalConfiguration
    {
        public const string URLBASE = "https://ws.sandbox.pagseguro.uol.com.br";
        public const string CRIARSESSAO = "/v2/sessions?email={{email}}&token={{token}}";
        public const string MEIOSDEPAGAMENTOS = "/payment-methods?amount={{Valor}}&sessionId={{IdSessao}}";
        public const string BANDEIRACARTAO = "https://df.uol.com.br/df-fe/mvc/creditcard/v1/getBin?tk={{IdSessao}}&creditCard={{BinCartao}}";
        public const string OBTERTOKENCARTAO = "https://df.uol.com.br/v2/cards";
        public const string CONDICOESDEPARCELAMENTO = "https://sandbox.pagseguro.uol.com.br/checkout/v2/installments.json?sessionId={{IdSessao}}&amount={{Valor}}&creditCardBrand={{cardBrand}}";
        public const string CARTAODECREDITO = "https://ws.sandbox.pagseguro.uol.com.br/v2/transactions?email={{email}}&token={{token}}";
        public const string Email = "igorssadm2@gmail.com";
        public const string TokenSandBox = "81FA224D1C63427A89BE25F4BD67702A";
    }
    public class Currency
    {
        public const string Brl = "BRL";
    }

}
