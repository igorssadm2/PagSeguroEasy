using msShop.Models;

namespace msShop.ViewModels
{
    public class CarrinhoViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal SomaCarrinho { get; set; }
        public decimal CarrinhoTotal { get; set; }
        public ValorPrazoFreteModel Frete { get; set; }
      
    }
}
