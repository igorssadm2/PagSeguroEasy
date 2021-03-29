using Microsoft.CodeAnalysis.Operations;
using msShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Funcoes.Frete
{
    public class CalculoPacote
    {

        private readonly AppDbContext _contextoBancodeDados;

        public CalculoPacote(AppDbContext contextoBancodeDados)
        {
            _contextoBancodeDados = contextoBancodeDados;
        }


        public List<PacoteFrete> CalcularPacotesdeProdutos(List<ShoppingCartItem> produtos)
        {
            List<PacoteFrete> PacoteFrete = new List<PacoteFrete>();
            PacoteFrete pacoteFrete = new PacoteFrete();

            foreach (var item in produtos)
            {
                for (int i = 0; i < item.Quantidade; i++)
                {
                    var peso = pacoteFrete.Peso + item.Peso;
                    var comprimento = (pacoteFrete.Comprimento > item.comprimento) ? pacoteFrete.Comprimento : item.comprimento;
                    var largura = (pacoteFrete.Largura > item.largura) ? pacoteFrete.Largura : item.largura;
                    var altura = pacoteFrete.Altura + item.altura;

                    var dimensao = comprimento + largura + altura;


                    //TODO -> Cria novo pacote caso ultrapasse 30kg e 200 cm
                    if (peso > 30 || dimensao > 200)
                    {

                        pacoteFrete.Peso = peso - 30;
                        if (dimensao > 200)
                        {
                            int novaDimensao = dimensao - 200;
                            int distribuicaoDimensao = novaDimensao / 3;
                            pacoteFrete.Comprimento = distribuicaoDimensao;
                            pacoteFrete.Largura = distribuicaoDimensao;
                            pacoteFrete.Altura = distribuicaoDimensao;
                        }

                        PacoteFrete.Add(pacoteFrete);
                        pacoteFrete = new PacoteFrete();
                    }

                    pacoteFrete.Peso = pacoteFrete.Peso + item.Peso;
                    pacoteFrete.Comprimento = pacoteFrete.Comprimento + item.comprimento;
                    pacoteFrete.Largura = pacoteFrete.Largura + item.largura;
                    pacoteFrete.Altura = pacoteFrete.Altura + item.altura;

                }

            }

            PacoteFrete.Add(pacoteFrete);
            return PacoteFrete;
        }
    }
}
