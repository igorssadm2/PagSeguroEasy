
namespace msShop.Models
{

    public class Shipping
    {
        public bool addressRequired { get; set; }

        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string postalCode { get; set; }
        public string street { get; set; }

        public string number { get; set; }
        public string complement { get; set; }
        public int? ShippingType { get; set; }
        public string Cost { get; set; }
      
    }
}
