using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public class PedidoDetalhe
    {
        [Key]
        public int DetalhePedidoId { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public Pedido Pedido { get; set; }
    }
}
