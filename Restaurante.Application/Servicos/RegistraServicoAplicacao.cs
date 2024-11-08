﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Application.Contratos;
using Restaurante.Application.Mapeamento;

namespace Restaurante.Application.Servicos;

public static class RegistraServicoAplicacao
{
    public static IServiceCollection AddServicosAplicacao(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IItemDoMenuService, ItemDoMenuService>();
        services.AddScoped<IPedidoService, PedidoService>();

        services.AddAutoMapper(typeof(RestauranteProfile));

        return services;
    }
}
