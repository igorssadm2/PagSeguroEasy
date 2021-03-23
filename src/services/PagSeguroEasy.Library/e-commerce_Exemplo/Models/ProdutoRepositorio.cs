using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace msShop.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio   
    {

        private readonly AppDbContext _contextoBancodeDados ;

        public ProdutoRepositorio(AppDbContext ContextoBancodeDados)
        {
            _contextoBancodeDados = ContextoBancodeDados;
        }

        public IEnumerable<Produto> GetAllProdutos
        {
            get
            {
                return _contextoBancodeDados.Produtos.Include(c => c.Categoria);
            }
        }


        public IEnumerable<Produto> GetProdutosVenda
        {
            get
            {
                return _contextoBancodeDados.Produtos.Include(c => c.Categoria).Where(p => p.aVenda);
            }
        }


        public Produto GetProdutoById(int ProdutoId)
        {
            return _contextoBancodeDados.Produtos.FirstOrDefault(p => p.ProdutoId == ProdutoId);
        }

    }
}
