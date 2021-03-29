using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using msShop.Configuration;
using msShop.Funcoes;
using msShop.Funcoes.Frete;
using msShop.Funcoes.PagSeguro;
using msShop.Models;
using msShop.TagHelpers;
using PagSeguroEasy.Library;
using WSCorreios;

namespace msShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            var moviesConfig =  Configuration.GetSection("PagSeguroUserPass:SandBox").Get<PagSeguroChaveAcesso>();
            services.Configure<PagSeguroChaveAcesso>(Configuration.GetSection("MySettings"));

            services.AddMvc();
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString
            ("ConexaoPadrao")));
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddRazorPages();
            services.AddSession();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ShoppingCart>(sc => ShoppingCart.GetCart(sc));
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<WSCorreiosCalcularFrete>();
            services.AddScoped<CalculoPacote>();
            services.AddScoped<CartaoCredito>();
            services.AddScoped<CartaoCreditoBLL>();
            services.AddScoped<DadosUsuarioBLL>();
            services.AddScoped<PagSeguroBLL>();
            services.AddLibraryConfig();
            services.AddScoped<CalcPrecoPrazoWSSoap>(options =>
            {
                var servico = new CalcPrecoPrazoWSSoapClient(CalcPrecoPrazoWSSoapClient.EndpointConfiguration.CalcPrecoPrazoWSSoap);
                return servico;
            });
            services.AddScoped<FuncoesBase>();
            services.AddHttpContextAccessor();
            services.AddSession();
            //configurando swagger
            services.AddSwaggerConfiguration();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                //configura o xml do swagger
                app.UseSwaggerConfiguration();
                
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{Action=Index}/{id?}"
                    );

                endpoints.MapRazorPages();

                endpoints.MapControllers();

            });
        }
    }
}
