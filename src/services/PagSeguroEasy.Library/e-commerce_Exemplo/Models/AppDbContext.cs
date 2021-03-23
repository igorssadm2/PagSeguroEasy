using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace msShop.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser> // Descomentar para criar as tabelas de membership .NetCore
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CartaoCredito> CartaoCredito { get; set; }
        public DbSet<DadosUsuario> DadosUsuario { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().HasData(new Categoria { CategoriaId = 1, CategoriaNome = "Softwares" });
            modelBuilder.Entity<Categoria>().HasData(new Categoria { CategoriaId = 2, CategoriaNome = "Hardware" });
            modelBuilder.Entity<Categoria>().HasData(new Categoria { CategoriaId = 3, CategoriaNome = "Video Games" });
            modelBuilder.Entity<Categoria>().HasData(new Categoria { CategoriaId = 4, CategoriaNome = "Acessórios" });
            modelBuilder.Entity<Categoria>().HasData(new Categoria { CategoriaId = 5, CategoriaNome = "Servidores" });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 1,
                Nome = "XBox One S 1TB + Anthem Legion Of Dawn",
                Descricao = "Console Xbox One S 1TB + Anthem Legion Of Dawn - Original Microsoft",
                ValorBruto = 3199.90m,
                Preco = 2979.90m,
                ImagemUrl = "xboxOneS.jpg",
                ImagemThumbnailUrl = "xboxOneS.jpg",
                aVenda = true,
                emEstoque = true,
                CategoriaId = 1,
                Slug = "Console-Xbox-One-S-1TB-Anthem-Legion-Of-Dawn",
                Marca = "Microsoft",
                Quantidade = 1,
                largura = 10,
                altura = 30,
                comprimento = 23,
                Peso = 5
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 2,
                Nome = "Halo Reach XBox 360",
                Descricao = "Halo: Reach é mais um título desta aclamada franquia exclusiva para o Xbox 360, contando uma nova história envolvendo os acontecimentos da Noble Team.",
                ValorBruto = 79.90m,
                Preco = 59.99m,
                ImagemUrl = "halo-reach.jpg",
                ImagemThumbnailUrl = "halo-reach.jpg",
                aVenda = true,
                emEstoque = true,
                CategoriaId = 2,
                Slug = "Halo-Reach-XBox-360",
                Marca = "Microsoft",
                Quantidade = 1,
                largura = 3,
                altura = 5,
                comprimento = 10,
                Peso = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 3,
                Nome = "Halo 4 XBox 360",
                Descricao = "Halo 4 é o quarto jogo da famosa franquia exclusiva da Microsoft, que estreou em 2001 com Halo: Combat Evolved. O game marca o surgimento de uma nova trilogia estrelada por Master Chief, o lendário soldado Spartan que é o grande representante da série.",
                ValorBruto = 99.90m,
                Preco = 74.90m,
                ImagemUrl = "halo-4.jpg",
                ImagemThumbnailUrl = "halo-4.jpg",
                aVenda = true,
                emEstoque = true,
                CategoriaId = 2,
                Slug = "Halo-4-XBox-360",
                Marca = "Microsoft",
                Quantidade = 1,
                largura = 3,
                altura = 5,
                comprimento = 10,
                Peso = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 4,
                Nome = "Test Drive Unlimited 2 XBox 360",
                Descricao = "Test Drive Unlimited 2 destina-se a transformar o gênero de condução, acrescentando que a persistência, a progressão ea personalização dos jogos mais recentes para a experiência multiplayer de corrida.",
                ValorBruto = 91.90m,
                Preco = 71.90m,
                ImagemUrl = "tdu2.jpg",
                ImagemThumbnailUrl = "tdu2.jpg",
                aVenda = true,
                emEstoque = true,
                CategoriaId = 1,
                Slug = "Test-Drive-Unlimited-2-XBox-360",
                Marca = "Microsoft",
                Quantidade = 1,
                largura = 3,
                altura = 5,
                comprimento = 10,
                Peso = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 5,
                Nome = "Halo 3 Odst Original Dublado XBox360",
                Descricao = "Em Halo 3: ODST o jogador controla seu protagonista principal, conhecido como Novato, em busca de pistas pela cidade de New Mombasa após acordar, depois de estar inconsciente por seis horas quando sua cápsula de lançamento caiu na superfície.",
                ValorBruto = 69.90m,
                Preco = 49.90m,
                ImagemUrl = "halo3-odst.jpg",
                ImagemThumbnailUrl = "halo3-odst.jpg",
                aVenda = true,
                emEstoque = true,
                CategoriaId = 1,
                Slug = "Halo-3-Odst Original-Dublado-XBox-360",
                Marca = "Microsoft",
                Quantidade = 1,
                largura = 3,
                altura = 5,
                comprimento = 10,
                Peso = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 6,
                Nome = "Halo Combat Evolved Anniversary - XBox 360 ",
                Descricao = "Os aprimoramentos de Anniversary incluem uma atualização completa para visuais em alta definição, suporte a jogabilidade cooperativa e online por meio do serviço Xbox Live, músicas e efeitos sonoros novos e remasterizados, além de extras como conquistas e colecionáveis dentro do jogo.",
                ValorBruto = 99.90m,
                Preco = 49.90m,
                ImagemUrl = "halo-aniversary.jpg",
                ImagemThumbnailUrl = "halo-aniversary.jpg",
                aVenda = true,
                emEstoque = true,
                CategoriaId = 1,
                Slug = "Halo-Combat-Evolved-Anniversary-Xbox-360 ",
                Marca = "Microsoft",
                Quantidade = 10,
                largura = 3,
                altura = 5,
                comprimento = 10,
                Peso = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 7,
                Nome = "Formula 1 2013 (edição Classica) - XBox 360",
                Descricao = "F1™ 2013 é o videogame definitivo de FÓRMULA 1™ para esta geração de consoles. A premiada série de FÓRMULA 1 da Codemasters já vendeu mais de 6,5 milhões de unidades. O F1 2013: CLASSIC EDITION é um pacote premium que inclui o F1 2013, conteúdo clássico da década de 1980, e ainda tem mais conteúdo da década de 1990 e pistas clássicas adicionais.",
                ValorBruto = 129.90m,
                Preco = 69.90m,
                ImagemUrl = "f1-2013.jpg",
                ImagemThumbnailUrl = "f1-2013.jpg",
                aVenda = true,
                emEstoque = true,
                CategoriaId = 1,
                Slug = "Formula-1-2013-(edição-Classica)-Xbox-360",
                Marca = "Microsoft",
                Quantidade = 1,
                largura = 3,
                altura = 5,
                comprimento = 10,
                Peso = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 8,
                Nome = "Controle Xbox 360 Original Sem Fio Wireless Microsoft",
                Descricao = "É um controle muito anatômico, se adapta completamente a sua mão, a posição do analógico é muito boa, evitando dores ao se jogar por muito tempo. Os gatilhos são outro ponto positivo do controle do Xbox 360, com um alcance excelente para os dedos, fornecendo uma jogabilidade confortável e precisa, principalmente nos jogos que exigem mais desses botões.",
                ValorBruto = 179.90m,
                Preco = 129.90m,
                ImagemUrl = "controle-xbox.jpg",
                ImagemThumbnailUrl = "controle-xbox.jpg",
                aVenda = true,
                emEstoque = true,
                CategoriaId = 1,
                Slug = "controle-xbox-360",
                Marca = "Microsoft",
                Quantidade = 1,
                largura = 5,
                altura = 5,
                comprimento = 5,
                Peso = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 9,
                Nome = "Fones de ouvido com fio para jogos",
                Descricao = "Fones de ouvido com fio para jogos, plug de 3.5mm Jack/Bass/Headsets Estéreo com Microfone para XBOX-ONE, PS4 e PC. Ideal para jogos Online",
                ValorBruto = 129.90m,
                Preco = 89.90m,
                ImagemUrl = "fone-ouvido-kotion.jpg",
                ImagemThumbnailUrl = "fone-ouvido-kotion.jpg",
                aVenda = true,
                emEstoque = true,
                CategoriaId = 1,
                Slug = "Fones-de-ouvido-com-fio-para-jogos",
                Marca = "Microsoft",
                Quantidade = 1,
                largura = 5,
                altura = 5,
                comprimento = 5,
                Peso = 1
            });


        }
    }
}
