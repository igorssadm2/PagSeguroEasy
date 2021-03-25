

using System.Collections.Generic;

namespace PagSeguroEasy.Library.Entities
{
   public class Payment
    {
        public Payment()
        {
            this.sender = new Sender();
            this.items = new List<Item>();
            this.shipping = new Shipping();
        }
        public Bank bank { get; set; }
        public string mode { get; set; }
        public string method { get; set; }
        public string currency { get; set; }
        public Sender sender { get; set; }
        public List<Item> items { get; set; }
        public CreditCard creditCard { get; set; }
        public Shipping shipping { get; set; }
        public string reference { get; set; }
        //public string receiverEmail { get; set; }
        public string extraAmount { get; set; }
        //public string notificationURL { get; set; }
    }
}
