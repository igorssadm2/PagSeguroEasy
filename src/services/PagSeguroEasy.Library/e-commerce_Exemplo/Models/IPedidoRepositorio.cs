using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public interface IPedidoRepositorio
    {
        void CriarPedido(Pedido pedido);
    }
}
