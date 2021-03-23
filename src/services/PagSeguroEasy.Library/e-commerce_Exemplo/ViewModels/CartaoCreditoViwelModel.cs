using msShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.ViewModels
{
    public class CartaoCreditoViwelModel : CartaoCredito
    {
        [Display(Name = "CVV")]
        public int CVV{ get; set; }
    }
}
