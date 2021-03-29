using System.Collections.Generic;

namespace msShop.Models
{
    public interface ICategoriaRepositorio
    {
        IEnumerable<Categoria> GetAllCategorias { get; }
    }
}
