using msShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.ViewModels
{
    public class ValorPrazoFreteModel
    {
        public List<ValorPrazoFrete> ListaValorPrazoFrete  { get; set; } 
        public decimal SomaTotalFrete { get; set; }

    }
}
