using Microsoft.AspNetCore.Mvc;
using msShop.Models;
using msShop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace msShop.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio, ICategoriaRepositorio categoriaRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
        }


        public ViewResult Lista(string categoria)
        {
            IEnumerable<Produto> produtos;
            string categoriaAtual;

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = _produtoRepositorio.GetAllProdutos.OrderBy(p => p.ProdutoId);
                categoriaAtual = "Todas as categorias";
            }
            else
            {
                produtos = _produtoRepositorio.GetAllProdutos.Where(c => c.Categoria.CategoriaNome == categoria);
                categoriaAtual = _categoriaRepositorio.GetAllCategorias.FirstOrDefault(c => c.CategoriaNome == categoria)?.CategoriaNome;
            }
            return View(new ListaProdutoViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            });
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _produtoRepositorio.GetProdutoById(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

    }
}
