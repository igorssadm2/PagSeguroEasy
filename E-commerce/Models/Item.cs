

namespace msShop.Models
{
    /// <summary>
    /// Represents a product/item in a transaction
    /// </summary>
    public class item
    {
        public string id { get; set; }
        public string description { get; set; }
        public int quantity
        {
            get;
            set;
        }

        public decimal amount
        {
            get;
            set;
        }       
    }
}
