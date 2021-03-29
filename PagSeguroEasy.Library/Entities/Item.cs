

namespace PagSeguroEasy.Library.Entities
{
  public class Item
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

