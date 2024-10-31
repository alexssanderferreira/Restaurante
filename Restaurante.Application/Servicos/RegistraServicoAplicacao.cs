using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Application.Contratos;
using System.Reflection;

namespace Restaurante.Application.Servicos;

public static class RegistraServicoAplicacao
{
    public static IServiceCollection AddServicosAplicacao(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IItemDoMenuService, ItemDoMenuService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
