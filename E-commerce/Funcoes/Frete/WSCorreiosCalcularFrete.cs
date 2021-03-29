using Microsoft.Extensions.Configuration;
using msShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WSCorreios;

namespace msShop.Funcoes.Frete
{
    public class WSCorreiosCalcularFrete
    {
        private IConfiguration _configuration;
        private CalcPrecoPrazoWSSoap _servico;
        public WSCorreiosCalcularFrete(IConfiguration configuration, CalcPrecoPrazoWSSoap servico )
        {
            _configuration = configuration;
            _servico = servico;
        }


        public async Task<ValorPrazoFrete> CalcularFrete(String cepDestino, String tipoFrete, List<PacoteFrete> Pacotes)
        {
            List<ValorPrazoFrete> ValorDosPacotesPorFrete = new List<ValorPrazoFrete>();

            foreach (var pacote in Pacotes)
            {
                ValorDosPacotesPorFrete.Add(await CalcularValorPrazoFrete(cepDestino, tipoFrete, pacote));
            }

            ValorPrazoFrete ValorDosFretes = ValorDosPacotesPorFrete
                .GroupBy(a => a.TipoFrete)
                .Select(list => new ValorPrazoFrete
                {
                    TipoFrete = list.First().TipoFrete,
                    Prazo = list.Max(c => c.Prazo),
                    Valor = list.Sum(c => c.Valor)
                }).ToList().First();

            return ValorDosFretes;

        }

        private async Task<ValorPrazoFrete> CalcularValorPrazoFrete(String cepDestino, String tipoFrete, PacoteFrete pacoteFrete)
        {
            var cepOrigem = _configuration.GetValue<string>("Frete:cepOrigem");
            var maoPropria = _configuration.GetValue<string>("Frete:maoPropria");
            var avisoRecebimento = _configuration.GetValue<string>("Frete:avisoRecebimento");
            var diametro = Math.Max(Math.Max(pacoteFrete.Comprimento, pacoteFrete.Largura), pacoteFrete.Altura);

            cResultado resultado = await _servico.CalcPrecoPrazoAsync("", "", tipoFrete, cepOrigem, cepDestino, pacoteFrete.Peso.ToString(), 1, pacoteFrete.Comprimento,
                pacoteFrete.Altura, pacoteFrete.Largura, diametro, maoPropria, 0 , avisoRecebimento);
        
        if(resultado.Servicos[0].Erro == "0")
            {
                return new ValorPrazoFrete()
                {
                    TipoFrete = int.Parse(tipoFrete),
                    Prazo = int.Parse(resultado.Servicos[0].PrazoEntrega),
                    Valor = double.Parse(resultado.Servicos[0].Valor.Replace(".", "").Replace(",", ".")),
                };
            }
            else
            {

                return new ValorPrazoFrete()
                {

                };
                //("Erro: " + resultado.Servicos[0].MsgErro);
            }
        
        
        }


    }
}
