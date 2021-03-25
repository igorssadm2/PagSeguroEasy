

namespace PagSeguroEasy.Library.Entitys
{
    public class PagMeiosPagamentos
    {

        public bool error { get; set; }
        public Paymentmethods paymentMethods { get; set; }


        public class Paymentmethods
        {
            public BOLETO BOLETO { get; set; }
            public BALANCE BALANCE { get; set; }
            public ONLINE_DEBIT ONLINE_DEBIT { get; set; }
            public CREDIT_CARD CREDIT_CARD { get; set; }
            public DEPOSIT DEPOSIT { get; set; }
        }

        public class BOLETO
        {
            public string name { get; set; }
            public Options options { get; set; }
            public int code { get; set; }
        }

        public class Options
        {
            public BOLETO1 BOLETO { get; set; }
        }

        public class BOLETO1
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images images { get; set; }
        }

        public class Images
        {
            public SMALL SMALL { get; set; }
            public MEDIUM MEDIUM { get; set; }
        }

        public class SMALL
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class BALANCE
        {
            public string name { get; set; }
            public Options1 options { get; set; }
            public int code { get; set; }
        }

        public class Options1
        {
            public BALANCE1 BALANCE { get; set; }
        }

        public class BALANCE1
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public object images { get; set; }
        }

        public class ONLINE_DEBIT
        {
            public string name { get; set; }
            public Options2 options { get; set; }
            public int code { get; set; }
        }

        public class Options2
        {
            public BANCO_BRASIL BANCO_BRASIL { get; set; }
            public BANRISUL BANRISUL { get; set; }
            public BRADESCO BRADESCO { get; set; }
            public ITAU ITAU { get; set; }
        }

        public class BANCO_BRASIL
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images1 images { get; set; }
        }

        public class Images1
        {
            public SMALL1 SMALL { get; set; }
            public MEDIUM1 MEDIUM { get; set; }
        }

        public class SMALL1
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM1
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class BANRISUL
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images2 images { get; set; }
        }

        public class Images2
        {
            public SMALL2 SMALL { get; set; }
            public MEDIUM2 MEDIUM { get; set; }
        }

        public class SMALL2
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM2
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class BRADESCO
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images3 images { get; set; }
        }

        public class Images3
        {
            public SMALL3 SMALL { get; set; }
            public MEDIUM3 MEDIUM { get; set; }
        }

        public class SMALL3
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM3
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class ITAU
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images4 images { get; set; }
        }

        public class Images4
        {
            public SMALL4 SMALL { get; set; }
            public MEDIUM4 MEDIUM { get; set; }
        }

        public class SMALL4
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM4
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class CREDIT_CARD
        {
            public string name { get; set; }
            public Options3 options { get; set; }
            public int code { get; set; }
        }

        public class Options3
        {
            public AMEX AMEX { get; set; }
            public AURA AURA { get; set; }
            public BRASILCARD BRASILCARD { get; set; }
            public CABAL CABAL { get; set; }
            public CARDBAN CARDBAN { get; set; }
            public DINERS DINERS { get; set; }
            public ELO ELO { get; set; }
            public FORTBRASIL FORTBRASIL { get; set; }
            public GRANDCARD GRANDCARD { get; set; }
            public HIPERCARD HIPERCARD { get; set; }
            public MAIS MAIS { get; set; }
            public MASTERCARD MASTERCARD { get; set; }
            public PERSONALCARD PERSONALCARD { get; set; }
            public PLENOCARD PLENOCARD { get; set; }
            public SOROCRED SOROCRED { get; set; }
            public VALECARD VALECARD { get; set; }
            public VISA VISA { get; set; }
        }

        public class AMEX
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images5 images { get; set; }
        }

        public class Images5
        {
            public SMALL5 SMALL { get; set; }
            public MEDIUM5 MEDIUM { get; set; }
        }

        public class SMALL5
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM5
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class AURA
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images6 images { get; set; }
        }

        public class Images6
        {
            public SMALL6 SMALL { get; set; }
            public MEDIUM6 MEDIUM { get; set; }
        }

        public class SMALL6
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM6
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class BRASILCARD
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images7 images { get; set; }
        }

        public class Images7
        {
            public SMALL7 SMALL { get; set; }
            public MEDIUM7 MEDIUM { get; set; }
        }

        public class SMALL7
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM7
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class CABAL
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images8 images { get; set; }
        }

        public class Images8
        {
            public SMALL8 SMALL { get; set; }
            public MEDIUM8 MEDIUM { get; set; }
        }

        public class SMALL8
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM8
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class CARDBAN
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images9 images { get; set; }
        }

        public class Images9
        {
            public SMALL9 SMALL { get; set; }
            public MEDIUM9 MEDIUM { get; set; }
        }

        public class SMALL9
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM9
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class DINERS
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images10 images { get; set; }
        }

        public class Images10
        {
            public SMALL10 SMALL { get; set; }
            public MEDIUM10 MEDIUM { get; set; }
        }

        public class SMALL10
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM10
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class ELO
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images11 images { get; set; }
        }

        public class Images11
        {
            public SMALL11 SMALL { get; set; }
            public MEDIUM11 MEDIUM { get; set; }
        }

        public class SMALL11
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM11
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class FORTBRASIL
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images12 images { get; set; }
        }

        public class Images12
        {
            public SMALL12 SMALL { get; set; }
            public MEDIUM12 MEDIUM { get; set; }
        }

        public class SMALL12
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM12
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class GRANDCARD
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images13 images { get; set; }
        }

        public class Images13
        {
            public SMALL13 SMALL { get; set; }
            public MEDIUM13 MEDIUM { get; set; }
        }

        public class SMALL13
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM13
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class HIPERCARD
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images14 images { get; set; }
        }

        public class Images14
        {
            public SMALL14 SMALL { get; set; }
            public MEDIUM14 MEDIUM { get; set; }
        }

        public class SMALL14
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM14
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MAIS
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images15 images { get; set; }
        }

        public class Images15
        {
            public SMALL15 SMALL { get; set; }
            public MEDIUM15 MEDIUM { get; set; }
        }

        public class SMALL15
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM15
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MASTERCARD
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images16 images { get; set; }
        }

        public class Images16
        {
            public SMALL16 SMALL { get; set; }
            public MEDIUM16 MEDIUM { get; set; }
        }

        public class SMALL16
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM16
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class PERSONALCARD
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images17 images { get; set; }
        }

        public class Images17
        {
            public SMALL17 SMALL { get; set; }
            public MEDIUM17 MEDIUM { get; set; }
        }

        public class SMALL17
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM17
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class PLENOCARD
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images18 images { get; set; }
        }

        public class Images18
        {
            public SMALL18 SMALL { get; set; }
            public MEDIUM18 MEDIUM { get; set; }
        }

        public class SMALL18
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM18
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class SOROCRED
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images19 images { get; set; }
        }

        public class Images19
        {
            public SMALL19 SMALL { get; set; }
            public MEDIUM19 MEDIUM { get; set; }
        }

        public class SMALL19
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM19
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class VALECARD
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images20 images { get; set; }
        }

        public class Images20
        {
            public SMALL20 SMALL { get; set; }
            public MEDIUM20 MEDIUM { get; set; }
        }

        public class SMALL20
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM20
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class VISA
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images21 images { get; set; }
        }

        public class Images21
        {
            public SMALL21 SMALL { get; set; }
            public MEDIUM21 MEDIUM { get; set; }
        }

        public class SMALL21
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM21
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class DEPOSIT
        {
            public string name { get; set; }
            public Options4 options { get; set; }
            public int code { get; set; }
        }

        public class Options4
        {
            public BANCO_BRASIL1 BANCO_BRASIL { get; set; }
            public HSBC HSBC { get; set; }
        }

        public class BANCO_BRASIL1
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images22 images { get; set; }
        }

        public class Images22
        {
            public SMALL22 SMALL { get; set; }
            public MEDIUM22 MEDIUM { get; set; }
        }

        public class SMALL22
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM22
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class HSBC
        {
            public string name { get; set; }
            public string displayName { get; set; }
            public string status { get; set; }
            public int code { get; set; }
            public Images23 images { get; set; }
        }

        public class Images23
        {
            public SMALL23 SMALL { get; set; }
            public MEDIUM23 MEDIUM { get; set; }
        }

        public class SMALL23
        {
            public string size { get; set; }
            public string path { get; set; }
        }

        public class MEDIUM23
        {
            public string size { get; set; }
            public string path { get; set; }
        }


    }
}