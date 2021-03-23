using Microsoft.AspNetCore.Mvc;
using msShop.Models;
using msShop.ViewModels;

namespace msShop.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProdutoRepositorio _produtoRepositorio;
        public HomeController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {

            var homeViewModel = new HomeViewModel
            {
                aVenda = _produtoRepositorio.GetProdutosVenda
            };

            return View(homeViewModel);
        }

        public IActionResult PoliticaTrocaDevolucao()
        {
            return View();
        }

    }
}
