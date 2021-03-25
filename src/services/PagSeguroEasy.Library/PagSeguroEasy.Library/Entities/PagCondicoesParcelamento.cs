using Newtonsoft.Json;
using System.Collections.Generic;

namespace Payments.PagSeguro.Entities
{
    public class PagCondicoesParcelamento
    {
        public Root root { get; set; }

        public class Mastercard : CondicoesParcelamento
        {

        }
        public class Visa : CondicoesParcelamento
        {

        }

        public class Installments
        {
            public List<Mastercard> mastercard { get; set; }
            public List<Visa> visa { get; set; }
        }

        public class Root
        {
            public bool error { get; set; }
            public Installments installments { get; set; }
        }

        public class CondicoesParcelamento
        {
            [JsonProperty("quantity")]
            public int quantity { get; set; }
            [JsonProperty("installmentAmount")]
            public float installmentAmount { get; set; }
            [JsonProperty("totalAmount")]
            public float totalAmount { get; set; }
            [JsonProperty("interestFree")]
            public bool interestFree { get; set; }
        }
    }
}
