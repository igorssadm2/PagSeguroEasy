﻿using Newtonsoft.Json;

namespace PagSeguroEasy.Library.InputModels
{
  public class ObterTokenCartaoInputModel
    {
        [JsonProperty("sessionId")]
        public string sessionId { get; set; }
        [JsonProperty("amount")]
        public decimal amount { get; set; }
        [JsonProperty("cardNumber")]
        public string cardNumber { get; set; }
        [JsonProperty("cardBrand")]
        public string cardBrand { get; set; }
        [JsonProperty("cardCvv")]
        public string cardCvv { get; set; }
        [JsonProperty("cardExpirationMonth")]
        public string cardExpirationMonth { get; set; }
        [JsonProperty("cardExpirationYear")]
        public string cardExpirationYear { get; set; }
    }
}
