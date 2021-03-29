using Microsoft.AspNetCore.Mvc;
using msShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Components
{
    public class MenuCategoria : ViewComponent
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public MenuCategoria(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepositorio.GetAllCategorias.OrderBy(c => c.CategoriaNome);

            return View(categorias);
        }
    }
}
