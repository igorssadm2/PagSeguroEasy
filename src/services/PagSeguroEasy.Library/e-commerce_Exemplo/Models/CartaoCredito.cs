using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace msShop.Models
{
    public class CartaoCredito
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]        
        public Guid CartaoId { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        [Display(Name="Numero Cartão")]
        public string NumeroCartao { get; set; }
        [Display(Name = "Nome Cartão")]
        public string NomeCartao { get; set; }
        [Display(Name = "Data Validade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataValidade { get; set; }

        public CartaoCredito()
        {
            this.CartaoId = Guid.NewGuid();
        }

    }
}
