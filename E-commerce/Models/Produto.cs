using System.ComponentModel.DataAnnotations;

namespace msShop.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool aVenda { get; set; }
        public bool emEstoque { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Slug { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
        public int largura { get; set; }
        public int altura { get; set; }
        public int comprimento { get; set; }
        public int Peso { get; set; }
        public string UnidadeMedida { get; set; }

    }
}
