


using System;

namespace PagSeguroEasy.Library.Entities
{
   public class CartaoDeCredito
    {
        public Guid CartaoId { get; set; }      
        public string UserId { get; set; }       
        public string NumeroCartao { get; set; }      
        public string NomeCartao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
