using msShop.Models;
using System.Collections.Generic;

namespace msShop.ViewModels
{
    public class ListaProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
