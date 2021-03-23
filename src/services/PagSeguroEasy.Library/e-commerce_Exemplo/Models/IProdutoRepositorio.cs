using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> GetAllProdutos { get; }
        IEnumerable<Produto> GetProdutosVenda { get; }
        Produto GetProdutoById(int ProdutoId);
    }
}
