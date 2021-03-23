using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace msShop.Models
{
    public class Pedido
    {
        [BindNever]
        public int PedidoId { get; set; }


        [Required(ErrorMessage = "Informe seu nome")]
        [Display(Name = "Primeiro Nome")]
        [StringLength(30)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Informe seu sobrenome")]
        [Display(Name = "Sobre Nome")]
        [StringLength(50)]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Informe seu CPF")]
        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe seu endereço")]
        [Display(Name = "Endereço")]
        [StringLength(80)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe a cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe a UF")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Informe seu CEP")]
        [StringLength(8, MinimumLength = 8)]
        public string CEP { get; set; }


        [Required(ErrorMessage = "Informe seu telefone")]
        [StringLength(12, MinimumLength = 12)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        public List<PedidoDetalhe> PedidoDetalhes { get; set; }

        [BindNever]
        public decimal TotalPedido { get; set; }

        [BindNever]
        public DateTime DataPedido { get; set; }

    }
}
