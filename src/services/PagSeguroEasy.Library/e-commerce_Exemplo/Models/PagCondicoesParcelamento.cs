
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
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

        //    [JsonProperty("mastercard")]
        //     public Installments installments { get; set; }
        //    [JsonProperty("errors")]
        //    public Root erro { get; set; }
        //    [JsonObject("Installments")]
        //    public class Installments
        //    {
        //        [JsonProperty("visa, mastercard")]
        //        public CondicoesParcelamento[] Cards { get; set; }

        //    }

        //    public class CondicoesParcelamento
        //    {
        //        [JsonProperty("quantity")]
        //        public int quantity { get; set; }
        //        [JsonProperty("installmentAmount")]
        //        public float installmentAmount { get; set; }
        //        [JsonProperty("totalAmount")]
        //        public float totalAmount { get; set; }
        //        [JsonProperty("interestFree")]
        //        public bool interestFree { get; set; }
        //    }
        //}
    }
