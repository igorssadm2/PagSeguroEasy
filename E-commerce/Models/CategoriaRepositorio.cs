using System.Collections.Generic;

namespace msShop.Models
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly AppDbContext _contextoBancodeDados;

        public CategoriaRepositorio(AppDbContext ContextoBancodeDados)
        {
            _contextoBancodeDados = ContextoBancodeDados;
        }


        public IEnumerable<Categoria> GetAllCategorias => _contextoBancodeDados.Categorias;
    }

}
