using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace msShop.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartaoCredito",
                columns: table => new
                {
                    CartaoId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    NumeroCartao = table.Column<string>(nullable: true),
                    NomeCartao = table.Column<string>(nullable: true),
                    DataValidade = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaoCredito", x => x.CartaoId);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(nullable: true),
                    CategoriaDescricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "DadosUsuario",
                columns: table => new
                {
                    DadosUsuarioId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    CPFCNPJ = table.Column<string>(nullable: true),
                    TipoDocumento = table.Column<int>(nullable: false),
                    Enderenco = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    CodigoArea = table.Column<string>(nullable: true),
                    NumeroTelefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosUsuario", x => x.DadosUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    SobreNome = table.Column<string>(maxLength: 50, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    Endereco = table.Column<string>(maxLength: 80, nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false),
                    CEP = table.Column<string>(maxLength: 8, nullable: false),
                    Telefone = table.Column<string>(maxLength: 12, nullable: false),
                    TotalPedido = table.Column<decimal>(nullable: false),
                    DataPedido = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    ValorBruto = table.Column<decimal>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    ImagemUrl = table.Column<string>(nullable: true),
                    ImagemThumbnailUrl = table.Column<string>(nullable: true),
                    aVenda = table.Column<bool>(nullable: false),
                    emEstoque = table.Column<bool>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    largura = table.Column<int>(nullable: false),
                    altura = table.Column<int>(nullable: false),
                    comprimento = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    UnidadeMedida = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalhes",
                columns: table => new
                {
                    DetalhePedidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalhes", x => x.DetalhePedidoId);
                    table.ForeignKey(
                        name: "FK_PedidoDetalhes_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalhes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItens",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<string>(nullable: true),
                    ProdutoId = table.Column<int>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    comprimento = table.Column<int>(nullable: false),
                    largura = table.Column<int>(nullable: false),
                    altura = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItens", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "CategoriaDescricao", "CategoriaNome" },
                values: new object[,]
                {
                    { 1, null, "Softwares" },
                    { 2, null, "Hardware" },
                    { 3, null, "Video Games" },
                    { 4, null, "Acessórios" },
                    { 5, null, "Servidores" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "CategoriaId", "Descricao", "ImagemThumbnailUrl", "ImagemUrl", "Marca", "Nome", "Peso", "Preco", "Quantidade", "Slug", "UnidadeMedida", "ValorBruto", "aVenda", "altura", "comprimento", "emEstoque", "largura" },
                values: new object[,]
                {
                    { 1, 1, "Console Xbox One S 1TB + Anthem Legion Of Dawn - Original Microsoft", "xboxOneS.jpg", "xboxOneS.jpg", "Microsoft", "XBox One S 1TB + Anthem Legion Of Dawn", 5, 2979.90m, 1, "Console-Xbox-One-S-1TB-Anthem-Legion-Of-Dawn", null, 3199.90m, true, 30, 23, true, 10 },
                    { 4, 1, "Test Drive Unlimited 2 destina-se a transformar o gênero de condução, acrescentando que a persistência, a progressão ea personalização dos jogos mais recentes para a experiência multiplayer de corrida.", "tdu2.jpg", "tdu2.jpg", "Microsoft", "Test Drive Unlimited 2 XBox 360", 1, 71.90m, 1, "Test-Drive-Unlimited-2-XBox-360", null, 91.90m, true, 5, 10, true, 3 },
                    { 5, 1, "Em Halo 3: ODST o jogador controla seu protagonista principal, conhecido como Novato, em busca de pistas pela cidade de New Mombasa após acordar, depois de estar inconsciente por seis horas quando sua cápsula de lançamento caiu na superfície.", "halo3-odst.jpg", "halo3-odst.jpg", "Microsoft", "Halo 3 Odst Original Dublado XBox360", 1, 49.90m, 1, "Halo-3-Odst Original-Dublado-XBox-360", null, 69.90m, true, 5, 10, true, 3 },
                    { 6, 1, "Os aprimoramentos de Anniversary incluem uma atualização completa para visuais em alta definição, suporte a jogabilidade cooperativa e online por meio do serviço Xbox Live, músicas e efeitos sonoros novos e remasterizados, além de extras como conquistas e colecionáveis dentro do jogo.", "halo-aniversary.jpg", "halo-aniversary.jpg", "Microsoft", "Halo Combat Evolved Anniversary - XBox 360 ", 1, 49.90m, 10, "Halo-Combat-Evolved-Anniversary-Xbox-360 ", null, 99.90m, true, 5, 10, true, 3 },
                    { 7, 1, "F1™ 2013 é o videogame definitivo de FÓRMULA 1™ para esta geração de consoles. A premiada série de FÓRMULA 1 da Codemasters já vendeu mais de 6,5 milhões de unidades. O F1 2013: CLASSIC EDITION é um pacote premium que inclui o F1 2013, conteúdo clássico da década de 1980, e ainda tem mais conteúdo da década de 1990 e pistas clássicas adicionais.", "f1-2013.jpg", "f1-2013.jpg", "Microsoft", "Formula 1 2013 (edição Classica) - XBox 360", 1, 69.90m, 1, "Formula-1-2013-(edição-Classica)-Xbox-360", null, 129.90m, true, 5, 10, true, 3 },
                    { 8, 1, "É um controle muito anatômico, se adapta completamente a sua mão, a posição do analógico é muito boa, evitando dores ao se jogar por muito tempo. Os gatilhos são outro ponto positivo do controle do Xbox 360, com um alcance excelente para os dedos, fornecendo uma jogabilidade confortável e precisa, principalmente nos jogos que exigem mais desses botões.", "controle-xbox.jpg", "controle-xbox.jpg", "Microsoft", "Controle Xbox 360 Original Sem Fio Wireless Microsoft", 1, 129.90m, 1, "controle-xbox-360", null, 179.90m, true, 5, 5, true, 5 },
                    { 9, 1, "Fones de ouvido com fio para jogos, plug de 3.5mm Jack/Bass/Headsets Estéreo com Microfone para XBOX-ONE, PS4 e PC. Ideal para jogos Online", "fone-ouvido-kotion.jpg", "fone-ouvido-kotion.jpg", "Microsoft", "Fones de ouvido com fio para jogos", 1, 89.90m, 1, "Fones-de-ouvido-com-fio-para-jogos", null, 129.90m, true, 5, 5, true, 5 },
                    { 2, 2, "Halo: Reach é mais um título desta aclamada franquia exclusiva para o Xbox 360, contando uma nova história envolvendo os acontecimentos da Noble Team.", "halo-reach.jpg", "halo-reach.jpg", "Microsoft", "Halo Reach XBox 360", 1, 59.99m, 1, "Halo-Reach-XBox-360", null, 79.90m, true, 5, 10, true, 3 },
                    { 3, 2, "Halo 4 é o quarto jogo da famosa franquia exclusiva da Microsoft, que estreou em 2001 com Halo: Combat Evolved. O game marca o surgimento de uma nova trilogia estrelada por Master Chief, o lendário soldado Spartan que é o grande representante da série.", "halo-4.jpg", "halo-4.jpg", "Microsoft", "Halo 4 XBox 360", 1, 74.90m, 1, "Halo-4-XBox-360", null, 99.90m, true, 5, 10, true, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalhes_PedidoId",
                table: "PedidoDetalhes",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalhes_ProdutoId",
                table: "PedidoDetalhes",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItens_ProdutoId",
                table: "ShoppingCartItens",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartaoCredito");

            migrationBuilder.DropTable(
                name: "DadosUsuario");

            migrationBuilder.DropTable(
                name: "PedidoDetalhes");

            migrationBuilder.DropTable(
                name: "ShoppingCartItens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
