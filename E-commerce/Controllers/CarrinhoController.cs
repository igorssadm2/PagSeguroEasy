using Microsoft.AspNetCore.Mvc;
using msShop.Funcoes.Frete;
using msShop.Models;
using msShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ShoppingCart _carrinho;
        private WSCorreiosCalcularFrete _wscorreios;
        private CalculoPacote _calcularPacote;
        public ValorPrazoFrete _frete;
        public CarrinhoController(IProdutoRepositorio produtoRepositorio, ShoppingCart carrinho, WSCorreiosCalcularFrete wscorreios, CalculoPacote calcularPacote)
        {
            _produtoRepositorio = produtoRepositorio;
            _carrinho = carrinho;
            _wscorreios = wscorreios;
            _calcularPacote = calcularPacote;
        }

        public ViewResult Index()
        {
            _carrinho.CarrinhoItens = _carrinho.GetShoppingCartItens();


            var carrinhoViewModel = new CarrinhoViewModel
            {
                ShoppingCart = _carrinho,
                CarrinhoTotal = _carrinho.TotalCarrinho(),
                Frete = new ValorPrazoFreteModel()
                {
                    SomaTotalFrete = _carrinho.TotalCarrinho(),
                    ListaValorPrazoFrete = new List<ValorPrazoFrete>()
                }
               
            };
            carrinhoViewModel.Frete.ListaValorPrazoFrete.Add(new ValorPrazoFrete());
            carrinhoViewModel.Frete.ListaValorPrazoFrete.Add(new ValorPrazoFrete());



            return View(carrinhoViewModel);

        }

        public RedirectToActionResult AdicionarItemCarrinho(int produtoId)
        {
            var selectProduto = _produtoRepositorio.GetAllProdutos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (selectProduto != null)
            {
                _carrinho.AdicionarItemCarrinho(selectProduto, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoverItemCarrinho(int produtoId)
        {
            var selectProduto = _produtoRepositorio.GetAllProdutos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (selectProduto != null)
            {
                _carrinho.RemoverItemCarrinho(selectProduto);
            }
            return RedirectToAction("Index");
        }

        public IActionResult LimparCarrinho()
        {
            _carrinho.LimparCarrinho();
            return RedirectToAction((nameof(Index)));
        }

        


        [HttpGet]
        public async Task<IActionResult> CalcularFrete(string CepDestino)
        {
            try
            {
                List<ShoppingCartItem> produtos = _carrinho.GetShoppingCartItens();

                List<PacoteFrete> pacotes = _calcularPacote.CalcularPacotesdeProdutos(produtos);

                ValorPrazoFrete ValorPAC = await _wscorreios.CalcularFrete(CepDestino.ToString(), TipoFreteConstante.PAC, pacotes);
                ValorPrazoFrete ValorSEDEX = await _wscorreios.CalcularFrete(CepDestino.ToString(), TipoFreteConstante.SEDEX, pacotes);

                ValorPrazoFreteModel valorPrazoFreteModel = new ValorPrazoFreteModel();

                valorPrazoFreteModel.ListaValorPrazoFrete = new List<ValorPrazoFrete>();

                //_frete = ValorPAC;
                ValorPAC.SomaTotal = _carrinho.TotalCarrinho() + (decimal)ValorPAC.Valor;
                ValorSEDEX.SomaTotal = _carrinho.TotalCarrinho() + (decimal)ValorSEDEX.Valor;


                valorPrazoFreteModel.ListaValorPrazoFrete.Add(ValorPAC);
                valorPrazoFreteModel.ListaValorPrazoFrete.Add(ValorSEDEX);

                //valorPrazoFreteModel.SomaTotalFrete = valorPrazoFreteModel.ListaValorPrazoFrete[0].SomaTotal;


                return PartialView("_CalculoFrete", valorPrazoFreteModel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



    }
}
