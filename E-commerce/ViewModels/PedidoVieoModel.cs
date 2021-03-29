using msShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.ViewModels
{
    public class PedidoVieoModel
    {
        public Pedido  pedido{ get; set; }
        public DadosUsuario  DadosUsuario{ get; set; }
        public CartaoCreditoViwelModel CartaoCredito{ get; set; }
    }
}
