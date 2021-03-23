using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public class ValorPrazoFrete
    {
        public int TipoFrete { get; set; }
        public double Valor { get; set; }
        public int Prazo { get; set; }
        public decimal SomaTotal { get; set; }
        public List<ErroFrete> ListErroFrete { get; set; }
       public ValorPrazoFrete()
        {
            this.ListErroFrete = new List<ErroFrete>();
            Valor = 0;
            SomaTotal = 0;
            Prazo = 0;
        }
    }

    public class ErroFrete
    {
        public string erro { get; set; }
        public string MensagemErro { get; set; }
        public ErroFrete(string Erro, string Mensagem)
        {
            this.erro = erro;
            this.MensagemErro = Mensagem;
        }
        public void Add(ErroFrete erroFrete)
        {
            this.erro =erroFrete.erro;
            this.MensagemErro = erroFrete.MensagemErro;
        }
    }

}
