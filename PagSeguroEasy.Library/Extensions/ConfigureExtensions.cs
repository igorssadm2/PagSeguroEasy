using Microsoft.Extensions.DependencyInjection;
using PagSeguroEasy.Library.Services;

namespace PagSeguroEasy.Library
{
    public static class ConfigureExtensions
    {
        public static void AddLibraryConfig(this IServiceCollection services)
        {
            services.AddScoped<ICriarSessaoService, CriarSessaoService>();
            services.AddScoped<IObterMeiosPagamentoService, ObterMeiosPagamentoService>();
            services.AddScoped<IObterTokenCartaoService, ObterTokenCartaoService>();
            services.AddScoped<IObterBandeiraCartaoService, ObterBandeiraCartaoService>();
            services.AddScoped<IObterCondicoesParcelamentoService, ObterCondicoesParcelamentoService>();
            services.AddScoped<IPagamentoCartaoDeCreditoService, PagamentoCartaoDeCreditoService>();
            services.AddScoped<IPostWebApiService, PostWebApiService>();
            services.AddScoped<IGerarPayment, GerarPayment>();
        }
    }
}
