using msShop.Models;
using System.Collections.Generic;

namespace msShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produto> aVenda { get; set; }
    }
}
