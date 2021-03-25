

namespace PagSeguroEasy.Library.Entities
{
   public class CreditCard
    {
        public string token { get; set; }
        public Installment installment { get; set; }
        public Holder holder { get; set; }
        public Address billingAddress { get; set; }

        public CreditCard()
        {
            this.installment = new Installment();
            this.holder = new Holder();
            this.billingAddress = new Address();
        }
    }
}
