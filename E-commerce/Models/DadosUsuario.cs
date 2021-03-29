using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace msShop.Models
{
    public class DadosUsuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid DadosUsuarioId { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public string DataNascimento { get; set; }

        [Display(Name = "CPF")]
        public string CPFCNPJ{ get; set; }

        [Display(Name = "CPF/CNPJ")]
        public int TipoDocumento { get; set; }

        [Display(Name="Endenreço")]
        public string Enderenco { get; set; }
        [Display(Name = "Numero")]
        public int Numero { get; set; }
        [Display(Name = "Bairro")]
        public string Bairro{ get; set; }
        [Display(Name = "Cidade")]
        public string Cidade{ get; set; }
        [Display(Name = "Estado")]
        public string Estado{ get; set; }
        [Display(Name = "Complemento")]
        public string Complemento{ get; set; }

        [Display(Name = "CEP")]
        public string CEP{ get; set; }
        [Display(Name = "Codigo Area")]
        public string CodigoArea{ get; set; }
        [Display(Name = "Telefone")]
        public string NumeroTelefone{ get; set; }

        
        public DadosUsuario()
        {
            this.DadosUsuarioId = Guid.NewGuid();
        }

    }
}
