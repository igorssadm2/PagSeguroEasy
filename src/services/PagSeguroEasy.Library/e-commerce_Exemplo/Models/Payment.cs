using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static msShop.Models.PagCondicoesParcelamento;

namespace msShop.Models
{
    public class payment
    {
        public payment()
        {
            this.sender = new sender();
            this.items = new List<item>();
            this.shipping = new Shipping();
        }
        public bank bank { get; set; }
        public string mode {get; set; }
        public string method { get; set; }
        public string currency { get; set; }
        public sender sender { get; set; }
        public List<item> items { get; set; }


        public creditCard creditCard { get; set; }
        public Shipping shipping { get; set; }
        public string reference { get; set; }
        //public string receiverEmail { get; set; }
        public string extraAmount { get; set; }
        //public string notificationURL { get; set; }
    }
}
