using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public class ShoppingCartItem
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
