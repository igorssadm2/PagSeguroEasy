using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public class creditCard
    {
        public string token { get; set; }
        public installment installment { get; set; }
        public holder holder { get; set; }
        public Address billingAddress { get; set; }

        public creditCard()
        {
            this.installment = new installment();
            this.holder = new holder();
            this.billingAddress = new Address();
        }

    }
}
