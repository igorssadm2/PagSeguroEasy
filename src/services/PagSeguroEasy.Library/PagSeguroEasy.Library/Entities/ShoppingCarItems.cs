

namespace PagSeguroEasy.Library.Entities
{
   public class ShoppingCarItems
    {
        public int ShoppingCartItemId { get; set; }
        public string ShoppingCartId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public int Peso { get; set; }
        public int comprimento { get; set; }
        public int largura { get; set; }
        public int altura { get; set; }

    }
}
